using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleFunc : MonoBehaviour
{
    private Toggle toggle;

    // Start is called before the first frame update
    void Start()
    {
        toggle = GetComponent<Toggle>();
        if (toggle != null)
        {
            toggle.onValueChanged.AddListener(ToggleDropdown);
        }

    }

    public void ToggleDropdown(bool isOn)
    {
       GameObject.Find("item").SetActive(isOn);
    }
}
