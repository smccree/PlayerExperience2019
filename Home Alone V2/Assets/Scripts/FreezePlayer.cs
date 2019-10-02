﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezePlayer : MonoBehaviour
{
    public float timeLeft = 1;//freeze for 1 second
    public float timer;
    public bool freeze = false;
    public bool gameover = false;
    public PlayerMovement moveScript;
    void Start()
    {
        timer = timeLeft;
    }
    // Update is called once per frame
    void Update()
    {
       
        if (freeze == true && gameover == false)
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

        if (freeze == true && gameover == true)
        {
            moveScript.canMove = false; //game over - movement halted indefinitely.
        }
        
    }
}