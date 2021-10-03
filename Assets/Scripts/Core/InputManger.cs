using System;
using Core.KeyHandlers;
using UnityEngine;

namespace Core
{
    public class InputManger : MonoBehaviour
    {
        public void Raise(InputEvent ev)
        {
            Debug.Log($"Raised input event: {ev.type}.{ev.value}");
        }

        public void Update()
        {
            foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(keyCode))
                {
                    Raise(new InputEvent {
                        type = InputEventType.Start,
                        value = $"key:{keyCode}"
                    });
                }
                
                if (Input.GetKey(keyCode))
                {
                    Raise(new InputEvent {
                        type = InputEventType.Continue,
                        value = $"key:{keyCode}"
                    });
                }
                
                if (Input.GetKeyUp(keyCode))
                {
                    Raise(new InputEvent {
                        type = InputEventType.End,
                        value = $"key:{keyCode}"
                    });
                }
            }
        }
    }
}
