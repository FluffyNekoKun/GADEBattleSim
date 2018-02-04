using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour {

    public float offset = 5.2f;
    public int gameTime = 0;
    public int seconds = 0;
    public const int refresh = 60;
    public float targetOrtho;
    
    public Unit[] units = new Unit[10];
    public Unit[] loadUnits = new Unit[10];
    public Building[] buildings = new Building[4];
    public float size ;
    public float xPos ;
   public  float yPos ;

    // public FactoryBuilding[] fBuildings = new FactoryBuilding[2];

    public int resourceH = 0;
    public int resourceE = 0;



    // Use this for initialization
    void Start ()
    {
        targetOrtho = Camera.main.orthographicSize;
        float size = Camera.main.orthographicSize;
        float xPos = -4 * size + size + offset;
        float yPos = size;

        InitiatUnit();

        DrawMap(xPos,yPos);
        
    
    }

    void moveMouse(float speed)
    {
        transform.position += new Vector3(Input.GetAxisRaw("Mouse X")* Time.deltaTime* speed,Input.GetAxisRaw("Mouse Y")*Time.deltaTime*speed,0f);
    }
    void zoom()
    {
        float zoomSpd = 1;

        float smoothSpd = 5f;
        float min = 1;
        float max = 20f;

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll !=0.0f)
        {
            targetOrtho -= scroll * zoomSpd;
            targetOrtho = Mathf.Clamp(targetOrtho,min,max);
        }
        Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, targetOrtho, smoothSpd * Time.deltaTime);
    }

    // Update is called once per frame
    void Update ()
    {
        float speed = 5f;
        moveMouse(speed);
        zoom();
        if ((gameTime % (refresh) == 0))
        {

            
            ReDraw();
            PlayeGame();
            seconds++;
        }
        gameTime++;
    }

    void DrawMap(float x,float y)
    {
        for (int k = 0; k < 21; k++)
        {
            for (int j = 0; j < 21; j++)
            {
                Instantiate(Resources.Load("grass"), new Vector3(x + k * offset, y + j * offset, 1), Quaternion.identity);
            }
        }

    }
    void InitiatUnit()
    {
        for (int i = 0; i < 10; i++)
        {
            int factionRnd = UnityEngine.Random.Range(1, 3);//random for both factions betteween 1 and 2
            int rndX = UnityEngine.Random.Range(0, 20);
            int rndY = UnityEngine.Random.Range(0, 20);
            if (factionRnd == 1)
            {
                int typeRnd = UnityEngine.Random.Range(1, 3); //random for class type
                if (typeRnd == 1)
                {
                    int classRnd = UnityEngine.Random.Range(1, 3);
                    if (classRnd == 1)
                    {
                        units[i] = new RangeUnit(10, 10, 1, 2, 2, rndX, rndY, faction: "Hero", unitType: "Sniper", symbol: 'R');
                        units[i].MaxHp = 10;

                    }
                    else
                    {
                        units[i] = new RangeUnit(10, 10, 1, 2, 2, rndX, rndY, faction: "Hero", unitType: "Archer", symbol: 'R');
                        units[i].MaxHp = 10;
                    }
                }
                else
                {
                    int classRnd = UnityEngine.Random.Range(1, 3);
                    if (classRnd == 1)
                    {

                        units[i] = new MeeleUnit(20, 20, 2, 1, 1, rndX, rndY, faction: "Hero", unitType: "Tank", symbol: 'M');
                        units[i].MaxHp = 20;
                    }
                    else
                    {
                        units[i] = new MeeleUnit(20, 20, 2, 1, 1, rndX, rndY, faction: "Hero", unitType: "Slayer", symbol: 'M');
                        units[i].MaxHp = 20;
                    }
                }

            }
            else
            {
                int typeRnd = UnityEngine.Random.Range(1, 3); //random for class type
                if (typeRnd == 1)
                {
                    int classRnd = UnityEngine.Random.Range(1, 3);
                    if (classRnd == 1)
                    {
                        units[i] = new RangeUnit(10, 10, 1, 2, 2, rndX, rndY, faction: "Enemy", unitType: "Sniper", symbol: 'T');
                        units[i].MaxHp = 10;
                    }
                    else
                    {
                        units[i] = new RangeUnit(10, 10, 1, 2, 2, rndX, rndY, faction: "Enemy", unitType: "Archer", symbol: 'T');
                        units[i].MaxHp = 10;
                    }
                }
                else
                {
                    int classRnd = UnityEngine.Random.Range(1, 3);
                    if (classRnd == 1)
                    {

                        units[i] = new MeeleUnit(20, 20, 2, 1, 1, rndX, rndY, faction: "Enemy", unitType: "Tank", symbol: 'W');
                        units[i].MaxHp = 20;
                    }
                    else
                    {
                        units[i] = new MeeleUnit(20, 20, 2, 1, 1, rndX, rndY, faction: "Enemy", unitType: "Slayer", symbol: 'W');
                        units[i].MaxHp = 20;
                    }
                }
            }

        }

        int xRnd = UnityEngine.Random.Range(0, 19);

        int yRnd = UnityEngine.Random.Range(0, 19);

        buildings[0] = new ResourceBuilding(40, xRnd, yRnd, "Hero", 'Y');
        buildings[0].YPos = yRnd;
        buildings[0].MaxHp = 40;


        xRnd = UnityEngine.Random.Range(0, 20);
        yRnd = UnityEngine.Random.Range(0, 20);

        buildings[1] = new ResourceBuilding(40, xRnd, yRnd, "Enemy", 'A');
        buildings[1].YPos = yRnd;
        buildings[1].MaxHp = 40;


        xRnd = UnityEngine.Random.Range(0, 20);

        yRnd = UnityEngine.Random.Range(0, 20);

        buildings[2] = new FactoryBuilding(40, xRnd, yRnd, "Hero", 'X');
        buildings[2].YPos = yRnd;
        buildings[2].MaxHp = 40;
        int rndSpn = UnityEngine.Random.Range(1, 3);
       // if (rndSpn == 1)
     //   {
      //      fBuildings[0].UnitSpn = "Meele";
     //       fBuildings[0].SpnTic = 5;
     //       fBuildings[0].SpnPtCalc();
    //    }
     //   else
     //   {
     //       fBuildings[0].UnitSpn = "Range";
     //       fBuildings[0].SpnTic = 5;
     //       fBuildings[0].SpnPtCalc();
     //   }

        xRnd = UnityEngine.Random.Range(0, 20);

        yRnd = UnityEngine.Random.Range(0, 20);

        buildings[3] = new FactoryBuilding(40, xRnd, yRnd, "Enemy", 'B');
        buildings[3].YPos = yRnd;
        buildings[3].MaxHp = 40;
        rndSpn = UnityEngine.Random.Range(1, 3);
     //   if (rndSpn == 1)
     //   {
     //       fBuildings[1].UnitSpn = "Meele";
     //       fBuildings[1].SpnTic = 5;
    //        fBuildings[1].SpnPtCalc();
     //   }
     //   else
     //   {
     //       fBuildings[1].UnitSpn = "Range";
      //      fBuildings[1].SpnTic = 5;
      //      fBuildings[1].SpnPtCalc();
      //  }

    }
    void ReDraw()
    {
        GameObject[] delete = GameObject.FindGameObjectsWithTag("ReDraw");

        foreach (GameObject temp in delete)
        {
            Destroy(temp.gameObject);
        }
        for (int i = 0; i < units.Length;i++)
        {
            if (units[i].Hp>0)
            {
                DrawUnits(units[i]);
            }
        }
        for (int i = 0; i < buildings.Length; i++)
        {
            if (buildings[i].Hp > 0)
            {
                DrawBuilding(buildings[i]);
            }
        }
        
    }

    void PlayeGame()
    {
        for (int i = 0; i < units.Length; i++)
        {

            if (units[i] != null || units[i].isDead() != true)//check if units are dead or null
            {
                int target = units[i].CheckClosest(units);//recive int(index) of closest unit
                if (units[i].Hp < (units[i].MaxHp * 0.25) && seconds % (units[i].Spd) == 0)//check if should run and if can move due to speed
                {

                    string direction = units[i].MoveUnit(units[target]);
                    units[i].XYChange(direction);


                }

                else if (units[i].RngCheck(units[target].XPos, units[target].YPos) == true)
                {
                    units[target].Hp = units[i].CombatDmg(units[i].Atk, units[target].Hp);

                }
                else if (seconds% (units[i].Spd) == 0)
                {

                    string direction = units[i].MoveUnit(units[target]);
                    units[i].XYChange(direction);
                }

            }

        }

    }
    void DrawBuilding(Building unit)
    {
        if (unit.Symbol == 'Y')
        {
            Instantiate(Resources.Load("BuildingResource"), new Vector3((float)unit.XPos * offset, (float)unit.YPos * offset, 0), Quaternion.identity);
            Instantiate(Resources.Load(getHpName(unit.Hp, unit.MaxHp)), new Vector3((float)unit.XPos * offset, (float)unit.YPos * offset, -1), Quaternion.identity);
        }

        if (unit.Symbol == 'A')
        {
            Instantiate(Resources.Load("EnemyBuildingResource"), new Vector3((float)unit.XPos * offset, (float)unit.YPos * offset, 0), Quaternion.identity);
            Instantiate(Resources.Load(getHpName(unit.Hp, unit.MaxHp)), new Vector3((float)unit.XPos * offset, (float)unit.YPos * offset, -1), Quaternion.identity);
        }

        if (unit.Symbol == 'X')
        {
            Instantiate(Resources.Load("BuildingSpawn"), new Vector3((float)unit.XPos * offset, (float)unit.YPos * offset, 0), Quaternion.identity);
            Instantiate(Resources.Load(getHpName(unit.Hp, unit.MaxHp)), new Vector3((float)unit.XPos * offset, (float)unit.YPos * offset, -1), Quaternion.identity);
        }

        if (unit.Symbol == 'B')
        {
            Instantiate(Resources.Load("EnemyBuildingSpawn"), new Vector3((float)unit.XPos * offset, (float)unit.YPos * offset, 0), Quaternion.identity);
            Instantiate(Resources.Load(getHpName(unit.Hp, unit.MaxHp)), new Vector3((float)unit.XPos * offset, (float)unit.YPos * offset, -1), Quaternion.identity);
        }
    }
    void DrawUnits(Unit unit)
    {
        if (unit.Symbol == 'M')
        {
            Instantiate(Resources.Load("Knight"), new Vector3((float)unit.XPos * offset, (float)unit.YPos * offset, 0), Quaternion.identity);
            Instantiate(Resources.Load(getHpName(unit.Hp, unit.MaxHp)), new Vector3((float)unit.XPos * offset, (float)unit.YPos * offset, -1), Quaternion.identity);
        }

        if (unit.Symbol=='R')
        {
            Instantiate(Resources.Load("RangeKnight"), new Vector3((float)unit.XPos * offset, (float)unit.YPos * offset, 0), Quaternion.identity);
            Instantiate(Resources.Load(getHpName(unit.Hp, unit.MaxHp)), new Vector3((float)unit.XPos * offset, (float)unit.YPos * offset, -1), Quaternion.identity);
        }

        if (unit.Symbol == 'W')
        {
            Instantiate(Resources.Load("EnemyKnight"), new Vector3((float)unit.XPos * offset, (float)unit.YPos * offset, 0), Quaternion.identity);
            Instantiate(Resources.Load(getHpName(unit.Hp, unit.MaxHp)), new Vector3((float)unit.XPos * offset, (float)unit.YPos * offset, -1), Quaternion.identity);
        }

        if (unit.Symbol == 'T')
        {
            Instantiate(Resources.Load("EnemyRangeKnight"), new Vector3((float)unit.XPos * offset, (float)unit.YPos * offset, 0), Quaternion.identity);
            Instantiate(Resources.Load(getHpName(unit.Hp, unit.MaxHp)), new Vector3((float)unit.XPos * offset, (float)unit.YPos * offset, -1), Quaternion.identity);
        }
    }

    string getHpName(int hp, int MaxHp)
    {
        string hpName = "hp";
        double percentHp = ((double)hp / (double)MaxHp) * 20;
        int roundUp = Mathf.CeilToInt((float)percentHp);
        hpName = "HpBar " + roundUp;

        return hpName;
    }
}
