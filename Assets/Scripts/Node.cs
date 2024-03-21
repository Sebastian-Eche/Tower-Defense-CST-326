using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;
    private GameObject turret;
    private Renderer nodeRend;
    private Color startColor;
    // Start is called before the first frame update
    void Start()
    {
        nodeRend = GetComponent<Renderer>();   
        startColor = nodeRend.material.color;
    }

    void OnMouseDown()
    {
        if(turret != null)
        {
            Debug.Log("CANT BUILD");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation, transform);
    }

    void OnMouseEnter()
    {
        nodeRend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        nodeRend.material.color = startColor;
    }
}
