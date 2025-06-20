using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheColor
{
    class Color
    {
        internal int R { get; }
        internal int G { get; }
        internal int B { get; }

        public Color(int red, int green, int blue)
        {
            R = red;
            G = green;
            B = blue;
        }

        internal static Color White() => new Color(255, 255, 255);
        internal static Color Black() => new Color(0, 0, 0);
        internal static Color Red() => new Color(255, 0, 0);
        internal static Color Orange() => new Color(255, 165, 0);
        internal static Color Yellow() => new Color(255, 255, 0);
        internal static Color Green() => new Color(0, 128, 0);
        internal static Color Blue() => new Color(0, 0, 255);
        internal static Color Purple() => new Color(128, 0, 128);
    }
}
