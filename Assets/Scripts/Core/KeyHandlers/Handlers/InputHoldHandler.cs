using UnityEditor;
using UnityEngine;

namespace Core.KeyHandlers.Handlers
{
    public class InputHoldHandler : InputHandler
    {
        private readonly string _value;
        private readonly float _targetHoldTime;
        
        private float _holdTime;

        public InputHoldHandler(string value, float targetHoldTime = 1.0f)
        {
            _value = value;
            _targetHoldTime = targetHoldTime;
        }

        protected override bool HandleInternal(InputEvent ev)
        {
            if (ev.value != _value) return _holdTime > _targetHoldTime;

            switch (ev.type)
            {
                case InputEventType.End:
                    _holdTime = 0;
                    break;

                case InputEventType.Continue:
                    _holdTime += Time.deltaTime;
                    break;
            }

            return _holdTime > _targetHoldTime;
        }
    }
}
