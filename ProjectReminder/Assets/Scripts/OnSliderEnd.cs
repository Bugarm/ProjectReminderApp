using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSliderEnd : MonoBehaviour
{
    public GameObject slider;

    public void OnSliderEndEvent()
    {
        SwitchScene("MainApp");
    }

    // Start is called before the first frame update
    void Start()
    {
        SliderAnim.SliderMoved += OnSliderEndEvent;
    }

    public void SwitchScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
