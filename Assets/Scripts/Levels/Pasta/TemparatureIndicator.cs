using Core;
using Core.InputEventHandlers;
using Core.Models;
using TMPro;
using UnityEngine;

namespace Levels.Pasta
{
    public class TemparatureIndicator : MonoBehaviour, IInputEventHandler
    {
        public string CodeName => "temp_indicator";
        private void Start()
        {
            var events = FindObjectOfType<EventManager>();
            var text = GetComponent<TextMeshProUGUI>();

            events.Register(this);

            events.Register(
                Helpers.On(
                    "temp_change",
                    ev => ev.value.StartsWith("temp:"),
                    ev => text.text = $"{ev.value.Substring(5)}ºC")
            );
        }

        public InputEvent? Handle(InputEvent ev) => null;
    }
}