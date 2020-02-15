using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    private TurretBlueprint turretToBuild;

    public GameObject BuildEffect;

    public GameObject standardTurretPrefab;
    public GameObject SniperTurretPrefab;
    public GameObject MissileTurretPrefab;



    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("more than one build manager");
            return;
        }
        instance = this;
        
    }

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not Enough Money!");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        GameObject Effect = (GameObject)Instantiate(BuildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(Effect, 5f);

        Debug.Log("Turret build! Money left: " + PlayerStats.Money);
    }

    public void SelectTurretToBuild (TurretBlueprint turret)
    {
        turretToBuild = turret; 
    }

}
