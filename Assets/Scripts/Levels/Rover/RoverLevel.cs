using System.Collections.Generic;
using System.Linq;
using Core.EventHandlers;
using Core.EventHandlers.Handlers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Levels.Rover
{
    public class RoverLevel : Level
    {
        private BuzzSoundsScript _buzzer;
        public override bool IsFailing => broken.Any() || (isStorm && !Input.GetKey(KeyCode.E)) || panelDust;

        public bool isStorm, panelDust, sampleFailing, canSeeSample, needToCollectSample;
        public string sample;
        public HashSet<string> broken = new HashSet<string>();

        public override void Start()
        {
            base.Start();
            _buzzer = FindObjectOfType<BuzzSoundsScript>();
            
            RegisterFix("left_wheel", KeyCode.A);
            RegisterFix("middle_wheel", KeyCode.S);
            RegisterFix("right_wheel", KeyCode.D);
            RegisterFix("left_joint", KeyCode.F);
            RegisterFix("right_joint", KeyCode.G);
            
            Events.Register(KeyCode.W.Pressed().Then(_ =>
            {
                panelDust = false;
                
            
                Events.Raise(new InputEvent {
                    type = InputEventType.End,
                    value = "panel_dust"
                });
            }));
        }

        public override void ClearLevel()
        {
            base.ClearLevel();

            foreach (var led in new[] {
                "green", "yellow", "red", "purple", "storm", "panel_dust"
            })
            {
                Events.Raise(new InputEvent
                {
                    type = InputEventType.End,
                    value = $"led:{led}"
                });
            }

            foreach (var part in broken)
            {
                Events.Raise(new InputEvent {
                    type = InputEventType.End,
                    value = $"fix:{part}"
                });
            }
        }

        private void RegisterFix(string partName, KeyCode k)
        {
            Events.Register(k
                .Hold(1)
                .Then(_ =>
                {
                    if (!broken.Contains(partName)) return;

                    broken.Remove(partName);

                    Events.Raise(new InputEvent() {
                        type = InputEventType.Once,
                        value = $"fix:{partName}"
                    });

                    if (!broken.Any())
                    {
                        Events.Raise(new InputEvent {
                            type = InputEventType.End,
                            value = $"led:yellow"
                        });
                    }
                })
            );
        }

        private bool Time(float time) => levelGoing >= time && levelGoing - UnityEngine.Time.deltaTime < time;

        public override void Update()
        {
            base.Update();

            if (!isPlaying) return;

            if (Time(6f)) BrakeSomething();
            if (Time(8f)) BrakeSomething();
            if (Time(15f)) BrakeSomething();
            if (Time(27f)) BrakeSomething();
            if (Time(27f)) BrakeSomething();
            if (Time(35f)) BrakeSomething();
            if (Time(48f)) BrakeSomething();
            if (Time(55f)) BrakeSomething();

            if (Time(10)) StartStorm();
            if (Time(20)) EndStorm();
            if (Time(40)) StartStorm();
            if (Time(50)) EndStorm();
            if (Time(25)) StartStorm();
            if (Time(35)) EndStorm();
        }

        private void StartStorm()
        {
            Events.Raise(new InputEvent() {
                type = InputEventType.Start,
                value = $"storm"
            });
            isStorm = true;
        }

        private void EndStorm()
        {
            Events.Raise(new InputEvent() {
                type = InputEventType.End,
                value = $"storm"
            });
            isStorm = false;
            panelDust = true;
            
            Events.Raise(new InputEvent {
                type = InputEventType.Start,
                value = "panel_dust"
            });
        }


        private void BrakeSomething()
        {
            var s = new[] {
                "left_wheel", "middle_wheel", "right_wheel", "left_joint", "right_joint"
            }[Random.Range(0, 5)];

            broken.Add(s);

            Events.Raise(new InputEvent {
                type = InputEventType.Once,
                value = $"broken:{s}"
            });
            
            Events.Raise(new InputEvent {
                type = InputEventType.Start,
                value = $"led:yellow"
            });
        }
    }
}