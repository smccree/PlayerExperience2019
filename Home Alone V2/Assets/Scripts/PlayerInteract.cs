using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public GameObject currentInterobj = null; //object we are currently interacting with
    public InteractionObject currentInterobjScript = null;

    void Update()
    {
        if(Input.GetButtonDown ("Interact") && currentInterobj)
        {
            //Do something with the object
            //send message to object interacting with
            currentInterobj.SendMessage("DoInteraction");

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

            //testing
            HealthBarScript.health -= 10f;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("inter_object"))
        {
            if(collision.gameObject == currentInterobj)
            {
                currentInterobj = null; //player has walked out of range of interactable object
            } 
            
        }
    }
}
