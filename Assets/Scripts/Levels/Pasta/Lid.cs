using Core;
using Core.InputEventHandlers;
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

            events.Register(Helpers.OnEvent("lever-up", Clear));
            events.Register(Helpers.OnEvent("lever-down", Clear));

            void Clear(InputEvent _)
            {
                var r = transform.eulerAngles;
                var p = transform.localPosition;
                r.z = 0;
                p.y = minHeight;
                p.x = -1.8f;
                transform.localPosition = p;
                transform.eulerAngles = r;
            }
        }

        public void Update()
        {
            var r = transform.eulerAngles;
            var p = transform.localPosition;

            if (lidOpening && p.y < maxHeight)
            {
                p.y += Time.deltaTime * speed;
                p.x -= Time.deltaTime * speed;
                r.z += Time.deltaTime * speed * 25;
            }
            else if (!lidOpening && p.y > minHeight)
            {
                p.y -= Time.deltaTime * speed;
                p.x += Time.deltaTime * speed;
                r.z -= Time.deltaTime * speed * 25;
            }

            transform.localPosition = p;
            transform.eulerAngles = r;
        }

        public InputEvent? Handle(InputEvent ev) => null;
    }
}
