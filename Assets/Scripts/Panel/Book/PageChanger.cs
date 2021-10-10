using UnityEngine;

namespace Panel.Book
{
    public class PageChanger : MonoBehaviour
    {
        public bool left = false;
        private Book _book;

        public void Start()
        {
            _book = GetComponentInParent<Book>();
        }

        private void OnMouseDown()
        {
            if (left)
            {
                _book.Prev();
            }
            else
            {
                _book.Next();
            }
        }
    }
}
