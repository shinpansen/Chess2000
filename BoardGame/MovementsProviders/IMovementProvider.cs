﻿using BoardGame.SquaresLocation.Links;
using BoardGame.Squares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame.MovementsProviders;

public interface IMovementProvider
{
    public bool TryGetSquare(Queue<ISquareLink> links, out ISquare square, bool pathShouldBeFree);
}