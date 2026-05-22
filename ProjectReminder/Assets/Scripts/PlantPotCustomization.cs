using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantPotCustomization : MonoBehaviour
{
    [SerializeField] Transform[] costumeSlots; 

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform slot in costumeSlots)
        {
            Image image = slot.GetComponent<Image>();
            if (image != null)
            {
                image.sprite = null; // Clear the sprite to make it invisible
                image.gameObject.SetActive(false); // Deactivate the GameObject to hide it
            }
            else
            {
                Debug.LogError("No Image component found on slot: " + slot.name);
            }
        }
    }

    public void ButtonPressed(GameObject obj)
    {
        // Implement button press functionality here

        Image image = obj.GetComponent<Image>();
        string tag = obj.tag;
        Transform slot = SlotDecider(tag);
        if (slot != null)
        {
            Image slotImage = slot.GetComponent<Image>();
            if (slotImage != null)
            {
                if(slotImage.sprite != null && slotImage.sprite.name == image.sprite.name)
                {
                    slotImage.sprite = null; // Clear the sprite to make it invisible
                    slotImage.gameObject.SetActive(false); // Deactivate the GameObject to hide it
                    return;
                }

                slotImage.gameObject.SetActive(true); // Activate the GameObject to show the sprite
                slotImage.sprite = image.sprite;
            }
            else
            {
                Debug.LogError("No Image component found on slot: " + slot.name);
            }
        }
    }
    private Transform SlotDecider(string tag)
    {
        if(tag == "Head")
        {
            return costumeSlots[0];
        }
        else if(tag == "Body")
        {
            return costumeSlots[1];
        }
        else if (tag == "Eye")
        {
            return costumeSlots[3];
        }
        else if (tag == "Grab")
        {
            return costumeSlots[2];
        }
        else if(tag == "Face")
        {
            return costumeSlots[4];
        }
        else
        {
            Debug.LogError("Invalid tag: " + tag);
            return null;
        }
    }

}
