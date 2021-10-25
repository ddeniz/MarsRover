using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface IPlateau
    {
        int MinX { get; set; }
        int MinY { get; set; }
        int MaxX { get; set; }
        int MaxyY { get; set; }
    }
}
