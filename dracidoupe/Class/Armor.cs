using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dracidoupe
{
    class Armor : IItem, IDamagable
    {
        public string name { get; set; }
        public int goldValue { get; set; }
        public int value { get; set; }
        public int durability { get; set; }


        public Armor(string _name, int _goldValue, int _value, int _durability)
        {
            name = _name;
            goldValue = _goldValue;
            value = _value;
            durability = _durability;
        }
        public void Equip()
        {
        }
        public void Discard()
        {

        }
        public void TakeDamage(int _dmg)
        {
            durability -= _dmg;
        }

    }
}
