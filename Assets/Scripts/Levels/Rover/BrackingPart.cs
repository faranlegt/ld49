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
        if (isBroken)
        {
            var angle = Random.rotation;
            transform.localPosition = startingPoint + angle * (Vector3.forward * brokenRadius);
        }
        else
        {
            transform.localPosition = startingPoint;
        }
    }
}
