using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slots : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public ItemsData item;
    public Image icon;

    // Methode appeler quand on click sur un slot
    public void ClickOnSlot()
    {
        Inventory.instance.OpenActionPanel(item);
    }

    // Methode pour faire apparaitre la tooltip quand la souris touche un slot non vide
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item != null) 
        { 
            ToolTipSystem.instance.Show(item.description, item.name); 
        }
        
    }

    // Methode pour faire disparraitre la tooltip 
    public void OnPointerExit(PointerEventData eventData)
    {
        ToolTipSystem.instance.Hide();
    }


    
}
