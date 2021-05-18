using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trapping : MonoBehaviour
{
    [SerializeField] LayerMask mask;
    [SerializeField] BoolSO needTrap;
    [SerializeField] RectTransform joystickField;
    [SerializeField] GameObject trapPrefab;
    [SerializeField] Vector3SO trapLocation;
    [SerializeField] GameManager _GM;
    // Start is called before the first frame update
    void Start()
    {
        trapLocation.value = Vector3.zero;
        needTrap.state = false;
    }
    public void NeedTrap()
    {
        needTrap.state = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            foreach (var touch in Input.touches)
            {
                RaycastHit hit;
                Vector3 touchposition = new Vector3(touch.position.x, touch.position.y,0.0f);
                Ray ray = Camera.main.ScreenPointToRay(touchposition);
                if (Physics.Raycast(ray, out hit,mask) && needTrap.state == false &&(hit.collider.gameObject.tag == "Ground"|| hit.collider.gameObject.tag == "Walkable") &&trapLocation.value==Vector3.zero&&!joystickField.rect.Contains(touch.position))
                {
                    trapLocation.value = hit.point;
                }
            }
        }
        if (needTrap.state==true&&_GM.Inv.GetItemCount(ItemTypes.Trap)>0)
        {
            Instantiate(trapPrefab, trapLocation.value, Quaternion.identity);
            _GM.Inv.UseItem(ItemTypes.Trap, 1);
            trapLocation.value = Vector3.zero;
            needTrap.state = false;
        }
        
    }
}
