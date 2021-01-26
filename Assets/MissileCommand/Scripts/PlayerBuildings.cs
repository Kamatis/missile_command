using System.Collections.Generic;
using UnityEngine;

public class PlayerBuildings : MonoBehaviour
{
    public List<Building> buildings;


    public static Building GetRandomBuilding()
    {
        int buildingIndex = Random.Range(0, Instance.buildings.Count);
        int traverseCount = 0;
        while(!Instance.buildings[buildingIndex].IsAlive())
        {
            buildingIndex = (buildingIndex + 1) % Instance.buildings.Count;
            traverseCount++;
            if(traverseCount >= Instance.buildings.Count)
            {
                return null;
            }
        }
        return Instance.buildings[buildingIndex];
    }

    public static PlayerBuildings Instance;
    private void Awake()
    {
        Instance = this;
    }
}
