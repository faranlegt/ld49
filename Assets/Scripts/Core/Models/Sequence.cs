using Core.KeyHandlers;
using UnityEngine;

namespace Core.Models
{
    public class Sequence
    {
        public string Name { get; }

        private InputHandler _inputHandler;

        public Sequence(string name, InputHandler inputHandler)
        {
            Name = name;
            _inputHandler = inputHandler;
        }

        public bool Handle(InputEvent inputEvent)
        {
            var raised = _inputHandler.Handle(inputEvent);

            if (raised)
            {
                _inputHandler.Release();
            }
            
            Debug.Log($"Sequence {Name} was raised");

            return raised;
        }
    }
}