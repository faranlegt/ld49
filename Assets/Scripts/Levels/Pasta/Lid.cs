using Core;
using Core.EventHandlers;
using Core.Models;
using UnityEngine;

namespace Levels.Pasta
{
    public class Lid : MonoBehaviour, IInputEventHandler
    {
        public string CodeName => "lid";

        public bool lidOpening;
        public float minHeight, maxHeight, speed = 1;
    
        public void Start()
        {
            var events = FindObjectOfType<EventManager>();
            events.Register(this);
            
            events.Register(Helpers.OnEvent("start_open_lid", _ => lidOpening = true));
            events.Register(Helpers.OnEvent("stop_open_lid", _ => lidOpening = false));
        }

        public void Update()
        {
            var p = transform.localPosition;

            if (lidOpening && p.y < maxHeight)
            {
                p.y += Time.deltaTime * speed;
            }
            else if (!lidOpening && p.y > minHeight)
            {
                p.y -= Time.deltaTime * speed;
            }

            transform.localPosition = p;
        }

        public InputEvent? Handle(InputEvent ev) => null;
    }
}
