using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tetris
{
    internal class Piece
    {


        public Piece(int _type, int _color, int _startLoc)
        {
            type = _type;
            color = _color;
            startLoc = _startLoc;

            if (color == 1)
            {
                
            }
        }
        //gonna have to use this int to choose a type of piece from a dictionary most likely
        public int type { get; set; }
        //have like 4 colors 
        public int color { get; set; }
        //the starting location is 1 - number of cols representing where left or right it can spawn
        public int startLoc { get; set; }


    }
}

