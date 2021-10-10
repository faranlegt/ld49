using Core.Levels;
using UnityEngine;

namespace Panel
{
    public class LevelProgress : MonoBehaviour
    {
        private LevelController _levelController;

        public void Start()
        {
            _levelController = FindObjectOfType<LevelController>();
        }

        public void Update()
        {
            var p = transform.position;
            p.x = 7 * _levelController.levelGoing / _levelController.fullLevelTime;
            transform.position = p;
        }
    }
}
