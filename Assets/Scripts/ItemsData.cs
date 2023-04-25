using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "Items/NewItems")]
public class ItemsData : ScriptableObject
{
    public string name;
    public Sprite icon;
    public GameObject prefab;
}
