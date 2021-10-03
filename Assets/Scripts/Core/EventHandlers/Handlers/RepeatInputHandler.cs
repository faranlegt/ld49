namespace Core.EventHandlers.Handlers
{
    public class RepeatInputHandler : InputHandler
    {
        private readonly InputHandler _inputHandler;
        private readonly int _times;
        private int _handledTimes;

        public RepeatInputHandler(InputHandler inputHandler, int times)
        {
            _inputHandler = inputHandler;
            _times = times;

            AutoRelease = true;
        }

        public override string CodeName => $"rep:{_times}*{_inputHandler.CodeName}";

        public override bool? HandleInternal(InputEvent ev)
        {
            if (_inputHandler.Handle(ev) is { type: InputEventType.Once })
            {
                _handledTimes++;
            }

            if (_handledTimes >= _times)
            {
                _handledTimes = 0;
                return true;
            }

            return false;
        }
    }
}