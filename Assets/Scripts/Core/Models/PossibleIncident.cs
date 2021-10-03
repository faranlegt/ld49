using UnityEngine;

namespace Core.Models
{
    [CreateAssetMenu(fileName = "Incident", menuName = "DI/Incident", order = 0)]
    public class PossibleIncident : ScriptableObject
    {
        public string incidentName;
        
        public float timeToFix;

        public string sequenceToFix;

        public float possibility;

        public AnimationClip brokenClip;
    }
}