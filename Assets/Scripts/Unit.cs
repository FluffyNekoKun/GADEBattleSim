using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;


    public abstract class Unit
    {
        private int maxHp;
        private int hp;
        private int atk;
        private int atkRng;
        private int spd;
        private int xPos;
        private int yPos;
        private string faction;
        private string unitType;
        private char symbol;
     
        public Random r = new Random();
        

        public int MaxHp {
            get
            {
                return maxHp;
            }

            set
            {
                maxHp= value;
            }
        }
        public int Hp {
            get
            {
                return hp;
            }

            set
            {
               hp = value;
            }
        }
        public int Atk
        {
            get
            {
                return atk;
            }

            set
            {
             atk   = value;
            }
        }
        public int AtkRng
        {
            get
            {
                return atkRng;
            }

            set
            {
                atkRng= value;
            }
        }
        public int Spd
        {
            get
            {
                return spd;
            }

            set
            {
               spd = value;
            }
        }
        public string Faction
        {
            get
            {
                return faction;
            }

            set
            {
               faction = value;
            }
        }
        public string UnitType
        {
            get
            {
                return unitType;
            }

            set
            {
               unitType = value;
            }
        }
        public char Symbol
        {
            get
            {
                return symbol;
            }

            set
            {
                symbol= value;
            }
        }
        public int XPos
        {
            get
            {
                return xPos;
            }

            set
            {
               xPos = value;
            }
        }
        public int YPos
        {
            get
            {
                return yPos;
            }

            set
            {
              yPos  = value;
            }
        }
     

        public Unit(int maxHP,int hp,int atk,int atkRng,int spd,int xPos, int yPos, string faction,string unitType,char symbol)
        {
            this.MaxHp = maxHp;
            this.Hp = hp;
            this.Atk = atk;
            this.AtkRng = atkRng;
            this.Spd = spd;
            this.XPos = xPos;
            this.YPos = yPos;
            this.Faction = faction;
            this.unitType = unitType;
            this.Symbol = symbol;
       

        }  

        ~Unit()
        {

        }

        abstract public string MoveUnit(Unit unit);


        abstract public void XYChange(string direction);

        abstract public int CombatDmg(int atk, int hp);

        abstract public Boolean RngCheck(int x, int y);


        abstract public int CheckClosest(Unit[] units);


        abstract public Boolean isDead();

     
       

        public override string ToString()
        {

            return base.ToString();
        }
    }

