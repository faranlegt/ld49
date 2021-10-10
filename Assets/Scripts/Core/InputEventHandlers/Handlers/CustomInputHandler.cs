using System;

namespace Core.InputEventHandlers.Handlers
{
    public class CustomInputHandler : InputHandler
    {
        private readonly string _name;
        private readonly Func<InputEvent, bool?> _handle;
        private readonly Action<InputEvent> _reflex;

        public CustomInputHandler(string name, Func<InputEvent, bool?> handle, Action<InputEvent> reflex = null)
        {
            _name = name;
            _handle = handle;
            _reflex = reflex;

            AutoRelease = true;
        }

        public override string CodeName => $"cstm:{_name}";

        public override bool? HandleInternal(InputEvent ev)
        {
            var res = _handle(ev);

            if (res is true && _reflex is { })
            {
                _reflex(ev);
            }

            return res;
        }
    }
}