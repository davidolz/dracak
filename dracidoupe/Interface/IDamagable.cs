using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dracidoupe
{
    interface IDamagable
    {
        int durability { get; set; }
        void TakeDamage(int _amount);
    }
}
