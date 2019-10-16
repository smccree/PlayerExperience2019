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
    public HealthBarScript survBar;
    public HealthBarScript entBar;
    public bool over = false; //initialize game over is false
    public bool stopclock; //for stopping the clock later

    //initialize images to be inactive
    void Start()
    {
        endOfDay.SetActive(false);
        gameOver.SetActive(false);
    }

    //is it game over yet?
    void Update()
    {
        if(over == true)
        {
            EndGame();
        }
    }
    void EndGame()
    {
        //first freeze the player and stop the clock
        freezeScript.freeze = true;
        freezeScript.gameover = true;
        //clock.timeLeft = 17; // day naturally ends at 17
        stopclock = true;
        //the Game has finished for one of two reasons:

        //Reason One: No more time
        if (survBar.value >= 0 && entBar.value >= 0)
        {
            Debug.Log("Out of Time!");
            endOfDay.SetActive(true);
        }

        //Reason Two: Survival or Entertainment Bar reached 0
        if (survBar.value <=0 || entBar.value <= 0)
        {
            Debug.Log("Bar empty!");
            gameOver.SetActive(true);
        }
    }
}
