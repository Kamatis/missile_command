using System.Collections.Generic;
using UnityEngine;

public class PlayerBuildings : MonoBehaviour
{
    public List<Building> buildings;


    public static Building GetRandomBuilding()
    {
        int buildingIndex = Random.Range(0, Instance.buildings.Count);
        return Instance.buildings[buildingIndex];
    }

    public void OnBuildingDestroyed(Building building)
    {
        buildings.Remove(building);
        if(buildings.Count <= 0)
        {
            GameController.Instance.GameOver();
        }
    }

    public static PlayerBuildings Instance;
    private void Awake()
    {
        Instance = this;
    }
}
