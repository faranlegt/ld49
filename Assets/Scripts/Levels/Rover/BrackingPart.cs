using System.Collections;
using System.Collections.Generic;
using Core;
using Core.EventHandlers;
using UnityEngine;

public class BrackingPart : MonoBehaviour
{
    public string name;
    public bool isBroken;

    public float brokenRadius = 0.2f;
    
    public Vector3 startingPoint;
    private float t = 0;
    
    public void Start()
    {
        var events = FindObjectOfType<EventManager>();
        events.Register(
            Helpers.OnEvent($"broken:{name}", _ => isBroken = true)
        );
        events.Register(
            Helpers.OnEvent($"fix:{name}", _ => isBroken = false)
        );

        startingPoint = transform.localPosition;
    }

    public void Update()
    {
        t++;

        if (isBroken)
        {
            var angle = Random.rotation;
            transform.localPosition = startingPoint + angle * (Vector3.forward * brokenRadius);
        }
        else
        {
            transform.localPosition = startingPoint;

            // if (name.Contains("wheel"))
            // {
            //     transform.Rotate(Vector3.forward * -0.6f);
            //     transform.localPosition = startingPoint +
            //         new Vector3(
            //             0,
            //             Mathf.Sin(t * 0.3f + transform.position.x * 1.5f) * 0.02f,// + Mathf.Cos(t * 0.5f) * 0.02f,
            //             0);
            // }
        }
    }
}
