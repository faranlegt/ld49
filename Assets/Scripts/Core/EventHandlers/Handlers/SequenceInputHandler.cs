namespace Core.EventHandlers.Handlers
{
    public class SequenceInputHandler : InputHandler
    {
        private bool _firstHandled;
        private readonly InputHandler _h1;
        private readonly InputHandler _h2;

        public SequenceInputHandler(InputHandler h1, InputHandler h2)
        {
            _h1 = h1;
            _h2 = h2;

            AutoRelease = true;
        }

        public override string CodeName => $"seq:{_h1.CodeName}+{_h2.CodeName}";

        public override bool? HandleInternal(InputEvent ev)
        {
            if (_firstHandled)
            {
                var v = _h2.Handle(ev);

                if (v is { })
                {
                    _firstHandled = false;
                    return true;
                }

                return null;
            }
            
            _firstHandled |= _h1.Handle(ev) is { };
            return null;
        }
    }
}