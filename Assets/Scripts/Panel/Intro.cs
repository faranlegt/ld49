using Core;
using Core.InputEventHandlers;
using UnityEngine;

namespace Panel
{
    public class Intro : MonoBehaviour
    {
        private SpriteRenderer _renderer;
        
        public void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
            
            var events = FindObjectOfType<EventManager>();

            events.Register(Helpers.OnEvent("lever-up", _ => _renderer.enabled = false));
            events.Register(Helpers.OnEvent("lever-down", _ =>  _renderer.enabled = true));
        }
    }
}