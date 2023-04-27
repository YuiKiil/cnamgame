using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<ItemsData> inv = new List<ItemsData>(49);

    [SerializeField] private GameObject InventoryUi;
    [SerializeField] private Transform invSlotParents;

    private const int INVSIZE = 49;

    [Header("Action Panel References")]

    // Panel
    [SerializeField] private GameObject actionPanel;

    //Button of panel
    [SerializeField] private GameObject UseItem;
    [SerializeField] private GameObject EquipItem;
    [SerializeField] private GameObject DropItem;
    [SerializeField] private GameObject DestroyItem;
    [SerializeField] private Sprite TransparantSlotTexture;
    [SerializeField] private Transform dropPoint;

    private ItemsData currentItemSelected;

    public static Inventory instance;

    void Awake()
    {
        instance = this;
    }

    // Ajoute des items par defaut si il y en a 
    private void Start()
    {
        RefreshInv();
        InventoryUi.SetActive(false);
    }


    
    private void Update()
    {
        // Partie pour ouvrir ou fermer inventaire (InventoryUi.activeSelf recuperant sont état actuelle et on l'inverse - les 2 en même temps)
        if (Input.GetKeyDown(KeyCode.I))
        {
            InventoryUi.SetActive(!InventoryUi.activeSelf);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (InventoryUi.activeSelf == true)
            {
                InventoryUi.SetActive(false);
            }
        }

        if(actionPanel.activeSelf == true) 
        { 
            if(InventoryUi.activeSelf == false) 
            {
                actionPanel.SetActive(false);
            }
        }
    }

    // Methode d'ajout d'item dans l'inv
    public void AddItem(ItemsData item)
    {
        inv.Add(item);
        RefreshInv();
    }

    // Methode pour fermer l'inv
    public void CloseInv()
    {
        InventoryUi.SetActive(false);
    }

    // Methode pour mettre a jour l'inv
    private void RefreshInv()
    {
        // on clear tous les visuel de l'inv
        for (int i =  0; i < invSlotParents.childCount; i++)
        {
            Slots currentSlot = invSlotParents.GetChild(i).GetComponent<Slots>();
            currentSlot.item = null;
            currentSlot.icon.sprite = TransparantSlotTexture;
        }

        // On remplit le visuel selon la list
        for (int i = 0; i < inv.Count; i++)
        {
            Slots currentSlot = invSlotParents.GetChild(i).GetComponent<Slots>();
            currentSlot.item = inv[i];
            currentSlot.icon.sprite = inv[i].icon;
            
        }
    }

    // Methode pour voir si l'inv est full
    public bool IsFull()
    {
        return INVSIZE == inv.Count;
    }
    
    public void OpenActionPanel(ItemsData itemsData)
    {

        currentItemSelected = itemsData;
        if (itemsData == null) 
        {
            actionPanel.SetActive(false);
            return; 
        }

        switch (itemsData.type) 
        {
            // "Desactive les button" les rends plus sombre si sont pas utile au type d'item
            case ItemsType.Ressource:
                UseItem.GetComponent<Image>().color = new Color32(78, 78, 78, 127); // or setActive
                EquipItem.GetComponent<Image>().color = new Color32(78, 78, 78, 127);
                break;
            case ItemsType.Equipment:
                UseItem.GetComponent<Image>().color = new Color32(78, 78, 78, 127); // or setActive
                EquipItem.GetComponent<Image>().color = new Color32(255, 255, 255, 127);
                break;
            case ItemsType.Consumable:
                UseItem.GetComponent<Image>().color = new Color32(255, 255, 255, 127); // or setActive
                EquipItem.GetComponent<Image>().color = new Color32(78, 78, 78, 127);
                break;
        }

        actionPanel.SetActive(true);
    }

    // Methode qui ferme le panel d'action
    public void CloseActionPanel()
    {
        actionPanel.SetActive(false);
        currentItemSelected = null;
        RefreshInv();
    }

    // Methode des bouttons
    public void UseActionButton()
    {
        CloseActionPanel();
    }

    public void EquipActionButton()
    {
        CloseActionPanel();
    }

    public void DropActionButton()
    {
        GameObject instantiatedItem = Instantiate(currentItemSelected.prefab);
        instantiatedItem.transform.position = dropPoint.position;
        inv.Remove(currentItemSelected);
        CloseInv();
        CloseActionPanel();
    }

    public void DestroyActionButton()
    {
        inv.Remove(currentItemSelected);
        CloseActionPanel();
    }

}
