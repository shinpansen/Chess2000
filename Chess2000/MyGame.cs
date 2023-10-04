using BoardGame.Game.Chess;
using Chess2000.Graphics;
using Chess2000.Points;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Linq;

namespace Chess2000
{
    public class MyGame : Game
    {
        private GraphicsDeviceManager _graphics { get; set; }
        private SpriteBatch _spriteBatch { get; set; }
        private MonoGameWindowPoint _monoGameWindowPoint { get; set; }
        private MonoGameChessBoard _monoGameChessBoard { get; set; }
        private BoardGame.Game.IGame _chessGame { get; set; }

        Texture2D p;

        public MyGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            _chessGame = new ChessGame();

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
            _monoGameWindowPoint = new MonoGameWindowPoint(GraphicsDevice);
            _monoGameChessBoard = new MonoGameChessBoard(GraphicsDevice, _spriteBatch, 64);
        }

        protected override void Update(GameTime gameTime)
        {
            /*if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();*/

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(20, 20, 20));

            _monoGameChessBoard.Draw(_monoGameWindowPoint.GetCenterScreenPoint(), Content);
            foreach (var piece in _chessGame.GetAvailablePlayers().First().GetAvailablePieces())
                _monoGameChessBoard.DrawChessPiece(_monoGameWindowPoint.GetCenterScreenPoint(), piece, "Black", Content);
            foreach (var piece in _chessGame.GetAvailablePlayers().ElementAt(1).GetAvailablePieces())
                _monoGameChessBoard.DrawChessPiece(_monoGameWindowPoint.GetCenterScreenPoint(), piece, "White", Content);

            base.Draw(gameTime);
        }
    }
}