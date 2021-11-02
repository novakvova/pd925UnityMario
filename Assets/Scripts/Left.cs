using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Left : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        PlayerMovement.GlobalEvent = -1;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        PlayerMovement.GlobalEvent = 0;
    }
}
