using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TargetIndicator : MonoBehaviour
{
    [SerializeField] GameObject TargetPrefab;
    [SerializeField] List<TransformSO> Targets;
    [SerializeField] List<GameObject> Indicatortargets;
    [SerializeField] GameManager _GM;

    private void Start()
    {
        _GM = FindObjectOfType<GameManager>();
        Indicatortargets = new List<GameObject>(3);
    }

    public void GetCharcters()
    {
        foreach (var item in Indicatortargets)
        {
            item.SetActive(false);
            Destroy(item);
        }
        Indicatortargets.Clear();
        GameObject[] arr = new GameObject[Targets.Count];
        for (int i = 0; i < Targets.Count; i++)
        {
            arr[i] = Instantiate(TargetPrefab, transform);
            arr[i].SetActive(false);
        }
        Indicatortargets = arr.ToList();
    }
    public void LateUpdate()
    {
        foreach (var Target in Targets)
        {
            if (Target.value != null&&Indicatortargets.Count>0&&Target.value.position!=_GM.transform.position)
            {

                Vector3 targetPosition = Target.value.position;
                Vector3 screenPos = Camera.main.WorldToScreenPoint(targetPosition);
                if (Mathf.Approximately(screenPos.z, 0))
                {
                    return;
                }
                Vector3 halfScreen = new Vector3(Screen.width, Screen.height) / 2;
                Vector3 screenPosNoZ = screenPos;
                screenPosNoZ.z = 0;
                Vector3 screenCenterPos = screenPosNoZ - halfScreen;
                if (screenPos.z < 0)
                {
                    screenCenterPos *= -1;
                }
                if (screenPos.z < 0 || screenPos.x > Screen.width || screenPos.x < 0 ||
                    screenPos.y > Screen.height || screenPos.y < 0)
                {
                    Indicatortargets[Targets.IndexOf(Target)].gameObject.SetActive(true);
                    Indicatortargets[Targets.IndexOf(Target)].GetComponent<RectTransform>().rotation =
                        Quaternion.FromToRotation(Vector3.up, screenCenterPos);
                    Vector3 norSCP = screenCenterPos.normalized;
                    if (norSCP.x == 0)
                    {
                        norSCP.x = 0.01f;
                    }
                    if (norSCP.y == 0)
                    {
                        norSCP.y = 0.01f;
                    }
                    Vector3 xScreenCP = norSCP * (halfScreen.x / Mathf.Abs(norSCP.x));
                    Vector3 yScreenCP = norSCP * (halfScreen.y / Mathf.Abs(norSCP.y));
                    if (xScreenCP.sqrMagnitude < yScreenCP.sqrMagnitude)
                    {
                        screenPos = halfScreen + xScreenCP;
                    }
                    else
                    {
                        screenPos = halfScreen + yScreenCP;
                    }
                }
                else
                {
                    Indicatortargets[Targets.IndexOf(Target)].gameObject.SetActive(true);
                }
                float margin = 70;
                screenPos.z = 0;
                screenPos.x = Mathf.Clamp(screenPos.x, margin, Screen.width - margin);
                screenPos.y = Mathf.Clamp(screenPos.y, margin, Screen.height - margin);
                Indicatortargets[Targets.IndexOf(Target)].GetComponent<RectTransform>().position = screenPos;
            }
            else
            {
                if(Indicatortargets.Count>0)
                {
                Indicatortargets[Targets.IndexOf(Target)].gameObject.SetActive(false);
                }
            }
        }
    }
}
