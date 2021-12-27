using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcAutoClicker.Lib
{
    public static class cur_pos
    {
        public struct pos
        {
            public int X;
            public int Y;
            public override string ToString()
            {
                return $"x:{X} / y:{Y}";
            }
        }
    }
}
