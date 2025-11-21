using Project.Dev.Services.InputService;
using UnityEngine;
using Zenject;

namespace Project.Dev.GamePlay.NPC.Player1
{
    public class HeroMove : MonoBehaviour
    {
        [SerializeField] private float movementSpeed ;
        [SerializeField] private float leftLimit ;
        [SerializeField] private float rightLimit;

        private IInputService _inputService;

        [Inject]
        private void Construct(IInputService inputService) => _inputService = inputService;

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            float moveX = _inputService.MoveAxis.x;
            if (Mathf.Abs(moveX) < 0.01f) return;

            Vector3 newPosition = transform.position;
            newPosition.x += moveX * movementSpeed * Time.deltaTime;

            newPosition.x = Mathf.Clamp(newPosition.x, leftLimit, rightLimit);

            transform.position = newPosition;
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
