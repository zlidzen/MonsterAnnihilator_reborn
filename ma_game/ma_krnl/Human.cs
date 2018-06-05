﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ma_krnl
{
    [Serializable]
    public class Human : Puppet
    {
        private int exp;
        private string pass;
        private int spec; // Berserker -> 0 / Guardian -> 1.

        public int Sp {
            get { return spec; }
            set { spec = value < 1 ? 1 : value; }            
        }
        
        public int Exp {
            get { return exp; }
            set { exp = value < 0 ? 0 : value; }
        }

        public string Pass {
            get { return pass; }
            set { pass = value.Length <= 0 ? "1111" : value; }
        }

        public Human(string name, int lvl, int helsh, int power,
                     int resist, int attackThrow, Dice attackDice,
                     int defenceThrow, Dice defenceDice, string pathToPic, int exp, 
                     string pass, int spec)
            : base(name, lvl, helsh, power, resist, attackThrow,
                  attackDice, defenceThrow, defenceDice, pathToPic)
        {
            Exp = exp;
            Pass = pass;
            Sp = spec;
        }

        private List<string> ToStringList()
        {
            List<string> res = ToStringList();
            res.Add(exp.ToString());
            return res;
        }

        public string heroSpec()
        {
            Dictionary<int, string> spec = new Dictionary<int, string>();
            spec.Add(0, "Berserker");
            spec.Add(1, "Guardian");
            return spec[Sp];
        }
    }
}
