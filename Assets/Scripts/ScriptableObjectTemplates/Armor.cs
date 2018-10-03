using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Armor", menuName ="Armor")]
public class Armor : ScriptableObject {

    public new string name;
    public string description;
    public int health;
}
