using Levels;
using UnityEngine;

namespace Panel
{
    public class Shield : MonoBehaviour
    {
        public Sprite lostSprite, wonSprite, shieldSprite;
        private SpriteRenderer _renderer;

        private Level _level;

        public void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _level = FindObjectOfType<Level>();
        }

        public void Update()
        {
            if (_level.levelGoing > _level.fullLevelTime)
            {
                _renderer.sprite = wonSprite;
            }
            else if (_level.failingTime > 7)
            {
                _renderer.sprite = lostSprite;
            }
            else
            {
                _renderer.sprite = shieldSprite;
            }
        }
    }
}
