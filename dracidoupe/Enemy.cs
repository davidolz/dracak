using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dracidoupe
{
    class Enemy
    {

        private string _name;
        private double _health;
        private double _maxhealth;
        private int _attack;
        private int _exp;
        

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public double Health
        {
            get
            {
                return _health;
            }

            set
            {
                _health = value;
            }
        }

        public int Attack
        {
            get
            {
                return _attack;
            }

            set
            {
                _attack = value;
            }
        }

        public int Exp
        {
            get
            {
                return _exp;
            }

            set
            {
                _exp = value;
            }
        }

        public double MaxHealth
        {
            get
            {
                return _maxhealth;
            }

            set
            {
                _maxhealth = value;
            }
        }
    }
}
