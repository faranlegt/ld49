using Core.Levels;
using Levels;
using UnityEngine;

namespace Panel
{
    public class Shield : MonoBehaviour
    {
        public Sprite lostSprite, wonSprite, shieldSprite;
        private SpriteRenderer _renderer;

        private LevelController _levelController;

        public void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _levelController = FindObjectOfType<LevelController>();
        }

        public void Update()
        {
            if (_levelController.levelGoing > _levelController.fullLevelTime)
            {
                _renderer.sprite = wonSprite;
            }
            else if (_levelController.failingTime > 7)
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
