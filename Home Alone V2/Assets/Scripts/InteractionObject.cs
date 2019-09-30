using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    public bool talks; //temporary to set up logic (if true object can talk to player)
    public string message; //what object says to player

    public void DoInteraction()
    {
        //Pick up and remove from screen
        gameObject.SetActive(false); //turn invisible but not destroyed
    }

    public void Talk()
    {
        Debug.Log(message); //temporary - add UI later.
    }

}
