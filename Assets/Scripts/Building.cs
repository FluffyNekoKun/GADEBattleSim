using System;
using System.Collections.Generic;
using System.Linq;

    public abstract class Building
    {
        protected int hp;
        protected int xPos;
        protected int yPos;
        protected string faction;
        protected char symbol;
    protected int maxHp;

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
        public string Faction {
            get
            {
                return faction;
            }

            set
            {
                faction= value;
            }
        }
        public char Symbol {
            get
            {
                return symbol;
            }

            set
            {
             symbol = value;
            }
        }
        public int XPos {
            get
            {
                return xPos;
            }

            set
            {
                xPos = value;
            }
        }
        public int YPos {
            get
            {
                return yPos;
            }

            set
            {
              yPos = value;
            }
        }
    public int MaxHp
    {
        get
        {
            return maxHp;
        }
        set
        {
            maxHp = value;
        }
    }
        public Building(int hp,int xPos,int yPos,string faction,char symbol)
        {
            this.Hp = hp;
            this.XPos = xPos;
            this.YPos = YPos;
            this.Faction = faction;
            this.Symbol = symbol;
        }
        public abstract void SaveFile();

        public override string ToString()
        {
            return "Building"+this.GetType()+ " hp: "+hp+" x:"+XPos+ " YPos"+YPos+ " Faction: "+Faction;

        }
        public abstract Boolean isDead();
    }

