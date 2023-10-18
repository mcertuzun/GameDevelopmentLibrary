using Obvious.Soap;
using UnityEngine;

public class IncreaseGateValue : MonoBehaviour
{
    public FloatReference attributeSC;

    public float GetValue()
    {
        return attributeSC.Value;
    }
}
