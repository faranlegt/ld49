using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class ComponentsRegistry : MonoBehaviour
    {
        public List<Component> components;
        
        public void Register(Component component)
        {
            components.Add(component);
        }
    }
}