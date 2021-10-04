using System;
using Core;
using Core.EventHandlers;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    private SpriteRenderer _renderer;
    private EventManager _events;

    public bool isUp = true;
    private int anim = 0;
    public Sprite upSprite, downSprite, smudgeSprite;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _events = FindObjectOfType<EventManager>();
    }

    private void OnMouseDown()
    {
        isUp = !isUp;
        anim = 4;

        _events.Raise(new InputEvent()
        {
            type = InputEventType.Once,
            value = "lever-" + (isUp ? "up" : "down")
        });
    }

    private void OnMouseUp()
    {
    }

    void Update()
    {
        _renderer.sprite =
            anim > 0
                ? smudgeSprite
                : isUp
                    ? upSprite
                    : downSprite;

        if (anim > 0)
            anim--;
    }
}
