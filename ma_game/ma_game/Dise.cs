using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ma_game
{
    public class Dice
    {
        // xdn
        private int x;
        private int n;

        public int X {
            get { return x; }
            set { x = value < 1 ? 1 : value; }
        }

        public int N
        {
            get { return n; }
            set { n = value < 1 ? 1 : value; }
        }

        public Dice(int ax = 1, int an = 6) {
            X = ax;
            N = an;
        }

        public Dice(string strDice) {
            string[] separators = { "d", "D" };            
            string[] words = strDice.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            int buff = 0;
            int.TryParse(words[0], out buff);
            X = buff;
            int.TryParse(words[1], out buff);
            N = buff;
        }

        public override string ToString()
        {
            return x.ToString() + "d" + n.ToString();
        }        
    }          
}
