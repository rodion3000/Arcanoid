using UnityEngine;

namespace Project.Dev.GamePlay.ObjectEvent.Event
{
    public class LosingEvent : IObjectEvent
    {
        public GameObject Object { get; }

        public LosingEvent(GameObject gameObject) => Object = gameObject;
    }
}
