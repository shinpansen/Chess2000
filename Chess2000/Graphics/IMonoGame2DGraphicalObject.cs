using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2000.Graphics
{
    internal interface IMonoGame2DGraphicalObject
    {
        public void Draw(Point centerPoint, ContentManager content);
    }
}
