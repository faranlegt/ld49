using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IrisScript : MonoBehaviour
{
    private float t = 0;
    private Vector3 origin;
    
    void Start()
    {
        origin = transform.localPosition;
    }

    void Update()
    {
        t += Random.Range(0f, 5f);
        float t1 = t * 0.01f;
        int b = 10;
        float cos = Mathf.Cos(t1);
        float sin = Mathf.Sin(t1 * 0.7f + 200);
        float dx = Mathf.Sqrt((1 + b * b)/(1 + b * b * cos * cos)) * cos;
        float dy = Mathf.Sqrt((1 + b * b) / (1 + b * b * sin * sin)) * sin;

        transform.localPosition =
            origin + new Vector3(dx * 0.1f, dy * 0.1f, 0);
    }
}
