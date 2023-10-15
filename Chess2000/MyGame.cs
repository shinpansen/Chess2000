using BoardGame.Game.Chess;
using BoardGame.SquaresLocation.Chess;
using Chess2000.Actions;
using Chess2000.Drawables.Chess;
using Chess2000.Window;
using Chess2000.Controls;
using Chess2000.Drawables;
using Chess2000.Window.Chess;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;
using Chess2000.Drawables.Actions;
using Chess2000.Drawables.UI;

namespace Chess2000
{
    public class MyGame : Game
    {
        public static readonly Color TransparencyColor = Color.Pink;

        public IEnumerable<IDrawable> GameDrawables => new List<IDrawable>() 
        { 
            _drawableBoard,
            _cursor,
            _selection,
            _checkTargetHighlight,
            _checkSourceHighlight
        }
        .Concat(_drawablePieces)
        .Concat(_actions)
        .Where(d => d is not null);

        public IEnumerable<IClickable> GameClickables => new List<IClickable>().Concat(
            _drawablePieces.Where(d => _chessGame.GetCurrentPlayers().First().GetAvailablePieces().Any(p => p == d.Piece)))
            .Concat(_actions);

        private readonly GraphicsDeviceManager _graphics;
        private readonly BoardGame.Game.IGame _chessGame;
        private SpriteBatch _spriteBatch;
        private GraphicsManager _graphicsManager;
        private ViewPort _viewPort;
        private ChessBoard _drawableBoard;
        private ActionsProvider _actionsProvider;
        private List<Drawables.Chess.ChessPiece> _drawablePieces;
        private List<Action> _actions;
        private Cursor _cursor;
        private PieceHighlight _selection;
        private CheckTargetHighlight _checkTargetHighlight;
        private CheckSourceHighlight _checkSourceHighlight;
        private MouseTools _mouseTools;
        private Point _mouseClickLocation;

        public MyGame()
        {
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
            Window.AllowUserResizing = true;

            _graphics = new GraphicsDeviceManager(this);
            _chessGame = new ChessGame();
            _drawablePieces = new List<Drawables.Chess.ChessPiece>();
            _actions = new List<Action>();
            _mouseTools = new MouseTools();
        }

        protected override void Initialize()
        {
            base.Initialize();

            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _viewPort = new ViewPort(GraphicsDevice);
            _graphicsManager = new GraphicsManager(GraphicsDevice, Content, _spriteBatch);
            _drawableBoard = new ChessBoard(_graphicsManager);
            _actionsProvider = new ActionsProvider(_graphicsManager);
            _cursor = new Cursor(_graphicsManager, this);
            UpdateDrawablePiecesList();
        }

        protected override void Update(GameTime gameTime)
        {
            /*if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();*/

            MouseState mouseState = Mouse.GetState();
            _mouseClickLocation = new Point(mouseState.X, mouseState.Y);
            var leftButtonMouseClicked = _mouseTools.IsButtonPressed(MouseTools.MouseButton.Left);

            var player = _chessGame.GetCurrentPlayers().First();
            foreach (var drawablePiece in _drawablePieces.Where(d =>  player.GetAvailablePieces().Any(p => d.Piece == p)))
            {
                if (!leftButtonMouseClicked || !drawablePiece.Contains(_mouseClickLocation)) continue;
                _actions.Clear();
                _selection?.Hide();
                drawablePiece.IsSelected = !drawablePiece.IsSelected;
                if (drawablePiece.IsSelected)
                {
                    _actions = _actionsProvider.GetAvailableActions(_chessGame, drawablePiece.Piece);
                    _selection = new PieceHighlight(_graphicsManager, drawablePiece.Piece.Location.ToString(), drawablePiece);
                    foreach (var d in _drawablePieces.Where(dr => dr != drawablePiece))
                        d.IsSelected = false;
                    break;
                }
            }

            foreach (var action in _actions)
            {
                if(leftButtonMouseClicked && action.Contains(_mouseClickLocation))
                {
                    _chessGame.ExecuteMove(action.Piece, action.Move);
                    UpdateDrawablePiecesList();
                    UpdateCheckState();
                    _actions.Clear();
                    _selection?.Hide();
                    break;
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(20, 20, 20));

            foreach (var gameDrawable in GameDrawables.Where(d => d.Visible).OrderBy(d => d.DrawOrder))
                gameDrawable.Draw(gameTime);

            base.Draw(gameTime);
        }

        private void UpdateDrawablePiecesList()
        {
            _drawablePieces.Clear();
            foreach (var piece in _chessGame.GetAvailablePlayers().ElementAt(0).GetAvailablePieces())
                _drawablePieces.Add(new ChessPiece(_graphicsManager, piece, ChessPiece.PieceColor.White));
            foreach (var piece in _chessGame.GetAvailablePlayers().ElementAt(1).GetAvailablePieces())
                _drawablePieces.Add(new ChessPiece(_graphicsManager, piece, ChessPiece.PieceColor.Black));
        }

        private void UpdateCheckState()
        {
            _checkTargetHighlight?.Hide();
            _checkSourceHighlight?.Hide();
            var player = _chessGame.GetCurrentPlayers().ElementAt(0);
            var otherPlayer = _chessGame.GetAvailablePlayers().Where(p => p != player).First();
            foreach (var piece in otherPlayer.GetAvailablePieces())
            {
                var moves = piece.GetAvailableMoves(_chessGame);
                foreach(var move in moves)
                {
                    if(!move.SimulateMove(_chessGame, player).Any(p => p is BoardGame.Pieces.Chess.IKing))
                    {
                        var king = player.GetAvailablePieces().First(p => p is BoardGame.Pieces.Chess.IKing);
                        _checkTargetHighlight = new CheckTargetHighlight(_graphicsManager, king.Location.ToString());
                        _checkSourceHighlight = new CheckSourceHighlight(_graphicsManager, piece.Location.ToString());
                        return;
                    }
                }
            }
        }
    }
}