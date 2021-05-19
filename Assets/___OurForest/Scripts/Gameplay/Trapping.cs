using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trapping : MonoBehaviour
{

    [SerializeField] BoolSO needTrap;
    [SerializeField] GameObject trapPrefab;
    [SerializeField] Vector3SO trapLocation;
    [SerializeField] RectTransform joystickLocation;
    [SerializeField] GameManager _GM;
    Ray r;
    // Start is called before the first frame update
    void Start()
    {
        trapLocation.value = Vector3.zero;
        needTrap.state = false;
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            foreach (var touch in Input.touches)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                Physics.Raycast(ray, out RaycastHit hit);
                if (needTrap.state == false && TCompareTag(hit.collider.gameObject.tag)&&!joystickLocation.rect.Contains(touch.position))
                {
                    trapLocation.value = hit.transform.position;
                    needTrap.state = true;
                }
            }
        }
    }
    public void NeedTrap()
    {
        if (needTrap.state == true && _GM.Inv.GetItemCount(ItemTypes.Trap) > 0)
        {
            Instantiate(trapPrefab, trapLocation.value, Quaternion.identity);
            _GM.Inv.UseItem(ItemTypes.Trap, 1);
            trapLocation.value = Vector3.zero;
            needTrap.state = false;
        }
    }
    private bool TCompareTag(string tag)
    {
        return tag switch
        {
            "Walkable" => true,
            "Ground" => true,
            _ => false
        };
    }
}
