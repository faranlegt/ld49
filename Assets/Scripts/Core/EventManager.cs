using System;
using System.Collections.Generic;
using Core.EventHandlers;
using Core.Models;
using UnityEngine;

namespace Core
{
    public class EventManager : MonoBehaviour
    {
        private List<IInputEventHandler> _handlers = new List<IInputEventHandler>();

        public void Register(IInputEventHandler sequence)
        {
            _handlers.Add(sequence);
        }

        public void Raise(InputEvent ev)
        {
            if (ev.type == InputEventType.Once)
            {
                Debug.Log($"Raised input event: {ev.value}");
            }

            foreach (var handler in _handlers)
            {
                if (handler.Handle(ev) is { } newEvent)
                {
                    Raise(newEvent);
                }
            }
        }

        public void Update()
        {
            foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(keyCode))
                {
                    Raise(new InputEvent {
                        type = InputEventType.Start,
                        value = keyCode.ToEvent()
                    });
                }

                if (Input.GetKey(keyCode))
                {
                    Raise(new InputEvent {
                        type = InputEventType.Continue,
                        value = keyCode.ToEvent()
                    });
                }

                if (Input.GetKeyUp(keyCode))
                {
                    Raise(new InputEvent {
                        type = InputEventType.End,
                        value = keyCode.ToEvent()
                    });
                }
            }
        }
    }
}