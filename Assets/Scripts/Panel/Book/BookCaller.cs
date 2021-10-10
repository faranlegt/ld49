using UnityEngine;

namespace Panel.Book
{
    public class BookCaller : MonoBehaviour
    {
        public GameObject book;
    
        private void OnMouseDown()
        {
            book.SetActive(true);
        }
    }
}
