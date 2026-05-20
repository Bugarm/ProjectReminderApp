using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleFunc : MonoBehaviour
{
    public Toggle toggle;
    private GameObject item = null;

    // Start is called before the first frame update
    void Start()
    {
        if (toggle != null)
        {
            toggle.onValueChanged.AddListener(ToggleDropdown);
        }

    }

    public void ToggleDropdown(bool isOn)
    {
        if(item == null)
        {
            item = GameObject.Find("item");
        }

       item.SetActive(isOn);
    }
}
