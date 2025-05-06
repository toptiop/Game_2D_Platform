using UnityEngine;

namespace Pixel.GamePlay
{
    public class PlatForm : MonoBehaviour
    {
        public Transform posA, posB;
        public float Speed;
        Vector2 tragerPos;


        void Start()
        {
            tragerPos = posB.position;
        }


        void Update()
        {

            if (Vector2.Distance(transform.position, posA.position) < .1f) tragerPos = posB.position;

            if (Vector2.Distance(transform.position, posB.position) < .1f) tragerPos = posA.position;

            transform.position = Vector2.MoveTowards(transform.position, tragerPos, Speed * Time.deltaTime);

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                collision.transform.SetParent(this.transform);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                collision.transform.SetParent(null);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(posA.position, posB.position);

        }
    }
}
