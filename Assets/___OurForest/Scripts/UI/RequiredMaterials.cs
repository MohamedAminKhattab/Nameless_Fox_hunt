using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RequiredMaterials : MonoBehaviour
{
    [SerializeField] GameManager _GM;
    [SerializeField] ItemTypes type;
    [SerializeField] TMP_Text woodNeeded;
    [SerializeField] TMP_Text rockNeeded;
    [SerializeField] TMP_Text vineNeeded;
    // Start is called before the first frame update
    void Start()
    {
        woodNeeded.text = _GM.Inv.GetWoodneeded(type).ToString();
        rockNeeded.text = _GM.Inv.GetRockneeded(type).ToString();
        vineNeeded.text = _GM.Inv.GetVineneeded(type).ToString();
    }
}
