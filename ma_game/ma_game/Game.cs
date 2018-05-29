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
            if (File.Exists("her.dat"))
            {
                using (Stream fStream = new FileStream("her.dat", FileMode.OpenOrCreate, FileAccess.Read, FileShare.None))
                {
                    Heroes = (List<Human>)binFormat.Deserialize(fStream);
                }
            }

            return true;
        }

        public static bool writeHeroList()
        {
            BinaryFormatter binFormat = new BinaryFormatter();

            using (Stream fStream = new FileStream("her.dat", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, Heroes);
            }

            return true;
        }

        public static bool makeNewPersonage(int spec, string Name, string pass)
        {
            Personage = (spec == 0) ? new Human(Name, 1, 30, 2, 0, 1, new Dice(), 1, new Dice(1, 5), "Berserker.png", 0, pass, 0) :
                                    new Human(Name, 1, 25, 1, 1, 1, new Dice(1, 5), 1, new Dice(), "Guardian.png", 0, pass, 1);

            bool res = (Personage != null);
            if (res)
            {
                Heroes.Add(Personage);
                res = writeHeroList();
            }
            return res; 
        }

        public static void updateHeroFrame()
        {
            //if (Personage == null) h
        }
        
        // t*xdn
        public static int GetThrowCalculation(int t, Dice d)
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
    }
}
