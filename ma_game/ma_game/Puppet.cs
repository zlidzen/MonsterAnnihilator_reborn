using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ma_game
{
    public abstract class Puppet
    {
        public string name;
        private int lvl;
        private int helsh;
        private int power;
        private int resist;
        private int attackThrow;
        public Dice attackDice;
        private int defenceThrow;
        public Dice defenceDice;

        public int Lvl {
            get { return lvl; }
            set {
                lvl = value < 0 ? 0 : value;
                lvl = value > 10 ? 10 : value;
            }
        }

        public int Helsh
        {
            get { return helsh; }
            set { helsh = value < 0 ? 0 : value; }
        }

        public int Power
        {
            get { return power; }
            set { power = value < 0 ? 0 : value; }
        }

        public int Resist
        {
            get { return resist; }
            set { resist = value < 0 ? 0 : value; }
        }

        public int aThrow
        {
            get { return attackThrow; }
            set { attackThrow = value < 0 ? 0 : value; }
        }
        
        public int dThrow
        {
            get { return defenceThrow; }
            set { defenceThrow = value < 0 ? 0 : value; }
        }

        public Puppet(string name, int lvl, int helsh, int power, int resist, int attackThrow, Dice attackDice, int defenceThrow, Dice defenceDice) {
            this.name = name;
            Lvl = lvl;
            Helsh = helsh;
            Power = power;
            Resist = resist;
            aThrow = attackThrow;
            this.attackDice = attackDice;
            dThrow = defenceThrow;
            this.defenceDice = defenceDice;            
        }

        private List<string> ToStringList() {
            List<string> res = new List<string>();
            res.Add(name);
            res.Add(lvl.ToString());
            res.Add(helsh.ToString());
            res.Add(power.ToString());
            res.Add(resist.ToString());
            res.Add(Game.GetThrowStr(attackThrow, attackDice));
            res.Add(Game.GetThrowStr(defenceThrow, defenceDice));
            return res;
        }
    }    
}
