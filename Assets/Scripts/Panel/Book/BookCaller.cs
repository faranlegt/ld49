using UnityEngine;

namespace Panel
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
