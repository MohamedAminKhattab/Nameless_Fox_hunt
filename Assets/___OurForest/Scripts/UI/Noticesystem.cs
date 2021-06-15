using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Noticesystem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TMP_Text notice;
    public void wait()
    {
        StartCoroutine(ClearText());
    }
    IEnumerator ClearText()
    {
        yield return new WaitForSeconds(2.0f);
        notice.text = null;
    }
}
