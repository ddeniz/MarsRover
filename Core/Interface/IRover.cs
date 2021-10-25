using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface IRover
    {
        IPosition Position { get; set; }
        Direction Direction { get; set; }
        void ExecuteCommands(string command);

    }
}
