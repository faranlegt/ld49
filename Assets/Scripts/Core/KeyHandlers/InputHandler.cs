using UnityEngine;

namespace Core.KeyHandlers
{
    public abstract class InputHandler : ScriptableObject
    {
        private bool _state = false;
        
        public bool Handle(InputEvent ev) => 
            _state |= HandleInternal(ev);

        protected abstract bool HandleInternal(InputEvent ev);

        public void Release() => _state = false;
    }
}