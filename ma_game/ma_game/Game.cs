using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ma_game
{
    class Game
    {
        public static Human b = new Human("", 1, 25, 3, 2, 1, new Dice(), 1, new Dice(1, 5), 0, "", 0);
        public static Human g = new Human("", 1, 30, 2, 3, 1, new Dice(1, 5), 1, new Dice(), 0, "", 1);

        // t*xdn
        public static int GetThrow(int t, Dice d)
        {
            int res = 0;
            Random rnd = new Random();
            for (int i = 0; i < t; i++)     
                res += rnd.Next(d.X, d.N + 1);            
            return res;
        }

        public static string GetThrowStr(int t, Dice d) {
            return t.ToString() + "*" + d.ToString();
        }

        public static bool MakeNewHero(Human h)
        {            
            string line;
            List<string> nameList = new List<string>();
            try
            {
                StreamReader sr = new StreamReader("SampleH.txt");
                line = sr.ReadLine();
                while (line != null)
                {
                    nameList.Add(line);
                    line = sr.ReadLine();
                }
                sr.Close();

                if (nameList.Contains(h.name)) return false;

                string fileName = h.name + ".her";
                BinaryWriter hw = new BinaryWriter(File.Open(fileName, FileMode.OpenOrCreate));
                hw.Write(h.name);
                hw.Write(h.Pass);
                hw.Write(h.Lvl);
                hw.Write(h.Helsh);
                hw.Write(h.Power);
                hw.Write(h.Resist);
                hw.Write(h.aThrow);
                hw.Write(h.attackDice.ToString());
                hw.Write(h.dThrow);
                hw.Write(h.defenceDice.ToString());
                hw.Write(h.Sp);
                hw.Write(h.Exp);
                hw.Close();

                StreamWriter sw = new StreamWriter("SampleH.txt");
                sw.WriteLine(h.name);
                sr.Close();
            }            
            catch (Exception e) { return false; }
            return true;
        }

    }
}
