using Core.EventHandlers;

namespace Core.Models
{
    public interface IInputEventHandler
    {
        string CodeName { get; }
        
        InputEvent? Handle(InputEvent ev);
    }
}