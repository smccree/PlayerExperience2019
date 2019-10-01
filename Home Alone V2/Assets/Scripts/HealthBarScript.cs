using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    Image bar;
    float maxValue = 100f;
    public float value;

    // Start is called before the first frame update
    void Start()
    {
        bar = GetComponent<Image>();
        value = 50f;
    }

    // Update is called once per frame
    void Update()
    {
        bar.fillAmount = value / maxValue;
    }
}
