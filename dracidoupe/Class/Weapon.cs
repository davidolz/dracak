using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dracidoupe
{
    class Weapon : IItem
    {
        public string name { get; set; }
        public int goldValue { get; set; }
        public int value { get; set; }

        public Weapon(string _name, int _goldValue, int _value)
        {
            name = _name;
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
