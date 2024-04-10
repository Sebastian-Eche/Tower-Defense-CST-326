using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public GameObject buildEffect;
    public GameObject sellEffect;
    public static BuildManager instance;
    void Awake()
    {
        instance = this;
    }
    private TurretBlueprint turretSelected;
    private Node nodeSelected;
    public NodeUI nodeUI;

    public bool CanBuild {get {return turretSelected != null;}}

    public bool HasMoney {get {return PlayerStats.Money >= turretSelected.cost;}}

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretSelected = turret;
        DeselectNode();
    }

    public void SelectNode(Node node)
    {
        if(node.Equals(nodeSelected))
        {
            DeselectNode();
            return;
        }
        nodeSelected = node;

        turretSelected = null;
        nodeUI.SetSelected(node);
    }
    public void DeselectNode()
    {
        nodeSelected = null;
        nodeUI.Hide();
    }

    public TurretBlueprint GetTurretBlueprint(){
        return turretSelected;
    }
}
