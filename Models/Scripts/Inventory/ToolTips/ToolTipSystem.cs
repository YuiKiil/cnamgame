using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ToolTipSystem : MonoBehaviour
{
    public static ToolTipSystem instance;

    [SerializeField] private ToolTip toolTip;
    
    private void Awake()
    {
        instance = this;
    }

    // Methode pour afficher la tooltip
    public void Show(string content, string header = "")
    {
		toolTip.setText(content, header);
        toolTip.gameObject.SetActive(true);
    }

    // Methode pour cacher la tooltip
    public void Hide()
    {
        toolTip.gameObject.SetActive(false);
    }
    
}
