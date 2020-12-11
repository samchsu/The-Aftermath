using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barSlideHandler : MonoBehaviour
{
    public Slider s;
    public GameObject ps;
    Vector3 localScale;
    public void SetMaxCD(float curVal)
    {
        s.maxValue = curVal;
        s.value = curVal;
    }
    public void SetCD(float currVal)
    {
        s.value = currVal;
        localScale.x = currVal;
        localScale.y = 2f;
        localScale.z = 2f;
        ps.transform.localScale = localScale;
    }
}
