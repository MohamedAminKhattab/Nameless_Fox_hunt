using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Trapping : MonoBehaviour
{

    [SerializeField] BoolSO needTrap;
    [SerializeField] TransformSO trapLocation;
    [SerializeField] IntegerSO selectedLevel;
    [SerializeField] Level level;
    [SerializeField] GameObject trapPrefab;
    [SerializeField] GameManager _GM;
    [SerializeField] EventSO targetselected;
    [SerializeField] RectTransform joystickbackground;
    // Start is called before the first frame update
    void Start()
    {
        trapLocation.value = gameObject.transform;
        needTrap.state = false;
    }
    //private void Update()
    //{
    //    if (SceneManager.GetSceneByName($"Level {selectedLevel.value}").isLoaded)
    //    {
    //        if (Input.touchCount > 0)
    //        {
    //            foreach (var touch in Input.touches)
    //            {
    //                Ray ray = Camera.main.ScreenPointToRay(touch.position);
    //                if (Physics.Raycast(ray, out RaycastHit hit))
    //                {
    //                    if (FCompareTag(hit.collider.gameObject.tag) && !joystickbackground.rect.Contains(touch.position))
    //                    {
    //                        needTrap.state = true;
    //                        trapLocation.value = hit.transform;
    //                        targetselected.Raise();
    //                    }
    //                }
    //            }
    //        }
    //    }
    //}

    private bool FCompareTag(string tag)
    {
        return tag switch
        {
            "Walkable" => true,
            _ => false
        };
    }

    public void NeedTrap()
    {
        level = FindObjectOfType<Level>();
        if (needTrap.state == true && _GM.Inv.GetItemCount(ItemTypes.Trap) > 0 && trapLocation.value.position != gameObject.transform.position)
        {
            Instantiate(trapPrefab, trapLocation.value.position, Quaternion.identity);
            _GM.Inv.UseItem(ItemTypes.Trap, 1);
            trapLocation.value.position = gameObject.transform.position;
            needTrap.state = false;
        }
    }
}
