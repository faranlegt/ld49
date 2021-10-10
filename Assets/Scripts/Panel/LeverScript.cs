using Core;
using Core.InputEventHandlers;
using UnityEngine;

namespace Panel
{
    public class LeverScript : MonoBehaviour
    {
        private SpriteRenderer _renderer;
        private EventManager _events;

        public bool isUp = false;
        private int anim = 0;
        public Sprite upSprite, downSprite, smudgeSprite;

        public AudioSource _sound_1, _sound_2;

        private void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();

            _events = FindObjectOfType<EventManager>();

            _sound_1 = GetComponentsInParent<AudioSource>()[0];
            _sound_2 = GetComponentsInParent<AudioSource>()[1];
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

            if (isUp)
                _sound_1.Play();
            else
                _sound_2.Play();
        }

        private void OnMouseUp()
        {
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
                OnMouseDown();

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
}
