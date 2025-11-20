using Project.Dev.GamePlay.ObjectEvent.Event;
using Project.Dev.Services.Interfaces;
using UnityEngine;
using Zenject;

namespace Project.Dev.GamePlay.NPC.Player1
{
    public class BallCollision : MonoBehaviour
    {
        private IRxEventService _events;
        private Rigidbody2D _rb;

        [SerializeField] private float speed;

        [Inject]
        private void Construct(IRxEventService events)
        {
            _events = events;
        }

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            var other = col.collider;

            if (other.CompareTag("Platform"))
            {
                BounceFromPlatform(col);
            }
            else if (other.CompareTag("Brick"))
            {
                BounceFromBrick(col);
                _events.Publish(new BrickEvent(col.gameObject));
            }
            else if (other.CompareTag("Wall"))
            {
                BounceFromWall(col);
            }
        }

        private void BounceFromPlatform(Collision2D col)
        {
            float x = (transform.position.x - col.transform.position.x) 
                      / col.collider.bounds.size.x;

            Vector2 dir = new Vector2(x, 1).normalized;
            _rb.velocity = dir * speed;
        }

        private void BounceFromBrick(Collision2D col)
        {
            Vector2 normal = col.contacts[0].normal;
            _rb.velocity = Vector2.Reflect(_rb.velocity, normal).normalized * speed;
        }

        private void BounceFromWall(Collision2D col)
        {
            Vector2 normal = col.contacts[0].normal;
            _rb.velocity = Vector2.Reflect(_rb.velocity, normal).normalized * speed;
        }
    }
}
