using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ma_krnl;
using System.Runtime.Serialization.Formatters.Binary;


namespace ma_game
{
    class Game
    {
        public static Human Personage;
        public static Human Monster;
        public static List<Human> Heroes = new List<Human>();
        public static List<Human> Monsters = new List<Human>();
        
        enum gameState : byte { finished, started };
        enum actionPosition : byte { protect = 1, attack = 2 };

        public static void setStart()
        {
            throw new NotImplementedException();
        }

        public static bool readHeroList()
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            try
            {
                if (File.Exists("her.dat"))
                {
                    using (Stream fStream = new FileStream("her.dat", FileMode.Open, FileAccess.Read, FileShare.None))
                    {
                        Human r = (Human)binFormat.Deserialize(fStream);
                        Heroes.Add(r);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;             
            }
            return true;
        }

        public static bool writeNewHero(Human newHero)
        {          
            BinaryFormatter binFormat = new BinaryFormatter();
            try
            {
                using (Stream fStream = new FileStream("her.dat", FileMode.Append, FileAccess.Write, FileShare.None))
                {
                    binFormat.Serialize(fStream, newHero);
                }
            }
            catch(Exception ex)
            {
                throw ex;              
            }
            return true;
        }

        public static bool makeNewPersonage(int spec, string Name, string pass)
        {
            Personage = (spec == 0) ? new Human(Name, 1, 30, 2, 0, 1, new Dice(), 1, new Dice(1, 5), "Berserker.png", 0, pass, 0) :
                                    new Human(Name, 1, 25, 1, 1, 1, new Dice(1, 5), 1, new Dice(), "Guardian.png", 0, pass, 0);
            bool res = (Personage != null);

            if (res)
            {
                res = writeNewHero(Personage);
            }
            return res; 
        }

        public static Human setStartPersonage(int sp)
        {
            if (sp == 0) return new Human("", 1, 25, 3, 2, 1, new Dice(), 1, new Dice(1, 5),"", 0, "", 0);
            else return new Human("", 1, 30, 2, 3, 1, new Dice(1, 5), 1, new Dice(), "", 0, "", 1);
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
            catch { return false; }
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
                                dThrow, dd, "", exp, pass, sp);
        }

    }
}
