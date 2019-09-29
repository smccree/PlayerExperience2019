using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Class controls the pet's health bar
public class SimulationController : MonoBehaviour
{
    [SerializeField]
    private int s; //how happy is our pet? bar goes 0 - 100 where 0 is very stressed and 100 is very happy
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateStatus();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateStatus()
    {
        //set value for happiness meter
        if(!PlayerPrefs.HasKey("happiness"))
        {
            happiness = 100;
            PlayerPrefs.SetInt("happiness", happiness);
        }
        else
        {
            happiness = PlayerPrefs.GetInt("happiness");
        }

         
    }

    public int happiness
    {
        get { return happiness; }
        set { happiness = value; }
    }
}
