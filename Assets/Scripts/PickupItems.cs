using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItems : MonoBehaviour
{
    [SerializeField] 
    private float pickupRange = 2.6f;

    public Inventory Inventory ;

    private List<ItemsData> inv;

    void Update()
    {
        RaycastHit hit;
        inv = Inventory.inv;
        

        if (Physics.Raycast(transform.position, transform.forward, out hit, pickupRange))
        {
            if (hit.transform.CompareTag("Item"))
            {
                Debug.Log("ther is an item");

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Destroy(hit.transform.gameObject);
                    Debug.Log("item recip");
                    Inventory.AddItem(hit.transform.gameObject.GetComponent<Item>().item);
                    
                }
            }
        }
    }
}
