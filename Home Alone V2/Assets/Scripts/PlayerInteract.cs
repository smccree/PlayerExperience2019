using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//main character control class
public class PlayerInteract : MonoBehaviour
{
    public GameObject currentInterobj = null; //object we are currently interacting with
    public GameObject label = null; //label for interactive object
    public InteractionObject currentInterobjScript = null;
    public PlayerMovement moveScript;
    public GameObject Player;

    public FreezePlayer freezeScript;

    void Update()
    {
        //if we are pressing the interact button, have an object target and aren't frozen:
        if(Input.GetButtonDown ("Interact") && currentInterobj && moveScript.canMove)
        {
            //Do something with the object
            //send message to object interacting with
            currentInterobj.SendMessage("DoInteraction");

            currentInterobjScript.DoInteraction();
            freezeScript.freeze = true;

            //check to see if the object has a message and talks
            if (currentInterobjScript.talks)
            {
                currentInterobjScript.Talk();
            }
        }

        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("inter_object"))
        {
            Debug.Log(collision.name);
            currentInterobj = collision.gameObject; //player is in range of interactable object
            currentInterobjScript = currentInterobj.GetComponent<InteractionObject>();

            //make label appear when in radius
            label = currentInterobjScript.label;
            label.SetActive(true);


        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("inter_object"))
        {
            if(collision.gameObject == currentInterobj)
            {
                currentInterobj = null; //player has walked out of range of interactable object
                label.SetActive(false); //label disappears again
                label = null; //no current label
            } 
            
        }
    }


    
        
    
}
