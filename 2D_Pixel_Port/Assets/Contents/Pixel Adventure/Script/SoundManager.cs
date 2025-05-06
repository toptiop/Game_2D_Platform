using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public bool playSound;
    public AudioSource audios;
    public AudioClip coin, btn;

    public Toggle soundToggle;

    private void Awake()
    {
        instance = this;
    }

    public void PickupCoin()
    {
        if (playSound)
        {
            audios.PlayOneShot(coin);
        }
    }

    public void SoundBTN()
    {
        if (playSound)
        {
            audios.PlayOneShot(btn);
        }
    }

    public void SetToggle()
    {
        playSound = soundToggle.isOn;
    }
}
