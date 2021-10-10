using Core.Models;

namespace Core.InputEventHandlers.Handlers
{
    public class NamedHandler : IInputEventHandler
    {
        public string CodeName { get; }

        private readonly InputHandler _inputHandler;

        public NamedHandler(string name, InputHandler inputHandler)
        {
            CodeName = name;
            _inputHandler = inputHandler;
        }

        public InputEvent? Handle(InputEvent inputEvent)
        {
            if (_inputHandler.Handle(inputEvent) is null) return null;

            _inputHandler.Release();

            return new InputEvent {
                type = InputEventType.Once,
                value = CodeName
            };
        }
    }
}