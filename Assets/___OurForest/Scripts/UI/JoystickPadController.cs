using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoystickPadController : MonoBehaviour
{
    [SerializeField] Image outerJoystick;
    [SerializeField] Image joystick;
    [SerializeField] Vector3 position;
    [SerializeField] float range = 50;
    [SerializeField] Vector2SO movement;
    [SerializeField] Vector3SO positionSO;
    Touch _touch;
    Vector3 origninalPosition;
    Vector3 touchPosition;
    Vector3 Touchdisplacment;
    bool is_dragged = false;
    void Start()
    {
        //origninalPosition = positionSO.value;
        origninalPosition = outerJoystick.rectTransform.position;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            movement.value = Vector2.zero;
            _touch = Input.GetTouch(0);
            touchPosition = _touch.position;
            // origninalPosition = positionSO.value;
            origninalPosition = outerJoystick.rectTransform.position;
            touchPosition.z = 0.0f;
            Touchdisplacment = origninalPosition - touchPosition;
            position = joystick.rectTransform.position;
            if (Touchdisplacment.magnitude < range && _touch.phase == TouchPhase.Began /*|| _touch.phase == TouchPhase.Stationary*/)
            {
                is_dragged = true;
            }
            if (_touch.phase == TouchPhase.Moved || _touch.phase == TouchPhase.Stationary)
            {
                if (is_dragged == true && Touchdisplacment.magnitude < range)
                {
                    joystick.rectTransform.position = touchPosition;
                    movement.value = new Vector3(-Mathf.Clamp((Touchdisplacment).x, -1, 1), -Mathf.Clamp((Touchdisplacment).y, -1, 1));
                }
                else if (is_dragged == true && Touchdisplacment.magnitude >= range)
                {
                    joystick.rectTransform.position = Vector3.ClampMagnitude(Vector3.LerpUnclamped(origninalPosition, touchPosition, range), range) + origninalPosition;
                    movement.value = new Vector3(-Mathf.Clamp((Touchdisplacment).x, -1, 1), -Mathf.Clamp((Touchdisplacment).y, -1, 1));
                }
            }
            if (_touch.phase == TouchPhase.Ended)
            {
                EndTouch();
            }
        }
    }

    public void EndTouch()
    {
        is_dragged = false;
        joystick.rectTransform.position = origninalPosition;
        movement.value = Vector2.zero;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(origninalPosition, touchPosition);
    }
}