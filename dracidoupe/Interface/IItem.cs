using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dracidoupe
{
    interface IItem
    {     
        int goldValue { get; set; }
        int value { get; set; }

        void Equip();
        void Discard();
    }
}
