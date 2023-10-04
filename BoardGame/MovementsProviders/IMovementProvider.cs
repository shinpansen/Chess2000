using BoardGame.SquaresLocation.Links;
using BoardGame.Squares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoardGame.Pieces;
using BoardGame.SquaresLocation;
using BoardGame.Movements;

namespace BoardGame.MovementsProviders;

public interface IMovementProvider
{
    public List<IMovement> GetAvailableMoves();
    public List<IMovement> SimulateAvailableMoves();
    public bool TryGetSquare(Queue<ISquareLink> links, out ISquare square, bool pathShouldBeFree);
    public bool TryGetPiece(ISquareLocation location, out IPiece piece);
}
