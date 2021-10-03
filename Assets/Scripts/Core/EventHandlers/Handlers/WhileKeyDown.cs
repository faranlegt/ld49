using UnityEngine;

namespace Core.EventHandlers.Handlers
{
    public class WhileKeyDown : InputHandler
    {
        private readonly KeyCode _keyCode;
        private readonly InputHandler _inputHandler;
        public override string CodeName => $"while:{_keyCode}+{_inputHandler.CodeName}";

        public WhileKeyDown(KeyCode keyCode, InputHandler inputHandler)
        {
            _keyCode = keyCode;
            _inputHandler = inputHandler;

            AutoRelease = _inputHandler.AutoRelease;
        }

        public override bool? HandleInternal(InputEvent ev)
        {
            if (Input.GetKey(_keyCode))
            {
                return _inputHandler.HandleInternal(ev);
            }
            
            return false;
        }
    }
}