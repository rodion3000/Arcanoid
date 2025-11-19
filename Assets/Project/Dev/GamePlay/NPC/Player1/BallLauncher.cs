using Project.Dev.Services.InputService;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Project.Dev.GamePlay.NPC.Player1
{
    public class BallLauncher : MonoBehaviour
    {
        [SerializeField] private float launchForce = 10f;
        private bool _launched = false;
        [SerializeField] private Rigidbody2D rbBall;

        private IInputService _inputService;

        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }


        private void Update()
        {
            if (!_launched && Mouse.current.leftButton.wasPressedThisFrame)
            {
                LaunchBall();
            }
        }

        private void LaunchBall()
        {
            rbBall.transform.parent = null;
            _launched = true;
            rbBall.isKinematic = false;       // включаем физику
            rbBall.velocity = Vector2.up * launchForce; // стартовое движение
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!_launched) return;

            if (collision.gameObject.CompareTag("Platform"))
            {
                Debug.Log("длываааааааааааааааа");
                Vector3 platformPos = collision.transform.position;
                float hitPoint = (rbBall.transform.position.x - platformPos.x) / collision.collider.bounds.size.x;

                Vector2 direction = new Vector2(hitPoint, 1).normalized; // y всегда вверх
                rbBall.velocity = direction * rbBall.velocity.magnitude;
            }
        }

    }
}
