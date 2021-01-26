using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour, IPointerDownHandler
{
    public OnTappedScreen onTappedScreen;

    public void OnPointerDown(PointerEventData eventData)
    {
        onTappedScreen?.Invoke(eventData.position);
    }

    [System.Serializable]
    public class OnTappedScreen : UnityEvent<Vector2> { }
}
