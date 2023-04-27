using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour
{
    [SerializeField] private Text title;
    [SerializeField] private Text desc;

    [SerializeField] private LayoutElement layoutElement;
    [SerializeField] private int maxCharacter;
    [SerializeField] private RectTransform rectTransform;

    [SerializeField] private GameObject inv;
    [SerializeField] private GameObject tooltip;

    
    // Methode qui def le text du tooltips
    public void setText(string content, string header = "")
    {
        if (header == "")
        {
            title.gameObject.SetActive(false);
        }
        else
        {
            title.gameObject.SetActive(true);
            title.text = header;
        }

        desc.text = content;
        
        int titleLength = title.text.Length;
        int descLength = desc.text.Length;

        // Programmation par compréhension (condision et se qu'il y a a faire ne une ligne)
        // Permet d'activer le layoutElement (limitation de la taille de la tooltip) quand besoin est
        layoutElement.enabled = (titleLength > maxCharacter || descLength > maxCharacter) ? true : false;
    }


    // Fait bouger les tooltip avec la souris
    private void Update()
    {
        
        // règle le problem du tooltip qui resté afficher si on hover un item puis close l'inv
        if(inv.activeSelf == false)
        {
            if(tooltip.activeSelf == true)
            {
                tooltip.SetActive(false);
                return;
            }
        }

        // tooltiptracker
        Vector2 mousePos = Input.mousePosition;
        transform.position = mousePos;
    }
}
