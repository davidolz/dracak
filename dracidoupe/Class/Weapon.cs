using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dracidoupe
{
    public class Weapon : IItem
    {       
        public int goldValue { get; set; }
        public int value { get; set; }

        public Weapon(int _goldValue, int _value)
        {           
            goldValue = _goldValue;
            value = _value;
        }
        public void Equip()
        {

        }
        public void Discard()
        {

        }
    }
}
