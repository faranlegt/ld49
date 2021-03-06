using Core;
using Core.InputEventHandlers;
using Core.Levels;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Levels.Pasta
{
    public class SpaghettiLevelController : LevelController
    {
        private BuzzSoundsScript _buzzer;

        public float timeToChangeFireSpeed;
        public float initialTimeToChangeFireSpeed = 3f;

        public float temperature = 85f;
        public float fireSpeed = 1f;
        public int userFireSpeed = 0;

        public bool needToSalt = false, needToStir = false;

        public bool lidOpen = false;

        public override bool IsFailing => needToSalt || needToStir || temperature < 81 || temperature > 89;

        public override void Start()
        {
            base.Start();
            _buzzer = FindObjectOfType<BuzzSoundsScript>();
            
            Events.Register(KeyCode.LeftArrow.Pressed()
                .Then(KeyCode.RightArrow.Pressed())
                .Repeat(5)
                //.WhilePressed(KeyCode.L)
                .Then(e =>
                {
                    if (!lidOpen || !needToStir) return;

                    needToStir = false;
                    Events.Raise(new InputEvent {
                        type = InputEventType.End,
                        value = "led:yellow"
                    });
                })
                .Named("stir")
            );

            Events.Register(
                Helpers.On("start_w", e => e is { type: InputEventType.Start, value: "key:W" } ? (bool?)true : null)
                    .Named("start_open_lid")
            );

            Events.Register(
                KeyCode.W.Hold(0.3f).Then(_ => lidOpen = true).Named("lid_open")
            );

            Events.Register(
                Helpers.On("end_w", e => e is { type: InputEventType.End, value: "key:W" } ? (bool?)true : null)
                    .Then(_ => lidOpen = false)
                    .Named("stop_open_lid")
            );

            Events.Register(
                KeyCode.E.Pressed()
                    .Repeat(3)
                    .WhilePressed(KeyCode.W)
                    .Then(e =>
                    {
                        if (!lidOpen || !needToSalt) return;

                        needToSalt = false;
                        Events.Raise(new InputEvent {
                            type = InputEventType.End,
                            value = "led:purple"
                        });
                    })
                    .Named("salt")
            );

            Events.Register(
                KeyCode.UpArrow.Pressed().Then(_ => userFireSpeed++).Named("temp_up")
            );

            Events.Register(
                KeyCode.DownArrow.Pressed().Then(_ => userFireSpeed--).Named("temp_down")
            );
        }

        public override void ClearLevel()
        {
            base.ClearLevel();
            
            needToSalt = false;
            needToStir = false;
            temperature = 85f;
            fireSpeed = 1f;
            userFireSpeed = 1;
            timeToChangeFireSpeed = 0;
            lidOpen = false;

            foreach (var led in new[] { "green", "yellow", "red", "purple" })
            {
                Events.Raise(new InputEvent {
                    type = InputEventType.End,
                    value = $"led:{led}"
                });
            }
        }

        public override void Update()
        {
            base.Update();
            
            if (!isPlaying) return;

            UpdateFireSpeed();
            UpdateTemp();
            SaltCheck();

            float levelTens = Mathf.RoundToInt(levelGoing / 10) * 10f;

            if (levelGoing > levelTens && levelGoing - Time.deltaTime < levelTens)
            {
                _buzzer.Buzz(5);
                needToStir = true;
                Events.Raise(new InputEvent() {
                    type = InputEventType.Start,
                    value = "led:yellow"
                });
            }

            Events.Raise(new InputEvent {
                type = InputEventType.Start,
                value = $"temp:{(int)temperature}"
            });
        }

        private void SaltCheck()
        {
            if (!(levelGoing >= 45 && levelGoing - Time.deltaTime < 45)) return;

            needToSalt = true;
            Events.Raise(new InputEvent() {
                type = InputEventType.Start,
                value = "led:purple"
            });
        }

        private void UpdateFireSpeed()
        {
            if (userFireSpeed > 2) userFireSpeed = 2;
            else if (userFireSpeed < -2) userFireSpeed = -2;

            timeToChangeFireSpeed -= Time.deltaTime;

            if (timeToChangeFireSpeed > 0) return;

            timeToChangeFireSpeed = initialTimeToChangeFireSpeed;
            fireSpeed = Random.Range(0, 2) - 1;
        }

        private void UpdateTemp()
        {
            var temperatureWasOkay = temperature > 81 && temperature < 89;
            temperature += (userFireSpeed + fireSpeed + (lidOpen ? -2 : 0)) * Time.deltaTime;
            var newTempOkay = temperature > 81 && temperature < 89;

            switch (temperatureWasOkay, newTempOkay)
            {
                case (true, false):

                    _buzzer.Buzz(1);
                    Events.Raise(new InputEvent() {
                        type = InputEventType.Start,
                        value = "led:red"
                    });
                    break;

                case (false, true):
                    Events.Raise(new InputEvent() {
                        type = InputEventType.End,
                        value = "led:red"
                    });
                    break;
            }
        }
    }
}