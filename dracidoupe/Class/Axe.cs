using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dracidoupe
{
    class Axe : IItem, IDamagable
    {
        public string name { get; set; }
        public int goldValue { get; set; }
        public int durability { get; set; }


        public Axe(string _name, int _goldValue, int _durability)
        {
            name = _name;
            goldValue = _goldValue;
            durability = _durability;
        }
        public void Equip()
        {
        }
        public void Buy()
        {

        }
        public void TakeDamage(int _dmg)
        {
            durability -= _dmg;
        }

    }
}
