using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dracidoupe
{
    class Sword : IItem
    {
        public string name { get; set; }
        public int goldValue { get; set; }

        public Sword (string _name, int _goldValue)
        {
            name = _name;
            goldValue = _goldValue;
        }
        public void Equip()
        {
        }
        public void Buy()
        {

        }
    }
}
