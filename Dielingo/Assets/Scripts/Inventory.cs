using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    List<Interactable> inv = new List<Interactable>();

    public void addItem(Interactable obj)
    {
        inv.Add(obj);
        Debug.Log(inv.Count);
    }
}
