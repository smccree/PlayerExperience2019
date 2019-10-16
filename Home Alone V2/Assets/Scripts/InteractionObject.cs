using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    public bool talks; //temporary to set up logic (if true object can talk to player)
    public string message; //what object says to player
    public HealthBarScript survBar;
    public HealthBarScript entBar;
    public GameObject label;
    public PlayerMovement moveScript; //for affecting player speed

    public void Start()
    {
        //labels initialized invisible on startup
        label.SetActive(false);
    }

    public void DoInteraction()
    {
        //Pick up and remove from screen
        //gameObject.SetActive(false); //turn invisible but not destroyed - delete this (except for catch rats) (iteration 1)

        //Different settings for each object

        //Cat Food
        if (name == "CatFood")
        {
            survBar.value += 20f;
            entBar.value -= 10f;
            //slow cat
            moveScript.speed = 4f;
        }
        
        //Water Bowl
        if (name == "WaterBowl")
        {
            survBar.value += 15f;
            entBar.value -= 5f;
            //default speed
            moveScript.speed = 5f;
        }
        //Litter Box
        if (name == "LitterBox")
        {
            survBar.value += 10f;
            entBar.value -= 2f;
            //default speed
            moveScript.speed = 5f;
        }
        //Sun Beam
        if (name == "SunBeam")
        {
            survBar.value -= 10f;
            entBar.value += 20f;
            //default speed
            moveScript.speed = 4f;
        }
        //Cat Toy
        if (name == "CatToy")
        {
            survBar.value -= 2f;
            entBar.value += 10f;
            //default speed
            moveScript.speed = 5f;
        }
        //Scratch Post
        if (name == "ScratchPost")
        {
            survBar.value -= 5f;
            entBar.value += 15f;
            //default speed
            moveScript.speed = 5f;
        }
    }

    public void Talk()
    {
        Debug.Log(message); //temporary - add UI later.
    }

}
