using UnityEngine;

namespace Core
{
    public class BuzzSoundsScript : MonoBehaviour
    {
        public AudioClip[] buzzSounds;
        AudioSource source;

        void Start()
        {
            source = gameObject.AddComponent<AudioSource>();  
        }

        public void Buzz(int index)
        {
            source.clip = buzzSounds[index];
            source.Play();
        }
    
        void Update()
        {
        
        }
    }
}
