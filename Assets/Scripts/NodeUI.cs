using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject UI;
    public TextMeshProUGUI upgradeCost;
    public Button upgradeButton;
    private Node selected;


    public void SetSelected(Node _selected)
    {
        selected = _selected;
        transform.position = selected.GetBuildPosition();
        if(!selected.isUpgraded)
        {
            upgradeCost.text = $"${selected.turretBlueprint.upgradeCost}";
            upgradeButton.interactable = true;
        }else{
            upgradeCost.text = $"COMPLETE";
            upgradeButton.interactable = false;
        }
        UI.SetActive(true);
    }

    public void Hide()
    {
        UI.SetActive(false);
    }

    public void Upgrade()
    {
        selected.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        selected.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
