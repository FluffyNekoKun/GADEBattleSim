using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;


 class FactoryBuilding: Building
    {
        private string unitSpn;
        private int spnTic;
    
        private int spnPtY;
        public Random r = new Random();
        
        public string UnitSpn {
        get
        {
            return unitSpn;
        }

        set
        {
            unitSpn= value;
        }
    }
        public int SpnTic {
        get
        {
            return spnTic;
        }

        set
        {
            spnTic = value;
        }
    }
   
        public int SpnPtY {
        get
        {
            return spnPtY;
        }

        set
        {
            spnPtY= value;
        }
    }

        public FactoryBuilding(int hp,int xPos,int yPos,string faction,char symbol):base(hp,xPos,yPos,faction,symbol)
        {
            UnitSpn="Meele";
        }
        public Unit Spawn()
        {
            if (this.Faction == "Hero")
            {
                if (this.UnitSpn == "Meele")
                {
                    int classRnd = r.Next(1, 3);
                    if (classRnd == 1)
                    {
                        return new MeeleUnit(20, 20, 2, 1, 1, this.XPos, spnPtY, faction: "Hero", unitType: "Sniper", symbol:'R');

                    }
                    else
                    {
                        return new MeeleUnit(20, 20, 2, 1, 1, this.XPos, spnPtY, faction: "Hero", unitType: "Archer", symbol: 'R');
                    }
                }
                else
                {
                    int classRnd = r.Next(1, 3);
                    if (classRnd == 1)
                    {
                        return new RangeUnit(10, 10, 1, 2, 2, this.XPos, spnPtY, faction: "Hero", unitType: "Sniper", symbol: 'R');

                    }
                    else
                    {
                        return new RangeUnit(10, 10, 1, 2, 2,this.XPos, spnPtY, faction: "Hero", unitType: "Archer", symbol: 'R');
                    }
                }
            }
            else
            {
                if (this.UnitSpn == "Meele")
                {
                    int classRnd = r.Next(1, 3);
                    if (classRnd == 1)
                    {
                        return new MeeleUnit(20, 20, 2, 1, 1, this.XPos, spnPtY, faction: "Enemy", unitType: "Sniper", symbol: 'R');

                    }
                    else
                    {
                        return new MeeleUnit(20, 20, 2, 1, 1, this.XPos, spnPtY, faction: "Enemy", unitType: "Archer", symbol: 'R');
                    }
                }
                else
                {
                    int classRnd = r.Next(1, 3);
                    if (classRnd == 1)
                    {
                        return new RangeUnit(10, 10, 1, 2, 2, this.XPos, spnPtY, faction: "Enemy", unitType: "Sniper", symbol: 'R');

                    }
                    else
                    {
                        return new RangeUnit(10, 10, 1, 2, 2, this.XPos, spnPtY, faction: "Enemy", unitType: "Archer", symbol: 'R');
                    }
                }
            }

        }
        public void SpnPtCalc()
        {
     
            if (this.YPos>=10)
            {
                spnPtY = this.YPos - 1;
            }
            else
            {
                spnPtY = this.YPos +1;
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


            if (File.Exists("SAVES/savesBuildingF.file") != true)
            {
                Console.WriteLine("Directory exists");
                File.Create("SAVES/savesBuildingF.file").Close();
                Console.WriteLine("file created");
            }


            FileStream file = new FileStream("SAVES/savesBuildingF.file", FileMode.Open, FileAccess.ReadWrite);

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
            return "Factory,"+this.Hp+","+this.XPos+","+this.YPos+","+this.Faction+","+this.Symbol+","+this.UnitSpn+","+this.spnTic;
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

