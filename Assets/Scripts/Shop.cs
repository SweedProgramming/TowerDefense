
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint sniperTurret;
    public TurretBlueprint missileLauncher;
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandartTurret()
    {
        Debug.Log("Purchased PistolTurret");
        buildManager.SelectTurretToBuild(standardTurret);
    }
    public void SelectSniperTurret()
    {
        Debug.Log("Purchased SniperTurret");
        buildManager.SelectTurretToBuild(sniperTurret);
    }
    public void SelectMissileTurret()
    {
        Debug.Log("Purchased MissileTurret");
        buildManager.SelectTurretToBuild(missileLauncher);
    }
}
