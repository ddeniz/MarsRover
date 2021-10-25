using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface IPosition
    {
 
        IPlateau Plateau { get; set; }

        bool SetPoint(IPoint point);

        IPoint GetPoint();
    }
}
