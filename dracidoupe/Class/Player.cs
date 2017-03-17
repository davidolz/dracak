using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dracidoupe
{
    public class Player : ICharacterBonuses
    {
        private string _name;
        private string _type;
        private string _gender;
        private string _race;
        private double _exp;
        private double _health;
        private double _attack;
        private double _maxhealth;
        public Weapon Weapon;      
      
        public string Name {get { return _name; }set{_name = value;}}
        public string Type{get{return _type;}set{ _type = value;}}
        public string Gender{get{return _gender;}set{ _gender = value;}}
        public string Race{get{return _race;}set{_race = value;}}
        public double Exp {get{ return _exp;}set{ _exp = value;}}
        public double Health{get{return _health;}set{ _health = value;}}
        public double MaxHealth { get { return _maxhealth; } set { _maxhealth = value; } }
        public double Attack{get{ return _attack; }set{_attack = value;}}

        public Player()
        {
        }
       

        /*public Player(string playername, string playertype, string playergender, string playerrace)
        {
            PlayerName = playername;
            PlayerType = playertype;
            PlayerGender = playergender;
            PlayerRace = playerrace;
            PlayerHealth = 100;
            PlayerAttack = 10;
            PlayerDefense = 10;
        }*/
        /*
        public double attackBonus { get; set; }
        public double healthBonus { get; set; }
        public double defenseBonus { get; set; }
        
         Attack bonus = Trpaslík or Válečník
         Health Bonus = Elf + Hranicar
         Defense = Clovek + Sermir
        
        public void GiveAttackBonus()
        {
           if(PlayerRace == "Trpaslík" && PlayerType == "Válečník")
            {
                attackBonus = PlayerAttack * 1.2;
            }
            else if (PlayerRace == "Trpaslík" || PlayerType == "Válečník")
            {
                attackBonus = PlayerAttack * 1.1;
            }
            else { }
        }
        public void GiveHealthBonus()
        {
            if (PlayerRace == "Elf" && PlayerType == "Hraničář")
            {
                healthBonus = PlayerHealth * 1.2;
            }
            else if (PlayerRace == "Elf" || PlayerType == "Hraničář")
            {
                healthBonus = PlayerHealth * 1.1;
            }                       
            else { }
        }
        public void GiveDefenseBonus()
        {
            if (PlayerRace == "Člověk" && PlayerType == "Šermíř")
            {
                defenseBonus = PlayerDefense * 1.2;
            }
            else if (PlayerType == "Šermíř" || PlayerRace == "Člověk")
            {
                defenseBonus = PlayerDefense * 1.1;
            }
            else { }
        }
        */
    }
}
