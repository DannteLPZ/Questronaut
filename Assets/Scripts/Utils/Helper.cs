using UnityEngine;

public static class Helper
{
    public static float MapValue(float value,  float min1, float max1, float min2, float max2, bool clamp = false)
    {
        float newValue = min2 + (max2 - min2) * ((value - min1)/(max1 - min1));
        return clamp ? Mathf.Clamp(newValue, Mathf.Min(min2, max2), Mathf.Max(min2, max2)) : newValue;
    }
}
