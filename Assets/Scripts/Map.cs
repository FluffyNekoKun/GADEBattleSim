using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;


    
    class Map
    {
        
        public Char[,] mapArr = new Char[20, 20];
        public Unit[] units = new Unit[10];
        public   Unit[] loadUnits = new Unit[10]; 
        public Building[] buildings = new Building[4];
        public ResourceBuilding[] rBuildings=new ResourceBuilding[2];
        public FactoryBuilding[] fBuildings=new FactoryBuilding[2];

        public int resourceH = 0;
        public int resourceE = 0;


       public Random r = new Random();
      
        public Map()//fills map and array
        {
         
            for (int i = 0; i < 20; ++i)
            {
                for (int j = 0; j < 20; ++j)
                {
                    mapArr[i, j] = ',';
                }
            }

            for (int i=0;i<10;i++)
            {
                int factionRnd = r.Next(1,3);//random for both factions betteween 1 and 2
                int rndX = r.Next(0,19);
                int rndY = r.Next(0, 19);
                if (factionRnd == 1)
                {
                    int typeRnd = r.Next(1, 3); //random for class type
                    if (typeRnd==1)
                    {
                        int classRnd = r.Next(1, 3);
                        if (classRnd == 1)
                        {
                            units[i] = new RangeUnit(10, 10, 1, 2, 2, rndX, rndY, faction: "Hero", unitType: "Sniper", symbol: 'R');
                            units[i].MaxHp = 10;
                        units[i].XPos = rndX;
                        units[i].YPos = rndY;

                        }
                        else
                        {
                            units[i] = new RangeUnit(10, 10, 1, 2, 2, rndX, rndY, faction: "Hero", unitType: "Archer", symbol: 'R');
                            units[i].MaxHp = 10;
                        units[i].XPos = rndX;
                        units[i].YPos = rndY;
                    }
                    }
                    else
                    {
                        int classRnd = r.Next(1, 3);
                        if (classRnd==1)
                        {

                            units[i] = new MeeleUnit(20, 20, 2, 1, 1, rndX, rndY, faction: "Hero",unitType:"Tank", symbol: 'M');
                            units[i].MaxHp = 20;
                        units[i].XPos = rndX;
                        units[i].YPos = rndY;
                    }
                        else
                        {
                            units[i] = new MeeleUnit(20, 20, 2, 1, 1, rndX, rndY, faction: "Hero", unitType: "Slayer", symbol: 'M');
                            units[i].MaxHp = 20;
                        units[i].XPos = rndX;
                        units[i].YPos = rndY;
                    }
                    }

                }
                else
                {
                    int typeRnd = r.Next(1, 3); //random for class type
                    if (typeRnd == 1)
                    {
                        int classRnd = r.Next(1, 3);
                        if (classRnd == 1)
                        {
                            units[i] = new RangeUnit(10, 10, 1, 2, 2, rndX, rndY, faction: "Enemy", unitType: "Sniper", symbol: 'T');
                            units[i].MaxHp = 10;
                        units[i].XPos = rndX;
                        units[i].YPos = rndY;

                    }
                        else
                        {
                            units[i] = new RangeUnit(10, 10, 1, 2, 2, rndX, rndY, faction: "Enemy", unitType: "Archer", symbol: 'T');
                            units[i].MaxHp = 10;
                        units[i].XPos = rndX;
                        units[i].YPos = rndY;
                    }
                    }
                    else
                    {
                        int classRnd = r.Next(1, 3);
                        if (classRnd == 1)
                        {

                            units[i] = new MeeleUnit(20, 20, 2, 1, 1, rndX, rndY, faction: "Enemy", unitType: "Tank", symbol: 'W');
                            units[i].MaxHp = 20;
                        units[i].XPos = rndX;
                        units[i].YPos = rndY;
                    }
                        else
                        {
                            units[i] = new MeeleUnit(20, 20, 2, 1, 1, rndX, rndY, faction: "Enemy", unitType: "Slayer", symbol: 'W');
                            units[i].MaxHp = 20;
                        units[i].XPos = rndX;
                        units[i].YPos = rndY;
                    }
                    }
                }

            }

            int xRnd = r.Next(0, 19);

            int yRnd = r.Next(0, 19);

            rBuildings[0] = new ResourceBuilding(40,xRnd,yRnd,"Hero",'Y');
            rBuildings[0].YPos = yRnd;
            rBuildings[0].ResourcePerTic = 1;
            rBuildings[0].ResType="Wood";
            rBuildings[0].ResourceRemaining = 20;


            xRnd = r.Next(0, 20);
            yRnd = r.Next(0, 20);

            rBuildings[1] = new ResourceBuilding(40,xRnd,yRnd,"Enemy",'A');
            rBuildings[1].YPos = yRnd;
            rBuildings[1].ResourcePerTic = 1;
            rBuildings[1].ResType = "Wood";
            rBuildings[1].ResourceRemaining = 20;


            xRnd = r.Next(0, 20);

            yRnd = r.Next(0, 20);

            fBuildings[0] = new FactoryBuilding(40,xRnd,yRnd,"Hero",'X');
            fBuildings[0].YPos = yRnd;
            int rndSpn = r.Next(1, 3);
            if (rndSpn == 1)
            {
                fBuildings[0].UnitSpn = "Meele";
                fBuildings[0].SpnTic = 5;
                fBuildings[0].SpnPtCalc();
            }
            else
            {
                fBuildings[0].UnitSpn = "Range";
                fBuildings[0].SpnTic = 5;
                fBuildings[0].SpnPtCalc();
            }

            xRnd = r.Next(0, 20);

            yRnd = r.Next(0, 20);

           fBuildings[1] = new FactoryBuilding(40,xRnd,yRnd,"Enemy",'B');
            fBuildings[0].YPos = yRnd;
            rndSpn = r.Next(1, 3);
            if (rndSpn == 1)
            {
                fBuildings[1].UnitSpn = "Meele";
                fBuildings[1].SpnTic = 5;
                fBuildings[1].SpnPtCalc();
            }
            else
            {
                fBuildings[1].UnitSpn = "Range";
                fBuildings[1].SpnTic = 5;
                fBuildings[1].SpnPtCalc();
            }


        }
        ~Map()
        {
            
           

        }

   

        public string DrawMap()//draws map
        {
            string map = "";
            for (int i=0;i<20;i++)
            {
                for (int j = 0; j < 20; j++)
                { map += mapArr[i, j]; }
                map += "\n";
            }
            return map;
        }

        public void UpdateMap()
        {

            for (int k = 0; k < 20; ++k)
            {
                for (int j = 0; j < 20; ++j)
                {
                    mapArr[k, j] = ',';
                }
            }

            for (int i = 0; i < units.Length; i++)
            {
                if (units[i].isDead() == false)
                {
                    mapArr[ units[i].YPos, units[i].XPos] = units[i].Symbol;//place current unit in square
                }
             
            }

            for (int j=0; j < rBuildings.Length; j++)
            {
                if(rBuildings[j].isDead()==false)
                mapArr[rBuildings[j].YPos, rBuildings[j].XPos] = rBuildings[j].Symbol;
            }

            for (int j = 0; j< fBuildings.Length; j++)
            {
                if(fBuildings[j].isDead()==false)
                mapArr[fBuildings[j].YPos, fBuildings[j].XPos] = fBuildings[j].Symbol;
            }
          ;

            
            DrawMap();//draw map again
        }
     public void UnitMovementChoice(int seconds)
        {
           
            for (int i = 0; i < units.Length; i++)
            {
               
                    if (units[i] != null || units[i].isDead() != true)//check if units are dead or null
                    { 
                        int target = units[i].CheckClosest(units);//recive int(index) of closest unit
                        if (units[i].Hp < (units[i].MaxHp * 0.25)&& seconds % (units[i].Spd) == 0)//check if should run and if can move due to speed
                        {
                            
                            string direction = units[i].MoveUnit(units[target]);
                            units[i].XYChange(direction);
                        

                        }
                      
                        else if (units[i].RngCheck(units[target].XPos, units[target].YPos) == true)
                        {
                            units[target].Hp = units[i].CombatDmg(units[i].Atk, units[target].Hp);

                        }
                        else if(seconds % (units[i].Spd) == 0)
                        {
                           
                            string direction = units[i].MoveUnit(units[target]);
                            units[i].XYChange(direction);
                        }

                    }
            
            }
            UpdateMap();//update units postion in map array
                        //for passing into the UpdateMap() method
        }
      public void Spwn(int seconds)
       {
           for (int i = 0; i < fBuildings.Length; i++)
           {
               if (seconds %(fBuildings[i].SpnTic)==0&&seconds!=0)
                {
                    Unit[] newUnits = new Unit[units.Length + 1];
                    for (int j = 0; j < units.Length; j++)
                    {
                        newUnits[j] = units[j];
                    }
               
                    newUnits[units.Length] = fBuildings[i].Spawn();

                    if (fBuildings[i].UnitSpn == "Meele")
                    {
                        newUnits[units.Length].MaxHp = 20;
                    }
                    else
                    {
                        newUnits[units.Length].MaxHp = 10;
                    }

                   units = newUnits;
              }
           }
      }
        public void ResGenH()
        {
            for (int i=0;i<rBuildings.Length;i++)
            {
                if (rBuildings[i].Faction == "Hero")
                {
                    if (rBuildings[i].GenarateResources() == true)
                    {
                        resourceH++;
                    }
                }
            }
        }

        public void ResGenE()
        {
            for (int i = 0; i < rBuildings.Length; i++)
            {
                if (rBuildings[i].Faction=="Enemy")
                {
                    if (rBuildings[i].GenarateResources() == true)
                    {
                        resourceE++;
                    }
                }
            }
        }
    }
    

