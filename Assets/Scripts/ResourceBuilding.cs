using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;


     class ResourceBuilding:Building
    {
        private int resourceRemaining;
    private string resType;
        private int resourcePerTic;

        public int ResourceRemaining
    {
        get
        {
            return resourceRemaining;
        }

        set
        {
                resourceRemaining= value;
        }
    }
        public string ResType
    {
        get
        {
            return resType;
        }

        set
        {
               resType = value;
        }
    }
        public int ResourcePerTic
    {
        get
        {
            return resourcePerTic;
        }

        set
        {
              resourcePerTic  = value;
        }
    }

        public ResourceBuilding(int hp, int xPos, int yPos, string faction, char symbol):base(hp,xPos,yPos,faction,symbol)
        {

        }

        public Boolean GenarateResources()
        {
            if (this.ResourceRemaining != 0)
            {
                this.ResourceRemaining--;
                return true;
            }
            else
            {
                return false;
            }

        }

        public override void SaveFile()
        {
            if (!Directory.Exists("SAVES"))
            {
                Console.WriteLine("BAttleFiled is Empty");
                Directory.CreateDirectory("SAVES");
                Console.WriteLine("SAVES Directory created");

            }


            if (File.Exists("SAVES/savesBuildingR.file") != true)
            {
                Console.WriteLine("Directory exists");
                File.Create("SAVES/savesBuildingR.file").Close();
                Console.WriteLine("file created");
            }


            FileStream file = new FileStream("SAVES/savesBuildingR.file", FileMode.Open, FileAccess.ReadWrite);

            StreamWriter write = new StreamWriter(file);
            StreamReader reader = new StreamReader(file);

            if (file.Length != 0)
            {
                string line = reader.ReadLine();
                while (line != null)
                {

                    line = reader.ReadLine();
                }

                write.WriteLine(this.SaveText());
              
                write.Close();
                file.Close();

            }
            else
            {
                write.WriteLine(this.SaveText());
                
                write.Close();
                file.Close();
            }

            reader.Close();


        }

        public string SaveText()
        {
            return "Resource," + this.Hp + "," + this.XPos + "," + this.YPos + "," + this.Faction + "," + this.Symbol+","+this.resType+","+this.ResourceRemaining+","+ResourcePerTic;
        }
        public override bool isDead()//checks if unit is still alive
        {
            if (Hp <= 0)
            {
                this.Hp = 0;
                Symbol = '.';
                return true;
                this.Equals(null);
            }
            else
            {
                return false;
            }

        }
    }

