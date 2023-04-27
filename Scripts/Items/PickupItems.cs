using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItems : MonoBehaviour
{
    [SerializeField] 
    private float pickupRange = 2.6f;
    

    public PickupBehaviour playerPickUpBehaviour;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private GameObject pickUpText;

    private void Start()
    {
        
    }

    private void Update()
    {

        //On cree un raycast
        RaycastHit hit;

        // On regarde si le raycast touche un item a moins de pickuprange
        if (Physics.Raycast(transform.position, transform.forward, out hit, pickupRange, layerMask))
        {
            if (hit.transform.CompareTag("Item"))
            {
                
                pickUpText.SetActive(true);

                // On le remasse
                if (Input.GetKeyDown(KeyCode.E))
                {
                    playerPickUpBehaviour.DoPickUp(hit.transform.gameObject.GetComponent<Item>());
                    
                    
                }
            }
        }
        else
        {
            pickUpText.SetActive(false);
        }
    }
}
