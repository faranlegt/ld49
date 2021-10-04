using UnityEngine;

namespace Panel
{
    public class Book : MonoBehaviour
    {
        public Sprite[] pages;
        public int currentPage = 0;

        public SpriteRenderer pageRenderer;

        public void Update()
        {
            if (pages.Length > 0)
            {
                pageRenderer.sprite = pages[currentPage];
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                gameObject.SetActive(false);
            }
        }

        public void Next()
        {
            if (currentPage + 1 < pages.Length) currentPage++;
        }

        public void Prev()
        {
            if (currentPage > 0) currentPage--;
        }
    }
}
