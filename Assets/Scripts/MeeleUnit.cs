using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

   class MeeleUnit:Unit
    {
        public MeeleUnit(int maxHP, int hp, int atk, int atkRng, int spd, int xPos, int yPos, string faction, string unitType, char symbol) : base(maxHP, hp, atk, atkRng, spd, xPos, yPos, faction, unitType, symbol)
        {

        }
        ~MeeleUnit()
        {

        }

        public override string MoveUnit(Unit unit)//takes in enemy unit needed to move to and returns a direction to move
        {
            {
                String direction = "";
                if (this.Hp >= this.MaxHp * 0.25)//takes in to consideration if hp is below 25% if so run in random direction but if above 25% move towards enemy
                {

                    int xDirection = this.XPos - unit.XPos;
                    int yDirection = this.YPos - unit.YPos;
                    int absX = Math.Abs(xDirection);
                    int absY = Math.Abs(yDirection);

                    if (absX >= absY)
                    {
                        if (yDirection < 0)
                        {
                            direction = "down";
                        }
                        else
                        {
                            direction = "up";
                        }
                    }
                    else
                    {
                        if (xDirection < 0)
                        {
                            direction = "right";
                        }
                        else
                        {
                            direction = "left";
                        }
                    }
                }
                else
                {
                    int randMove = r.Next(1, 5);
                    switch (randMove)
                    {
                        case 1:
                            direction = "left";
                            break;
                        case 2:
                            direction = "right";
                            break;
                        case 3:
                            direction = "up";
                            break;
                        case 4:
                            direction = "down";
                            break;
                        default:
                            break;

                    }
                }
                return direction;
            }
           
        }

        public override string ToString()
        {
            String stuff = ("HP: " + Hp + " ATK: " + Atk + " Atk RANGE: " + AtkRng + " MovePerTic: " +Spd+ " Faction: " + Faction);
            return stuff;
        }

        public override void XYChange(string direction)//changes x and y positions, made with restirctions so not to go off the map
        {
            if (direction == "up" && this.YPos > 0)
            { YPos = YPos - 1; }
            if (direction == "down" && this.YPos < 19)
            { YPos = YPos + 1; }
            if (direction == "left" && this.YPos > 0)
            { XPos = XPos - 1; }
            if (direction == "right" && this.YPos < 19)
            { XPos = XPos + 1; }
           
        }

        public override int CombatDmg(int atk, int hp)// comabt methode to see damgae dealt and returns the hp remaing of the attacked unit. takes in enemy hp and current unit's atk
        {
            int hpRemain = hp - atk;
            if (hp > 0)
          
            this.isDead();
            return hpRemain;
           
        }

        public override bool RngCheck(int x, int y)// checks range of attack
        {
            Boolean inRng = false;
            int xRng = Math.Abs(XPos - x);
            int yRng = Math.Abs(YPos - y);
            if (xRng <= AtkRng)
            { inRng = true; }

            if (yRng <= AtkRng)
            { inRng = true; }

            return inRng;
           
        }

        public override int CheckClosest(Unit[] units) //checks closest enemy takes i entire array of units returns an int to be placed in the array bpx for index
        {
            int chosen = 0;
            int closestDistance = 1000;//maximum number to be rplaced by a smaller number since looking for the smallest
            int distance = 0;
            int absX = 0;
            int absY = 0;
            for (int i = 0; i < units.Length; i++)
            {
                if (units[i] != null||units[i].isDead()!=true)//checks to see if unit is valid
                {
                    if (units[i].Faction != this.Faction)///checks to see if unit is not the same faction
                    {
                        absX = this.XPos - units[i].XPos;
                        absY = this.YPos - units[i].YPos;
                        distance = absY + absX;
                        if (distance < closestDistance)
                        {
                            closestDistance = distance;//replace lowest with a new lowest
                            chosen = i;
                        }
                    }

                }
            }
            return chosen;
           
        }

        

        public string SaveText()
        {
            return "Meele," +this.MaxHp+","+ this.Hp + "," + this.Atk + "," + this.AtkRng+","+this.Spd+","+ this.XPos + "," + this.YPos + "," + this.Faction + "," +this.UnitType+","+ this.Symbol+",";
        }

        public override bool isDead()//checks if unit is still alive
        {
            if (Hp <= 0)
            {
                this.Hp = 0;
                Symbol = '.';
                return true;
               
            }
            else
            {
                return false;
            }
            
        }

    }

