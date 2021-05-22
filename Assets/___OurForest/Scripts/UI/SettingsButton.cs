using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButton : MonoBehaviour,IExecutable
{
    [SerializeField] Canvas mainmenu;
    [SerializeField] Canvas settingsmenu;
    public void Execute()
    {
        mainmenu.gameObject.SetActive(false);
        settingsmenu.gameObject.SetActive(true);
    }
}
