using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemUIController : MonoBehaviour {

    public Canvas ItemUI;
    public TextMeshProUGUI ItemNameLabel;
    public TextMeshProUGUI ItemDescLabel;
    public Button EquipButton;
    public Button DiscardButton;

    // Use this for initialization
    void Start () {
        ItemUI.enabled = false;
	}
		
}
