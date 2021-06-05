using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class FloatingJoystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] JoyStickDirection JoystickDirection = JoyStickDirection.Both;
    [SerializeField] RectTransform Background;
    [SerializeField] RectTransform Handle;
    [SerializeField] Vector2SO movementSO;
    [Range(0, 2f)] public float HandleLimit = 1f;
    Vector2 JoyPosition = Vector2.zero;
    public void OnPointerDown(PointerEventData eventdata)
    {
        Background.gameObject.SetActive(true);
        OnDrag(eventdata);
        JoyPosition = eventdata.position;
        Background.position = eventdata.position;
        Handle.anchoredPosition = Vector2.zero;
    }
    public void OnDrag(PointerEventData eventdata)
    {
        Vector2 JoyDriection = eventdata.position - JoyPosition;
        movementSO.value = (JoyDriection.magnitude > Background.sizeDelta.x / 2f) ? JoyDriection.normalized :
            JoyDriection / (Background.sizeDelta.x / 2f);
        if (JoystickDirection == JoyStickDirection.Horizontal)
        movementSO.value= new Vector2(movementSO.value.x, 0f);
        if (JoystickDirection == JoyStickDirection.Vertical)
            movementSO.value = new Vector2(0f,movementSO.value.y);
        Handle.anchoredPosition = (movementSO.value * Background.sizeDelta.x / 2f) * HandleLimit;
    }
    public void OnPointerUp(PointerEventData eventdata)
    {
        Background.gameObject.SetActive(false);
        movementSO.value = Vector2.zero;
        Handle.anchoredPosition = Vector2.zero;
    }
}

