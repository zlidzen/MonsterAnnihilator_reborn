using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ma_krnl;

namespace ma_game
{
    class Game
    {
        public static Human getStartPerson(int sp)
        {
            if (sp == 0) return new Human("", 1, 25, 3, 2, 1, new Dice(), 1, new Dice(1, 5), 0, "", 0);
            else return new Human("", 1, 30, 2, 3, 1, new Dice(1, 5), 1, new Dice(), 0, "", 1);
        }
        
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
                /*
                //read / write to binary file
            
class MyStream
{
    private const string FILE_NAME = "Test.data";
        using (FileStream fs = new FileStream(FILE_NAME, FileMode.CreateNew))
        {
            using (BinaryWriter w = new BinaryWriter(fs))
            {
                for (int i = 0; i < 11; i++)
                {
                    w.Write(i);
                }
            }
        }

        using (FileStream fs = new FileStream(FILE_NAME, FileMode.Open, FileAccess.Read))
        {
            using (BinaryReader r = new BinaryReader(fs))
            {
                for (int i = 0; i < 11; i++)
                {
                    Console.WriteLine(r.ReadInt32());
                }
            }
        }
    }
}

                */

                string fileName = h.name + ".her";
                using(BinaryWriter hw = new BinaryWriter(File.Open(fileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None)))
                {
                    hw.Seek(0, SeekOrigin.End);
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
                }

                StreamWriter sw = new StreamWriter("SampleH.txt");
                sw.WriteLine(h.name);
                sw.Close();
            }            
            catch (Exception e) { return false; }
            return true;
        }

        //public static Human getStartPerson(int sp)
        public static void LoadHero(string fileName)
        {
            string name, pass, aDice, dDice;
            int lvl, helsh, power, resist, aThrow, dThrow, sp, exp;

            using (BinaryReader hr = new BinaryReader(File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.None)))
            {                
                name = hr.ReadString();
                pass = hr.ReadString();
                lvl = hr.ReadInt32();
                helsh = hr.ReadInt32();
                power = hr.ReadInt32();
                resist = hr.ReadInt32();
                aThrow = hr.ReadInt32();
                aDice = hr.ReadString();
                dThrow = hr.ReadInt32();
                dDice = hr.ReadString();
                sp = hr.ReadInt32();
                exp = hr.ReadInt32();
            }
            Dice dd = new Dice(dDice);
            Dice ad = new Dice(aDice);
            Human lh = new Human(name, lvl, helsh, power,
                                 resist, aThrow, ad,
                                dThrow, dd, exp, pass, sp);
        }

    }
}
