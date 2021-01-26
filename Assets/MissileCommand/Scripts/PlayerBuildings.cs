using System.Collections.Generic;
using UnityEngine;

public class PlayerBuildings : MonoBehaviour
{
    public List<Building> buildings;

    public static Building GetRandomBuilding()
    {
        return Instance.buildings[Random.Range(0, Instance.buildings.Count)];
    }

    public static PlayerBuildings Instance;
    private void Awake()
    {
        Instance = this;
    }
}
