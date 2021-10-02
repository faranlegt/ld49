using UnityEditor;
using UnityEngine;

namespace Core.KeyHandlers.Handlers
{
    [CreateAssetMenu(menuName = "DI/Input/KeyHold")]
    public class InputHoldHandler : InputHandler
    {
        public string value;
        public float targetHoldTime;
        
        private float _holdTime;

        protected override bool HandleInternal(InputEvent ev)
        {
            if (ev.value != value) return _holdTime > targetHoldTime;

            switch (ev.type)
            {
                case InputEventType.End:
                    _holdTime = 0;
                    break;

                case InputEventType.Continue:
                    _holdTime += Time.deltaTime;
                    break;
            }

            return _holdTime > targetHoldTime;
        }
    }
}
