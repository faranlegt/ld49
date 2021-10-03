using System.Collections;
using System.Collections.Generic;
using Core;
using Core.EventHandlers;
using Core.Models;
using UnityEngine;

public class Indicator : MonoBehaviour, IInputEventHandler
{
    public bool on = false;

    public string indicatorName;

    private SpriteRenderer _renderer;
    private EventManager _events;

    public void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _events = FindObjectOfType<EventManager>();

        _events.Register(this);
    }

    public void Update()
    {
        _renderer.enabled = on;
    }

    public string CodeName { get; }

    public InputEvent? Handle(InputEvent ev)
    {
        if (ev.value == indicatorName && ev.type == InputEventType.Start)
        {
            on = true;
        }

        if (ev.value == indicatorName && ev.type == InputEventType.End)
        {
            on = false;
        }
        
        return null;
    }
}
