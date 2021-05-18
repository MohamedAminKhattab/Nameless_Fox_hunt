using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FellowEnemies : MonoBehaviour
{
    public List<Transform> myFellows { set; private get; }
    void Start()
    {
        myFellows = new List<Transform>();
        Measurements.GetDistance(myFellows[0], myFellows[1]);
    }
    public bool isAlone()
    {
        foreach (Transform fellow in myFellows)
        {
            if (fellow.gameObject == this.gameObject)
                continue;
            if (Measurements.isInRange(fellow, this.transform, 5))
                return false;
        }
        return true;
    }

}
