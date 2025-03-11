using UnityEngine;
using UnityEngine.UI;

namespace UI.AudioController
{
    [RequireComponent(typeof(AudioSource), typeof(Button))]
    public class ButtonController : MonoBehaviour
    {
        private Button _button;
        private AudioSource _audioSource;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(PlaySound);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(PlaySound);
        }

        private void PlaySound()
        {
            _audioSource.Play();
        }
    }
}