using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLlaunchingApp.lib
{
    public struct Ppoint
    {
        public Ppoint(int x , int y)
        {
            X = x;
            Y = y;
        }
        public int X;
        public int Y;
        public override string ToString()
        {
            return $"x:{this.X};y:{this.Y}";
        }
    }
}
