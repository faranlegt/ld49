using UnityEngine;

namespace Core.KeyHandlers
{
    public abstract class InputHandler
    {
        private bool _state;
        protected bool AutoRelease = false;
        
        public bool Handle(InputEvent ev)
        {
            var value = HandleInternal(ev);
            
            if (!AutoRelease)
            {
                _state |= value;
            }
            
            return value;
        }

        protected abstract bool HandleInternal(InputEvent ev);

        public void Release() => _state = false;
    }
}