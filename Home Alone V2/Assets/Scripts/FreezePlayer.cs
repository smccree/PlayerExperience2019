using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezePlayer : MonoBehaviour
{
    public float timeLeft = 2;
    public float timer;
    public bool freeze = false;
    public PlayerMovement moveScript;
    void Start()
    {
        timer = timeLeft;
    }
    // Update is called once per frame
    void Update()
    {
       
        if (freeze == true)
        {
            timer -= Time.deltaTime;
            moveScript.canMove = false;
            if (timer < 0)
            {
                // Can move again
                moveScript.canMove = true;
                timer = timeLeft;
                freeze = false;
            }
        }
        // Else do nothing.
    }
}