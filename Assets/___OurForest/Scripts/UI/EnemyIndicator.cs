using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyIndicator : MonoBehaviour
{
    [SerializeField] GameObject arrowPrefab;
    [SerializeField] List<EnemyBehaviours> enemies;
    [SerializeField] List<GameObject> arrows;

    private void Start()
    {
        enemies = new List<EnemyBehaviours>(5);
        arrows = new List<GameObject>(5);
    }

    public void GetCharcters()
    {
        foreach (var item in arrows)
        {
           item.SetActive(false);
            Destroy(item);
        }
        arrows.Clear();
        enemies = FindObjectsOfType<EnemyBehaviours>().ToList();
            GameObject[] arr = new GameObject[enemies.Count];
            for (int i = 0; i < enemies.Count; i++)
            {
                arr[i] = Instantiate(arrowPrefab, transform);
                arr[i].SetActive(false);
            }
            arrows = arr.ToList();
    }
    public void LateUpdate()
    {
        foreach (var enemy in enemies)
        {
            if(enemy!=null)
            {

            Vector3 targetPosition = enemy.transform.position;
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
                arrows[enemies.IndexOf(enemy)].gameObject.SetActive(true);
                arrows[enemies.IndexOf(enemy)].GetComponent<RectTransform>().rotation =
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
                arrows[enemies.IndexOf(enemy)].gameObject.SetActive(false);
            }
            float margin = 70;
            screenPos.z = 0;
            screenPos.x = Mathf.Clamp(screenPos.x, margin, Screen.width - margin);
            screenPos.y = Mathf.Clamp(screenPos.y, margin, Screen.height - margin);
            arrows[enemies.IndexOf(enemy)].GetComponent<RectTransform>().position = screenPos;
            }
            else
            {
                arrows[enemies.IndexOf(enemy)].gameObject.SetActive(false);
            }
        }
    }
}
