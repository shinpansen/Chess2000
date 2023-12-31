﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame.SquaresLocation.Links._2DGrid
{
    public class Link2DGridBuilder
    {
        private Queue<ISquareLink> links = new Queue<ISquareLink>();

        public Link2DGridBuilder Link(ISquareLink link)
        {
            links.Enqueue(link);
            return this;
        }
        public Link2DGridBuilder Link(ISquareLink link, int iterations)
        {
            for (int i = 0; i < iterations; i++) links.Enqueue(link);
            return this;
        }

        public Link2DGridBuilder Top()
        {
            links.Enqueue(new Top());
            return this;
        }

        public Link2DGridBuilder Top(int iterations)
        {
            for(int i = 0; i<iterations; i++) links.Enqueue(new Top());
            return this;
        }

        public Link2DGridBuilder Bottom()
        {
            links.Enqueue(new Bottom());
            return this;
        }

        public Link2DGridBuilder Bottom(int iterations)
        {
            for (int i = 0; i < iterations; i++) links.Enqueue(new Bottom());
            return this;
        }

        public Link2DGridBuilder Left()
        {
            links.Enqueue(new Left());
            return this;
        }

        public Link2DGridBuilder Left(int iterations)
        {
            for (int i = 0; i < iterations; i++) links.Enqueue(new Left());
            return this;
        }

        public Link2DGridBuilder Right()
        {
            links.Enqueue(new Right());
            return this;
        }

        public Link2DGridBuilder Right(int iterations)
        {
            for (int i = 0; i < iterations; i++) links.Enqueue(new Right());
            return this;
        }

        public Link2DGridBuilder TopLeft()
        {
            links.Enqueue(new TopLeft());
            return this;
        }

        public Link2DGridBuilder TopLeft(int iterations)
        {
            for (int i = 0; i < iterations; i++) links.Enqueue(new TopLeft());
            return this;
        }

        public Link2DGridBuilder TopRight()
        {
            links.Enqueue(new TopRight());
            return this;
        }

        public Link2DGridBuilder TopRight(int iterations)
        {
            for (int i = 0; i < iterations; i++) links.Enqueue(new TopRight());
            return this;
        }

        public Link2DGridBuilder BottomLeft()
        {
            links.Enqueue(new BottomLeft());
            return this;
        }

        public Link2DGridBuilder BottomLeft(int iterations)
        {
            for (int i = 0; i < iterations; i++) links.Enqueue(new BottomLeft());
            return this;
        }

        public Link2DGridBuilder BottomRight()
        {
            links.Enqueue(new BottomRight());
            return this;
        }

        public Link2DGridBuilder BottomRight(int iterations)
        {
            for (int i = 0; i < iterations; i++) links.Enqueue(new BottomRight());
            return this;
        }

        public Queue<ISquareLink> Build()
        {
            return links;
        }
    }
}
