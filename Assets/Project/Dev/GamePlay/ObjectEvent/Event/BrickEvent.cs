
using UnityEngine;

namespace Project.Dev.GamePlay.ObjectEvent.Event
{
    public class BrickEvent : IObjectEvent
    {
        public GameObject Object { get; }
        
        public BrickEvent(GameObject obj) => Object = obj;
    }
}
