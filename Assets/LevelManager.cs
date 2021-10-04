using Core;
using System.Collections;
using System.Collections.Generic;
using Core.EventHandlers;
using Core.EventHandlers.Handlers;
using Core.Models;
using UnityEngine;

public class LevelManager : MonoBehaviour, IInputEventHandler
{
    protected EventManager Events;
    public string CodeName => "level-manager";

    public AudioSource _music, _muffledMusic, _cymbal;
    public GameObject _powerLever;

    [Range(0.0f, 1.0f)]
    public float musicFade = 0f;
    int fadeDurationMs = 3 * 60;
    float targetMusicFade = 0f;

    // =========================================================================

    void Start()
    {
        _muffledMusic = GetComponentsInParent<AudioSource>()[0];
        _music = GetComponentsInParent<AudioSource>()[1];
        _cymbal = GetComponentsInParent<AudioSource>()[2];

        _powerLever = GameObject.Find("power_lever");

        Events = FindObjectOfType<EventManager>();
        Events.Register(this);
    }

    void Update()
    {
        if (Mathf.Abs(targetMusicFade - musicFade) > 0.01f)
        musicFade += Mathf.Sign(targetMusicFade - musicFade) / fadeDurationMs;

        _music.volume = musicFade;
        _muffledMusic.volume = (1f - musicFade) * .3f;
    }

    // =========================================================================

    public void StartLevel()
    {
        targetMusicFade = 1f;
        fadeDurationMs = 4 * 60;
    }

    public void StopLevel()
    {
        targetMusicFade = 0f;
        fadeDurationMs = 1 * 60;
        _cymbal.Play();
    }

    // =========================================================================

    public virtual InputEvent? Handle(InputEvent ev) {

        if (ev.value == "lever-up")
        {
            StartLevel();
        }

        if (ev.value == "lever-down")
        {
            StopLevel();
        }

        return null;
    }
}
