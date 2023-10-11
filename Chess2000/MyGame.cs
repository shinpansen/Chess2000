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

namespace Chess2000
{
    public class MyGame : Game
    {
        public static readonly Color TransparencyColor = Color.Pink;

        private GraphicsDeviceManager _graphics { get; set; }
        private SpriteBatch _spriteBatch { get; set; }

        private BoardGame.Game.IGame _chessGame { get; set; }
        private ViewPort _viewPort { get; set; }
        private ChessBoard _drawableBoard { get; set; }
        private ActionsProvider _actionsProvider { get; set; }
        private List<Drawables.Chess.Actions.Action> _actions { get; set; }
        private bool _leftButtonMouseClicked = false;
        private Point _mouseClickLocation;

        public MyGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            _chessGame = new ChessGame();
            _actions = new List<Drawables.Chess.Actions.Action>();

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
            _drawableBoard = new ChessBoard(GraphicsDevice, Content);
            _actionsProvider = new ActionsProvider(GraphicsDevice, Content);
        }

        protected override void Update(GameTime gameTime)
        {
            /*if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();*/

            MouseState mouseState = Mouse.GetState();
            _leftButtonMouseClicked = false;
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                _leftButtonMouseClicked = true;
                _mouseClickLocation = new Point(mouseState.X, mouseState.Y);
            }

            foreach (var piece in _chessGame.GetCurrentPlayers().First().GetAvailablePieces())
            {
                var drawable = new ChessPiece(GraphicsDevice, Content, piece);
                if (_leftButtonMouseClicked && drawable.IsClicked(_mouseClickLocation))
                {
                    _actions.Clear();
                    _actions = _actionsProvider.GetAvailableActions(_chessGame, piece);
                    break;
                }
            }

            foreach (var action in _actions)
            {
                if(_leftButtonMouseClicked && action.IsClicked(_mouseClickLocation))
                {
                    _chessGame.ExecuteMove(action.Piece, action.Move);
                    _actions.Clear();
                    break;
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(20, 20, 20));

            _drawableBoard.Draw(gameTime);

            foreach (var action in _actions)
                action.Draw(gameTime);

            foreach (var piece in _chessGame.GetAvailablePlayers().ElementAt(0).GetAvailablePieces())
                new ChessPiece(GraphicsDevice, Content, piece, ChessPiece.PieceColor.White).Draw(gameTime);
            foreach (var piece in _chessGame.GetAvailablePlayers().ElementAt(1).GetAvailablePieces())
                new ChessPiece(GraphicsDevice, Content, piece, ChessPiece.PieceColor.Black).Draw(gameTime);

            base.Draw(gameTime);
        }
    }
}