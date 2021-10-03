using UnityEngine;

namespace Core.KeyHandlers.Handlers
{
    public class SinglePressHandler : InputHandler
    {
        private string _value;

        public SinglePressHandler(string value)
        {
            _value = value;
        }

        protected override bool HandleInternal(InputEvent ev) => 
            ev.type == InputEventType.End && ev.value == ev.ToString();
    }
}