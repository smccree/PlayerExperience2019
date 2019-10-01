using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    public bool talks; //temporary to set up logic (if true object can talk to player)
    public string message; //what object says to player
    public HealthBarScript survBar;
    public HealthBarScript entBar;


    public void DoInteraction()
    {
        //Pick up and remove from screen
        //gameObject.SetActive(false); //turn invisible but not destroyed - delete this (except for catch rats) (iteration 1)

        //Different settings for each object

        //Cat Food
        if (name == "CatFood")
        {
            survBar.value += 5f;
            entBar.value -= 5f;
        }
        
        //Water Bowl
        if (name == "WaterBowl")
        {
            survBar.value += 10f;
            entBar.value -= 10f;
        }
        //Litter Box
        if (name == "LitterBox")
        {
            survBar.value += 15f;
            entBar.value -= 15f;
        }
        //Sun Beam
        if (name == "SunBeam")
        {
            survBar.value -= 5f;
            entBar.value += 5f;
        }
        //Cat Toy
        if (name == "CatToy")
        {
            survBar.value -= 10f;
            entBar.value += 10f;
        }
        //Scratch Post
        if (name == "ScratchPost")
        {
            survBar.value -= 15f;
            entBar.value += 15f;
        }
    }

    public void Talk()
    {
        Debug.Log(message); //temporary - add UI later.
    }

}
