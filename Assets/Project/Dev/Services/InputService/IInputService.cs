using UnityEngine;
using UnityEngine.Events;

namespace Project.Dev.Services.InputService
{
    public interface IInputService
    {
        Vector2 MoveAxis { get; }

        event UnityAction AttackPressed;
    }
}
