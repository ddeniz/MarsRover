using Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Plateau: IPlateau
    {
        public int MinX { get; set; }
        public int MinY { get; set; }
        public int MaxX { get; set; }
        public int MaxyY { get; set; }


        public Plateau(int maxX,int maxyY)
        {
            MaxX = maxX;
            MaxyY = maxyY;
        }

    }
}
