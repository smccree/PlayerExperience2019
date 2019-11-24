using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Timer clock;
    public FreezePlayer freezeScript;
    public GameObject endOfDay;
    public GameObject gameOver;
    public GameObject returntostart; //go back to main menu button
    public GameObject nextday; //move on to the next day - 5 days total
    public HealthBarScript survBar;
    public HealthBarScript entBar;
    public bool over = false; //initialize game over is false
    public bool stopclock; //for stopping the clock later

    //initialize images + buttons to be inactive
    void Start()
    {
        endOfDay.SetActive(false);
        gameOver.SetActive(false);
        returntostart.SetActive(false);
        nextday.SetActive(false);
    }

    //is it game over yet?
    void Update()
    {
        if(over == true)
        {
            EndGame();
            over = false;
        }
    }
    void EndGame()
    {
        Debug.Log("starting end game");
        //first freeze the player and stop the clock
        freezeScript.freeze = true;
        freezeScript.gameover = true;
        stopclock = true;
        //the Game has finished for one of two reasons:

        //Reason One: No more time
        if (clock.timeLeft >= 17)
        {
            Debug.Log("Out of Time!");
            endOfDay.SetActive(true);
            returntostart.SetActive(true); //option to return to start
            nextday.SetActive(true);  //option to keep playing - next day - for now infinite replay of same scene
        }

        //Reason Two: Survival or Entertainment Bar reached 0
        else
        {
            Debug.Log("Game Over");
            gameOver.SetActive(true);
            returntostart.SetActive(true);
        }
        
    }
}
