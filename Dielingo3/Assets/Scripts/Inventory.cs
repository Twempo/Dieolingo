using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    List<Item> inv = new List<Item>();

    public void addItem(Item item)
    {
        inv.Add(item);
        Debug.Log(inv.Count);
    }
}
