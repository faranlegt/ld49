using Core;
using Core.InputEventHandlers;
using Core.Models;
using UnityEngine;

namespace Levels
{
    public class LevelMusic : MonoBehaviour, IInputEventHandler
    {
        protected EventManager Events;
        public string CodeName => "level-manager";

        private AudioSource _music, _muffledMusic, _cymbal;
    
        [Range(0.0f, 1.0f)]
        public float musicFade = 0f;

        private int _fadeDurationMs = 3 * 60;
        private float _targetMusicFade = 0f;

        // =========================================================================

        public void Start()
        {
            _muffledMusic = GetComponentsInParent<AudioSource>()[0];
            _music = GetComponentsInParent<AudioSource>()[1];
            _cymbal = GetComponentsInParent<AudioSource>()[2];
        
            Events = FindObjectOfType<EventManager>();
            Events.Register(this);
        }

        void Update()
        {
            if (Mathf.Abs(_targetMusicFade - musicFade) > 0.01f)
                musicFade += Mathf.Sign(_targetMusicFade - musicFade) / _fadeDurationMs;

            _music.volume = musicFade;
            _muffledMusic.volume = (1f - musicFade) * .3f;
        }

        // =========================================================================

        private void StartLevel()
        {
            _targetMusicFade = 1f;
            _fadeDurationMs = 4 * 60;
        }

        private void StopLevel()
        {
            _targetMusicFade = 0f;
            _fadeDurationMs = 1 * 60;
            _cymbal.Play();
        }

        // =========================================================================

        public virtual InputEvent? Handle(InputEvent ev)
        {
            switch (ev.value)
            {
                case "lever-up":
                    StartLevel();
                    break;
                case "lever-down":
                case "game_lost":
                    StopLevel();
                    break;
            }

            return null;
        }
    }
}