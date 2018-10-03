using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{

    private ItemUIController UI;
    private Adventurer Player;

    public Weapon weapon;
    public Armor armor;

    public void Start()
    {
        UI = GameObject.FindGameObjectWithTag("UIController").GetComponent<ItemUIController>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Adventurer>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player = other.gameObject.GetComponent<Adventurer>();
            Player.GetComponent<Movement>().enabled = false;

            UI.ItemUI.enabled = true;

            if (weapon != null)
            {
                UI.ItemNameLabel.text = weapon.name;
                UI.ItemDescLabel.text = weapon.description;
                UI.EquipButton.onClick.AddListener(EquipItem);
                UI.DiscardButton.onClick.AddListener(DiscardItem);
            }
            else if (armor != null)
            {
                UI.ItemNameLabel.text = armor.name;
                UI.ItemDescLabel.text = armor.description;
                UI.EquipButton.onClick.AddListener(EquipItem);
                UI.DiscardButton.onClick.AddListener(DiscardItem);
            }
        }
    }

    public void EquipItem()
    {
        if (weapon != null)
            Player.weapon = weapon;
        else if (armor != null)
            Player.armor = armor;


        Player.ResetHealth();
        Player.GetComponent<Movement>().enabled = true;
        UI.ItemUI.enabled = false;
        Destroy(gameObject);
    }

    public void DiscardItem()
    {
        // Break down for gold?

        Player.GetComponent<Movement>().enabled = true;
        UI.ItemUI.enabled = false;
        Destroy(gameObject);
    }

}
