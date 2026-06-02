using UnityEngine;
using UnityEngine.UI;

public class ToggleFunc : MonoBehaviour
{
    public Toggle toggle;
    private GameObject item;
    private const string ItemNameToFind = "Item";

    // Start is called before the first frame update
    private void Start()
    {
        ToggleDropdown(toggle.isOn); // Set initial state based on toggle

        if (toggle != null)
        {
            toggle.onValueChanged.AddListener(ToggleDropdown);
        }
    }

    private void ToggleDropdown(bool isOn)
    {
        if(item == null)
        {
            item = GameObject.Find(ItemNameToFind);
        }

        item.SetActive(isOn);
    }
}
