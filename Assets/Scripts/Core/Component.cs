using System;
using Core.Models;
using UnityEngine;

namespace Core
{
    public class Component : MonoBehaviour
    {
        private ComponentsRegistry Registry => FindObjectOfType<ComponentsRegistry>(); 
    
        public PossibleIncident[] incidents;

        public AnimationClip idle;

        private void Start()
        {
            Registry.Register(this);
        }
    }
}