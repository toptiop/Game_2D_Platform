using System.Collections.Generic;
using UnityEngine;

namespace Pixel.Camera
{
    public class CameraManager : MonoBehaviour
    {
        public List<GameObject> vCam;      
        public Vector2 sizeBox = new Vector2(5, 5);
        [SerializeField] private LayerMask playerLayer;

        [SerializeField] Collider2D player;

        private void Update()
        {
            foreach (var cam in vCam)
            {
                bool hasPlayer = DetectPlayer(cam.transform.position);

                cam.SetActive(hasPlayer); // เปิดกล้องถ้ามีผู้เล่นในพื้นที่
            }
        }

        private bool DetectPlayer(Vector3 position)
        {
            player = Physics2D.OverlapBox(position, sizeBox, 0f, playerLayer);
            return player != null;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            foreach (var cam in vCam)
            {
                Gizmos.DrawWireCube(cam.transform.position, sizeBox);
            }
        }

    }
}


