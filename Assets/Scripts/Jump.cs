using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Jump : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        PlayerMovement.GlobalEventJump = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        PlayerMovement.GlobalEventJump = false;
    }
}
