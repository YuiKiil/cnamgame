using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehaviour : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private MoveBehaviour moveBehaviour;
    
    [SerializeField] private Inventory inv;

    private Item currentItem;
    
    // ajoute l'objet a l'inv du joueur
    // Bloque le joueur
    // Joue l'animation
    public void DoPickUp(Item item)
    {
        if (inv.IsFull())
        {
            Debug.Log("Inventory Full, can't pick up: " + item.name);
            return;
        }
        
        currentItem = item;
        animator.SetTrigger("Pickup");
        moveBehaviour.canMove = false;
        
    }

    // Methode pour ajoute un item a l'inv
    public void AddItemToInv()
    {
        inv.AddItem(currentItem.itemData);
        Destroy(currentItem.gameObject);
        currentItem = null;
    }

    // Methode qui redonne la possibilité au joueur de bouger (utiliser a la fin de l'animation)
    public void ReEnablePlayerMove()
    {
        moveBehaviour.canMove = true;
    }
}
