using Core;
using Core.InputEventHandlers;
using UnityEngine;

namespace Levels
{
    public class LevelElements : MonoBehaviour
    {
        public GameObject levelElements;
    
        public void Start()
        {
            var events = FindObjectOfType<EventManager>();
        
            events.Register(Helpers.OnEvent("lever-up", _ => levelElements.SetActive(true)));
            events.Register(Helpers.OnEvent("lever-down", _ => levelElements.SetActive(false)));
        }
    }
}
