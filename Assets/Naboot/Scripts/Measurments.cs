using UnityEngine;

public static class Measurements
{
    private static Vector2 distance;

    #region distance calculations
    public static float GetDistance(Transform a, Transform b)
    {
    
        return GetDistance(a.position,b.position);
    }
    public static float GetDistance(GameObject a, GameObject b)
    {
        
        return GetDistance(a.transform.position,b.transform.position);
    }
    public static float GetDistance(Vector3 a, Vector3 b)
    {
        distance.x = a.x - b.x;
        distance.y = a.z - b.z;
        float actualDistance = Vector2.SqrMagnitude(distance);
        return actualDistance;
    }
    #endregion

    #region RangeCalcualtions 
    public static bool isInRange(Transform a, Transform b, int range)
    {
        if (GetDistance(a, b) < range * range)
            return true;
        else return false;
    }
    #endregion
}