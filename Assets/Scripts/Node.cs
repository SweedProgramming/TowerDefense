using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

    public Color hoverColor;
    public Color notEnoughMoneyColor;

    [Header("Optional")]
    public GameObject turret;

    public Vector3 positionOffset;

    BuildManager buildManager;

    private Renderer rend;
    private Color startColor;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject() == null)
            return;

        if (!buildManager.CanBuild)
        {
            return;
        }

        if (turret != null)
        {
            Debug.Log("CantBuildThere");
            return;
        }

        buildManager.BuildTurretOn(this);
        
    }

    void OnMouseEnter()
    {

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;  

        if (buildManager.HasMoney)
        {
            rend.GetComponent<Renderer>().material.color = hoverColor;
        } else
        {
            rend.material.color = notEnoughMoneyColor;
        }

        
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

}
