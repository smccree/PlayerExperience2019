using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int timeLeft = 9;   //modified countdown timer to count up - 9 to 17  (military time; 9am to 5pm)
    public Text countdownText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("LoseTime");
    }

    // Update is called once per frame
    void Update()
    {
        countdownText.text = ("Current time: " + timeLeft + ":00");
        if(timeLeft >= 17)
        {
            StopCoroutine("LoseTime");
            countdownText.text = "Time's up!";
        }
    }
    IEnumerator LoseTime()
    {
        while(true)
        {
            yield return new WaitForSeconds(10); //60 seconds before changing the hour
            timeLeft++;
        }
    }
}
