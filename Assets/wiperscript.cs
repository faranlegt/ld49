using Core;
using Core.EventHandlers;
using Core.Models;
using UnityEngine;

public class wiperscript : MonoBehaviour, IInputEventHandler
{
    private EventManager _events;
    public string CodeName => "wiper";

    int wipingTicks = 0;

    void Start()
    {
        _events = FindObjectOfType<EventManager>();

        _events.Register(Helpers.OnEvent("panel_dust", _ => wipingTicks = 60));
    }

    
    void Update()
    {
        if (wipingTicks > 0)
        {
            wipingTicks--;
            transform.Rotate(Vector3.forward * -0.1f);
        } 
    }

    public InputEvent? Handle(InputEvent ev) => null;
}
