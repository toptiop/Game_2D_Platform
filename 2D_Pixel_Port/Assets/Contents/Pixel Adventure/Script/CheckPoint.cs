using Pixel.Manager;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Pixel.GamePlay
{
    public class CheckPoint : MonoBehaviour
    {
        public bool checkIn;

        public GameObject gamePanel;
        public TMP_Text scoreEnd;


        private Animator animator => GetComponent<Animator>();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                checkIn = true;
                animator.SetBool("in", checkIn);
                GameManager.instance.isStart = false;

                StartCoroutine(WaitHome());
            }
        }

        IEnumerator WaitHome()
        {
            scoreEnd.text = "You score : " + GameManager.instance.score.ToString();
            yield return new WaitForSeconds(1);
            gamePanel.SetActive(true);
        }
    }

}
