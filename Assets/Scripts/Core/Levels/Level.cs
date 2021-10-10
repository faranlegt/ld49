using UnityEngine;

namespace Core.Levels
{
    [CreateAssetMenu(fileName = "level", menuName = "DI/Level", order = 0)]
    public class Level : ScriptableObject
    {
        public Sprite photo;

        public LevelController prefab;

        public GameObject elementsPrefab;

        public Sprite intro;

        public Sprite[] pages;
    }
}