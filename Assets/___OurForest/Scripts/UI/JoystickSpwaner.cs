using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoystickSpwaner : MonoBehaviour
{
    [SerializeField] Image joystick;
    [SerializeField] Image joystickPad;
    [SerializeField] Vector3SO position;
    [SerializeField] RectTransform background;
    Vector3 touchPosition;


    public void GetTouchPosition()
    {
        if (Input.touchCount > 0)
        {
            foreach (var touch in Input.touches)
            {
             touchPosition = touch.position;
            if(background.rect.Contains(touchPosition))
                {
                    position.value = touchPosition;
                }
            }
        }
    }
    public void ShowJoystick()
    {
        joystick.transform.position = position.value;
        joystickPad.transform.position = position.value;
    }
}