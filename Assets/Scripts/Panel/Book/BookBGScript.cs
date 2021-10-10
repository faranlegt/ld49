using UnityEngine;

namespace Panel.Book
{
    public class BookBGScript : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnMouseDown()
        {
            gameObject.SetActive(false);
        }
    }
}