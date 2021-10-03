using UnityEngine;

namespace Panel
{
    public class Band : MonoBehaviour
    {
        private SpriteRenderer _renderer;
        public float maxPosition, minPosition, skipPosition, speed;

        public float minOpacity = 0.3f, maxOpacity = 0.6f;

        public void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
        }

        public void Update()
        {
            var c = _renderer.color;
            var p = transform.localPosition;

            c.a = minOpacity + (maxOpacity - minOpacity) * ((maxPosition - p.y) / (maxPosition - minPosition));
            _renderer.color = c;
        
            p.y -= speed * Time.deltaTime;

            if (p.y < minPosition - skipPosition)
            {
                p.y = maxPosition;
            }

            transform.localPosition = p;
        }
    }
}
