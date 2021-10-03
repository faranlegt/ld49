using Core.EventHandlers;
using UnityEngine;

namespace Levels
{
    public class Spaghetti : Level
    {
        public override void Start()
        {
            base.Start();

            Events.Register(
                KeyCode.Q.Pressed().Named("press_q")
            );
            
            Events.Register(KeyCode.J.Pressed()
                .Then(KeyCode.K.Pressed())
                .WhilePressed(KeyCode.L)
                .Named("stir")
            );
            
            Events.Register(KeyCode.J.Pressed()
                .Then(KeyCode.K.Pressed())
                .Named("stir_test")
            );

            Events.Register(
                KeyCode.W.Hold(0.3f)
                    .Then(
                        KeyCode.Q.Pressed()
                            .Repeat(3)
                            .WhilePressed(KeyCode.W)
                    )
                    .Named("salt")
            );

            Events.Register(
                KeyCode.N.Pressed().Named("fire_up")
            );
            
            Events.Register(
                KeyCode.M.Pressed().Named("fire_down")
            );


        }
    }
}