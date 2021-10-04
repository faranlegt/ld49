using UnityEngine;

namespace Levels.Pasta
{
    public class Fire : MonoBehaviour
    {
        public Sprite[] frames;
        private SpaghettiLevel _level;
        private SpriteRenderer _renderer;

        public void Start()
        {
            _level = FindObjectOfType<SpaghettiLevel>();
            _renderer = GetComponent<SpriteRenderer>();
        }

        public void Update()
        {
            var frame = _level.userFireSpeed + 2;
            var opacity = 0.5f;
            
            if (frame >= frames.Length - 1) {
                opacity = 1f;
            }

            _renderer.color = new Color(1, 1, 1, opacity);
            _renderer.sprite = frames[frame];
        }
    }
}
