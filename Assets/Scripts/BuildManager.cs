using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    void Awake()
    {
        instance = this;
    }
    public GameObject turretPrefab;
    void Start()
    {
        turretSelected = turretPrefab;
    }
    private GameObject turretSelected;

    public GameObject GetTurretToBuild()
    {
        return turretSelected;
    } 
}
