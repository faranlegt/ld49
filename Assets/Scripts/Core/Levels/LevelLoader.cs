using System;
using Levels;
using Panel.Book;
using UnityEngine;

namespace Core.Levels
{
    public class LevelLoader : MonoBehaviour
    {
        public static Level LevelToLoad; // variable to save between scene loading

        public Level defaultLevel;
        
        private void Awake()
        {
            if (!LevelToLoad)
            {
                LevelToLoad = defaultLevel;
            }
            
            Instantiate(LevelToLoad.prefab.gameObject,
                Vector3.zero,
                Quaternion.identity,
                gameObject.transform
            );

            // add elements
            var monitor = GameObject.FindWithTag("Monitor");
            var elements = Instantiate(LevelToLoad.elementsPrefab,
                monitor.transform.position,
                Quaternion.identity,
                monitor.transform
            );
            monitor.GetComponent<LevelElements>().levelElements = elements;

            // change photos
            GameObject.FindWithTag("LevelPhoto").GetComponent<SpriteRenderer>().sprite = LevelToLoad.photo;
            GameObject.FindWithTag("Intro").GetComponent<SpriteRenderer>().sprite = LevelToLoad.intro;

            
        }

        private void Start()
        {
            var book = FindObjectOfType<Book>(); 
            book.pages = LevelToLoad.pages;
            book.gameObject.SetActive(false);
        }
    }
}