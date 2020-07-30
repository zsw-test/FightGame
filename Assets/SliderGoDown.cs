using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderGoDown : MonoBehaviour
{
    public Slider slider;
    private float Slidershadowspeed = 0.8f;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Slider>().value = slider.value;
    }

    // Update is called once per frame
    void Update()
    {
        var distance = gameObject.GetComponent<Slider>().value - slider.value;
        if(distance<0)
        {
            gameObject.GetComponent<Slider>().value = slider.value;
        }
        else
        {
            gameObject.GetComponent<Slider>().value -= Time.deltaTime * Slidershadowspeed*distance;
        }
      
    }
}
