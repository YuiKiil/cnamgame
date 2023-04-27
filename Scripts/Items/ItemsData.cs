using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "Items/NewItems")]
public class ItemsData : ScriptableObject
{
    public string name;
    public string description;
    public Sprite icon;
    public GameObject prefab;

    public ItemsType type;
}

public enum ItemsType
{
    Ressource,
    Equipment,
    Consumable
}
