using System;
using Core.EventHandlers.Handlers;
using Core.Models;
using UnityEngine;

namespace Core.EventHandlers
{
    public static class Helpers
    {
        public static InputHandler Then(this InputHandler h1, InputHandler next) =>
            new SequenceInputHandler(h1, next);
            
        public static InputHandler Then(this InputHandler h1, Action<InputEvent> reflex) =>
            new CustomInputHandler(h1.CodeName, h1.HandleInternal, reflex);

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

        public static CustomInputHandler On(string n, Func<InputEvent, bool?> handle, Action<InputEvent> reflex = null) =>
            new CustomInputHandler(n, handle, reflex);

        public static CustomInputHandler OnEvent(string name, Action<InputEvent> reflex = null) =>
            new CustomInputHandler($"trigger:{name}", e => e.value == name, reflex);
    }
}