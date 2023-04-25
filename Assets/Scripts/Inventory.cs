using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    public List<ItemsData> inv = new List<ItemsData>();
    public void AddItem(ItemsData item)
    {
        inv.Add(item);
    }
}
