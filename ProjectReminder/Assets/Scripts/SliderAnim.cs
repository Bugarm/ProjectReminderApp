using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SliderAnim : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public static event Action SliderMoved;
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 position = transform.localPosition;
        transform.localPosition = new Vector3(Mathf.Clamp(position.x+eventData.delta.x, -435, 435), position.y, position.z);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Handle end of drag if needed
        Vector3 position = transform.localPosition;
        if(position.x < 435 && position.x > -435)
        {
            // Handle the case when the slider is out of bounds
            transform.localPosition = new Vector3(-435, position.y, position.z);
            return;
        }
        SliderMoved?.Invoke();
    }
}
