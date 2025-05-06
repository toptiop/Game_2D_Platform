using Pixel.Player;
using UnityEngine;

namespace Pixel.Trap
{
    public class Trap : MonoBehaviour
    {
        public int damage = 1;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Health.Instance.TakeDamage(damage);
            }
        }
    }
}
