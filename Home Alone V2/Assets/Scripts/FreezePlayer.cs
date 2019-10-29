using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezePlayer : MonoBehaviour
{
    public float timeLeft = 3;//freeze for 3 second
    public float timer;
    public bool freeze = false;
    public bool gameover = false;
    public PlayerMovement moveScript;
    public GameObject bubble;
    void Start()
    {
        timer = timeLeft;
        bubble.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
       
        if (freeze == true && gameover == false)
        {
            timer -= Time.deltaTime;
            moveScript.canMove = false;

            //stop animations -> front idle
            moveScript.animator.SetFloat("Horizontal", 0);
            moveScript.animator.SetFloat("Vertical", 0);
            moveScript.animator.SetFloat("speed", 0);

            //show up, think bubble!
            bubble.SetActive(true);

            if (timer < 0)
            {
                // Can move again
                moveScript.canMove = true;
                timer = timeLeft;
                freeze = false;
                bubble.SetActive(false);
            }
        }

        if (freeze == true && gameover == true)
        {
            moveScript.canMove = false; //game over - movement halted indefinitely.
        }
        
    }
}