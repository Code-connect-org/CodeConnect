using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaData
{
    public int id;
    public string name;
    public int lv;
    public int[] enemy;
    public string description;
}

public class InitialAreaData : MonoBehaviour
{
    void start(){
        Areas = new AreaData[]
        {
            new AreaData{
                id = 0,
                name = "Unknown",
                lv = 0,
                enemy = new int[] { 0 },
                description = "Unknown"
            },
            new AreaData{
                id = 1,
                name = "forest",
                lv = 1,
                enemy = new int[] { 1 },
                description = "Feels so good. BreeeeeEEEEEZE."
            },
            new AreaData{
                id = 2,
                name = "cave",
                lv = 3,
                enemy = new int[] { 1 },
                description = "Aren't you Scared? ...Boo! Huh, it looks bad..."
            }
        };
    }
}