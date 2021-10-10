using Core.Models;

namespace Core.InputEventHandlers
{
    public abstract class InputHandler : IInputEventHandler
    {
        private bool _state;

        public bool AutoRelease { get; protected set; }

        public abstract string CodeName { get; }

        public InputEvent? Handle(InputEvent ev)
        {
            if (!(HandleInternal(ev) is { } value))
            {
                return null;
            }

            switch (_state, value, AutoRelease)
            {
                case (false, false, _):
                    return null;

                case (false, true, true):
                    return new InputEvent {
                        type = InputEventType.Once,
                        value = CodeName
                    };

                case (false, true, false):
                    _state = true;
                    return new InputEvent {
                        type = InputEventType.Start,
                        value = CodeName
                    };

                case (true, false, _):
                    _state = false;
                    return new InputEvent {
                        type = InputEventType.End,
                        value = CodeName
                    };

                case (true, true, _):
                    return new InputEvent {
                        type = InputEventType.Continue,
                        value = CodeName
                    };
            }
        }

        public abstract bool? HandleInternal(InputEvent ev);

        public void Release() => _state = false;
    }
}