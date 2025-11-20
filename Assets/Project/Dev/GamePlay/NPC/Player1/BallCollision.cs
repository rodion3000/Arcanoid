using UnityEngine;

namespace Project.Dev.GamePlay.NPC.Player1
{
    public class BallCollision : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Platform"))
            {
                Debug.Log(other.gameObject.name);
            }
        }
    }
}
