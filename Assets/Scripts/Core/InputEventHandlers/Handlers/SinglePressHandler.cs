namespace Core.InputEventHandlers.Handlers
{
    public class SinglePressHandler : InputHandler
    {
        private string _value;

        public override string CodeName => $"single:{_value}";

        public SinglePressHandler(string value)
        {
            _value = value;

            AutoRelease = true;
        }

        public override bool? HandleInternal(InputEvent ev) =>
            ev.type == InputEventType.Start && ev.value == _value;
    }
}