using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSliderEnd : MonoBehaviour
{
    public GameObject slider;

    public void OnSliderEndEvent()
    {
        print("Slider Ended");
    }

    // Start is called before the first frame update
    void Start()
    {
        SliderAnim.SliderMoved += OnSliderEndEvent;
    }

}
