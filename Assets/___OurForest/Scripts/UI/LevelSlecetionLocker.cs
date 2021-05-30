using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSlecetionLocker : MonoBehaviour
{
    [SerializeField] Button levelbtn;
    [SerializeField] PlayerSaveSO save;
    [SerializeField] int levelnumber;
    private void Update()
    {
        if(levelnumber<=save.LastClearedLevel)
        {
            levelbtn.interactable = true;
        }
        else
        {
            levelbtn.interactable = false;
        }
    }
}
