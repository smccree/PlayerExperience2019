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
            StopCoroutine("LoseTime");
            StopCoroutine("DecreaseBar");
            countdownText.text = "End of the Day!";
            end.over = true; //day ended!
        }
        if(survBar.value <= 0 || entBar.value <= 0)
        {
            end.over = true; //game over!
        }
    }
    IEnumerator LoseTime()
    {
        while(true)
        {
            yield return new WaitForSeconds(10); //10 seconds before changing the hour for now
            timeLeft++;
            moveScript.speed = Random.Range(1f, 10f); //generate a random speed
        }
    }

    //make survival and entertainment bars decrease by 1 point per second
    IEnumerator DecreaseBar()
    {
        while (true)
        {
            yield return new WaitForSeconds(1); //1 point per second for now
            survBar.value -= 1f;
            entBar.value -= 1f;
        }
    }
}
