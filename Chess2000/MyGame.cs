using BoardGame.Game.Chess;
using BoardGame.SquaresLocation.Chess;
using Chess2000.Actions;
using Chess2000.Drawables.Chess;
using Chess2000.Window;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;
using Chess2000.Controls;
using Chess2000.Drawables;
using Chess2000.Window.Chess;

namespace Chess2000
{
    public class MyGame : Game
    {
        public static readonly Color TransparencyColor = Color.Pink;
        
        public IEnumerable<IDrawable> GameDrawables => new List<IDrawable>(){_drawableBoard}
            .Concat(_drawablePieces)
            .Concat(_actions)
            .Concat(_selections);
        
        private readonly GraphicsDeviceManager _graphics;
        private readonly BoardGame.Game.IGame _chessGame;
        private SpriteBatch _spriteBatch;
        private DrawTools _drawTools;
        private ViewPort _viewPort;
        private ChessBoard _drawableBoard;
        private ActionsProvider _actionsProvider;
        private List<Drawables.Chess.ChessPiece> _drawablePieces;
        private List<Drawables.Chess.Actions.Action> _actions;
        private List<Drawables.Chess.PieceSelection> _selections;
        private MouseTools _mouseTools;
        private Point _mouseClickLocation;

        public MyGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            _chessGame = new ChessGame();
            _drawablePieces = new List<Drawables.Chess.ChessPiece>();
            _actions = new List<Drawables.Chess.Actions.Action>();
            _selections = new List<PieceSelection>();
            _mouseTools = new MouseTools();

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.AllowUserResizing = true;
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
            _drawTools = new DrawTools(GraphicsDevice, Content, _spriteBatch);
            _drawableBoard = new ChessBoard(_drawTools);
            _actionsProvider = new ActionsProvider(_drawTools);
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
                if (!leftButtonMouseClicked || !drawablePiece.IsClicked(_mouseClickLocation)) continue;
                _actions.Clear();
                _selections.Clear();
                drawablePiece.IsSelected = !drawablePiece.IsSelected;
                if (drawablePiece.IsSelected)
                {
                    _actions = _actionsProvider.GetAvailableActions(_chessGame, drawablePiece.Piece);
                    _selections.Add(new PieceSelection(_drawTools, drawablePiece.Piece.Location.ToString()));
                    foreach (var d in _drawablePieces.Where(dr => dr != drawablePiece))
                        d.IsSelected = false;
                    break;
                }
            }

            foreach (var action in _actions)
            {
                if(leftButtonMouseClicked && action.IsClicked(_mouseClickLocation))
                {
                    _chessGame.ExecuteMove(action.Piece, action.Move);
                    UpdateDrawablePiecesList();
                    _actions.Clear();
                    _selections.Clear();
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
                _drawablePieces.Add(new ChessPiece(_drawTools, piece, ChessPiece.PieceColor.White));
            foreach (var piece in _chessGame.GetAvailablePlayers().ElementAt(1).GetAvailablePieces())
                _drawablePieces.Add(new ChessPiece(_drawTools, piece, ChessPiece.PieceColor.Black));
        }
    }
}