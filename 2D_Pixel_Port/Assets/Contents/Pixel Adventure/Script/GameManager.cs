using Pixel.Player;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pixel.Manager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        public bool isStart;

        public int score = 0;
        [SerializeField] private TMP_Text _ScoreText;
        private void Awake()
        {
            instance = this;
        }

        void Update()
        {
            if(Health.Instance.health <= 0)
            {
                Home();
            }
        }

        public void AddPoint(int point)
        {
            score += point;
            _ScoreText.text = score.ToString();
        }

        public void PlayGame()
        {
            isStart = true;
        }

        public void Home() //reset Scene
        {
            SceneManager.LoadScene("PixelGame");
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}
