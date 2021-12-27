using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLlaunchingApp.lib
{
    public static class Table
    {
        public static bool HasValue( string[] table , string val  )
        {
            foreach ( var item in table )
                if( item == val) return true;
            return false;
        }
    }
}
