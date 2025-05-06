using Pixel.Manager;
using UnityEngine;

namespace Pixel.GamePlay
{
    public class Point : MonoBehaviour
    {
        public int point = 1;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                GameManager.instance.AddPoint(point);
                Destroy(gameObject);
            }
        }
    }
}
