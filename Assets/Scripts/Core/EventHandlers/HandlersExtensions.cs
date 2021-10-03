using Core.EventHandlers.Handlers;
using Core.Models;
using UnityEngine;

namespace Core.EventHandlers
{
    public static class HandlersExtensions
    {
        public static InputHandler Then(this InputHandler h1, InputHandler next) =>
            new SequenceInputHandler(h1, next);

        public static InputHandler Repeat(this InputHandler h, int times) =>
            new RepeatInputHandler(h, times);

        public static NamedHandler Named(this InputHandler h, string name) =>
            new NamedHandler(name, h);

        public static InputHandler WhilePressed(this InputHandler h, KeyCode key) =>
            new WhileKeyDown(key, h);

        public static string ToEvent(this KeyCode k) => $"key:{k}";

        public static SinglePressHandler Pressed(this KeyCode k) => new SinglePressHandler(k.ToEvent());

        public static InputHoldHandler Hold(this KeyCode k, float time) =>
            new InputHoldHandler(k.ToEvent(), time);
    }
}