using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2000.Window
{
    internal interface IClickable
    {
        public bool IsSelected { get; set; }
        public bool IsClicked(Point point);
    }
}
