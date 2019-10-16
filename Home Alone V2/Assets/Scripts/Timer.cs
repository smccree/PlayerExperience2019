using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int timeLeft;   //modified countdown timer to count up - 9 to 17  (military time; 9am to 5pm)
    public Text countdownText;
    public HealthBarScript entBar; //import the entertainment and survival bars so we can decrease them over time
    public HealthBarScript survBar;
    public GameOver end;
    public PlayerMovement moveScript;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("LoseTime");
        StartCoroutine("DecreaseBar");
        timeLeft = 9;
    }

    // Update is called once per frame
    void Update()
    {
        countdownText.text = ("Current time: " + timeLeft + ":00");
        if(timeLeft >= 17)
        {
            //you win
            StopCoroutine("LoseTime");
            StopCoroutine("DecreaseBar");
            
            end.over = true; //day ended!
            countdownText.text = "End of the Day!";
        }
        if (survBar.value <= 0 || entBar.value <= 0)
        {
            //game over
            StopCoroutine("LoseTime");
            StopCoroutine("DecreaseBar");

            end.over = true; //day ended!
            countdownText.text = ("End time: " + timeLeft + ":00");
        }

    }
    IEnumerator LoseTime()
    {
        while(true)
        {
            yield return new WaitForSeconds(20); //10 seconds before changing the hour for now
            timeLeft++;
        }
    }

    //make survival and entertainment bars decrease by 1 point per second
    IEnumerator DecreaseBar()
    {
        while (true)
        {
            yield return new WaitForSeconds(1); //2 points per second for now
            survBar.value -= 2f;
            entBar.value -= 2f;

            //slow the player's speed if the health bars get too low, increase speed if both bars are high
            if (survBar.value <= 30f || entBar.value <= 30f)
            {
                moveScript.speed = 2f;
            }

            if (survBar.value >= 70f && entBar.value >= 70f)
            {
                moveScript.speed = 10f;
            }

        }
    }
}
