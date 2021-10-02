using UnityEngine;

namespace Core.KeyHandlers.Handlers
{
    [CreateAssetMenu(menuName = "DI/Input/KeyHold")]
    public class SinglePressHandler : InputHandler
    {
        public string value;

        protected override bool HandleInternal(InputEvent ev) => 
            ev.type == InputEventType.End && ev.value == ev.ToString();
    }
}