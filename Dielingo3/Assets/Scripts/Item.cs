using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class Item : ScriptableObject
{
    public int id;
    public string name;
    public string description;
    public Texture2D inventoryIcon;
}
