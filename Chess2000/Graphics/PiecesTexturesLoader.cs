using BoardGame.Pieces;
using BoardGame.Pieces.Chess;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2000.Graphics
{
    internal class PiecesTexturesLoader
    {
        public Texture2D Texture { get; private set; }
        public PiecesTexturesLoader(IPiece piece, string color, ContentManager content)
        {
            if (piece is Pawn) Texture = content.Load<Texture2D>("ChessPieces/" + color + " " + nameof(Pawn));
            else if (piece is Bishop) Texture = content.Load<Texture2D>("ChessPieces/" + color + " " + nameof(Bishop));
            else if (piece is King) Texture = content.Load<Texture2D>("ChessPieces/" + color + " " + nameof(King));
            else if (piece is Knight) Texture = content.Load<Texture2D>("ChessPieces/" + color + " " + nameof(Knight));
            else if (piece is Queen) Texture = content.Load<Texture2D>("ChessPieces/" + color + " " + nameof(Queen));
            else if (piece is Tower) Texture = content.Load<Texture2D>("ChessPieces/" + color + " " + nameof(Tower));
            else Texture = content.Load<Texture2D>("ChessPieces/default");
        }
    }
}
