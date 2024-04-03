using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
     BuildManager buildManager;
    public Color hoverColor;
    public Color notEnoughtMoneyColor;
    public Vector3 positionOffset;
    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;
    private Renderer nodeRend;
    private Color startColor;

    // Start is called before the first frame update
    void Start()
    {
        buildManager = BuildManager.instance;
        nodeRend = GetComponent<Renderer>();   
        startColor = nodeRend.material.color;
    }

    void OnMouseDown()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if(turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if(!buildManager.CanBuild){
            Debug.Log("CANT BUILD TODO: display to player that cant build");
            return;
        }
        BuildTurret(buildManager.GetTurretBlueprint());

    }

    void BuildTurret(TurretBlueprint blueprint)
    {

        if(PlayerStats.Money < blueprint.cost){
            Debug.Log($"NOT ENOUGH MONEY TO BUILD: {blueprint.ToString()}");
            return;
        }
        PlayerStats.Money -= blueprint.cost;
        GameObject turret = Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        this.turret = turret;
        turretBlueprint = blueprint;
        GameObject effect = Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        Debug.Log("TURRET PURCHASED!!");
    }

    public void UpgradeTurret()
    {
         if(PlayerStats.Money < turretBlueprint.upgradeCost){
            Debug.Log($"NOT ENOUGH MONEY TO UPGRADE: {turretBlueprint.ToString()}");
            return;
        }
        PlayerStats.Money -= turretBlueprint.upgradeCost;
        //removing old turret
        Destroy(this.turret);
        //replacing with upgraded turret 
        GameObject turret = Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        this.turret = turret;
        GameObject effect = Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded = true;
        Debug.Log("TURRET UPGRADED!!");
    }

    void OnMouseEnter()
    {
        if(EventSystem.current.IsPointerOverGameObject()){
            return;
        }
        if(!buildManager.CanBuild){
            return;
        }
        if(buildManager.HasMoney)
        {
            nodeRend.material.color = hoverColor;
        }else{
            nodeRend.material.color = notEnoughtMoneyColor;
        }
    }

    void OnMouseExit()
    {
        nodeRend.material.color = startColor;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
}
