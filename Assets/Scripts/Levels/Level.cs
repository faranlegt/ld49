using System;
using Core;
using Core.EventHandlers;
using Core.EventHandlers.Handlers;
using Core.Models;
using UnityEngine;

namespace Levels
{
    public class Level : MonoBehaviour, IInputEventHandler
    {
        private void Start()
        {
            var eventHandler = FindObjectOfType<EventManager>();

            eventHandler.Register(
                KeyCode.Q.Pressed().Named("press_q")
            );
            
            eventHandler.Register(KeyCode.J.Pressed()
                .Then(KeyCode.K.Pressed())
                .WhilePressed(KeyCode.L)
                .Named("stir")
            );
            
            eventHandler.Register(KeyCode.J.Pressed()
                .Then(KeyCode.K.Pressed())
                .Named("stir_test")
            );

            eventHandler.Register(
                KeyCode.W.Hold(0.3f)
                    .Then(
                        KeyCode.Q.Pressed()
                            .Repeat(3)
                            .WhilePressed(KeyCode.W)
                    )
                    .Named("salt")
            );

            eventHandler.Register(
                KeyCode.N.Pressed().Named("fire_up")
            );
            
            eventHandler.Register(
                KeyCode.M.Pressed().Named("fire_down")
            );
            
            
            eventHandler.Register(this);
        }

        public string CodeName => "level";

        public InputEvent? Handle(InputEvent ev)
        {
            return null;
        }
    }
}