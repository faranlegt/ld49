using Core;
using Core.InputEventHandlers;
using Core.Models;
using UnityEngine;

public class wiperscript : MonoBehaviour
{
    private EventManager _events;

    int wipingTicks = 0;

    void Start()
    {
        _events = FindObjectOfType<EventManager>();

        _events.Register(Helpers.OnEvent("panel_dust", _ => wipingTicks = 60));
    }


    void Update()
    {
        if (wipingTicks <= 0) return;

        wipingTicks--;
        transform.Rotate(Vector3.forward * -0.1f);
    }
}