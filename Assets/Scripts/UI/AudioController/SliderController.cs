using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI.AudioController
{
    [RequireComponent(typeof(Slider))]
    public class SliderController : MonoBehaviour
    {
        private const float Multiplier = 20;
        private const float MinAmplitude = -80f;

        [SerializeField] private AudioMixerGroup _audioMixerGroup;

        [FormerlySerializedAs("_toggle")] [SerializeField]
        private ToggleController _toggleController;

        private Slider _slider;
        private string _parameterName;
        private float _currentValue;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
            _parameterName = _audioMixerGroup.name;
            _slider.value = 1f;
        }

        private void OnEnable()
        {
            _toggleController.OnToggleEnabled += SetVolume;
            _slider.onValueChanged.AddListener(SetVolume);
        }

        private void OnDisable()
        {
            _toggleController.OnToggleEnabled -= SetVolume;
            _slider.onValueChanged.RemoveListener(SetVolume);
        }

        private void SetVolume()
        {
            if (_toggleController.ParameterName == _parameterName)
                _audioMixerGroup.audioMixer.SetFloat(_parameterName, _currentValue);
        }

        private void SetVolume(float volume)
        {
            _audioMixerGroup.audioMixer.SetFloat(_parameterName, GetCorrectVolume(volume));
        }

        private float GetCorrectVolume(float volume)
        {
            _currentValue = volume;

            if (_toggleController.IsEnabled || _toggleController.ParameterName != _parameterName)
            {
                if (volume == 0)
                    return MinAmplitude;

                return Mathf.Log10(volume) * Multiplier;
            }

            return MinAmplitude;
        }
    }
}