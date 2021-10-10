using Core.InputEventHandlers;

namespace Core.Models
{
    public interface IInputEventHandler
    {
        string CodeName { get; }
        
        InputEvent? Handle(InputEvent ev);
    }
}