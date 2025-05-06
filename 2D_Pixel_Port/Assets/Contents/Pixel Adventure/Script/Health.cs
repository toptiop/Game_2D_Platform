using System.Collections;
using TMPro;
using UnityEngine;

namespace Pixel.Player
{
    public class Health : MonoBehaviour
    {
        public static Health Instance;

        public int health = 5;
        public TMP_Text hpText;

        private Animator animator;

        private bool isInvincible = false;
        public float invincibleDuration = 0.3f;

        private void Awake()
        {
            Instance = this;
        }
        private void Start()
        {
            animator = GetComponentInChildren<Animator>();
            updateUI();
        }
        public void TakeDamage(int damage)
        {
            if (isInvincible) return;

            health -= damage;
            animator.SetTrigger("Hit");
            updateUI();

            StartCoroutine(InvincibilityCooldown());
        }

        IEnumerator InvincibilityCooldown()
        {
            isInvincible = true;
            yield return new WaitForSeconds(invincibleDuration);
            isInvincible = false;
        }

        void updateUI()
        {
            hpText.text = health.ToString();
        }
    }
}
