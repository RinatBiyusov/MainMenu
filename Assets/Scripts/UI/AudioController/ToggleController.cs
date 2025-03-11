using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Audio;
using System;

namespace UI.AudioController
{
    [RequireComponent(typeof(Toggle))]
    public class ToggleController : MonoBehaviour
    {
        private const float MinAmplitude = -80f;

        [SerializeField] private AudioMixerGroup _audioMixerGroup;

        private Toggle _toggle;
        private string _parameterName;

        public event Action OnToggleEnabled;

        public bool IsEnabled { get; private set; } = true;
        public string ParameterName { get; private set; }

        private void Awake()
        {
            _toggle = GetComponent<Toggle>();
            _parameterName = _audioMixerGroup.name;
            ParameterName =  _parameterName;
        }

        private void OnEnable()
        {
            _toggle.onValueChanged.AddListener(SetState);
        }

        private void OnDisable()
        {
            _toggle.onValueChanged.RemoveListener(SetState);
        }

        private void SetState(bool value)
        {
            IsEnabled = value;

            if (value)
                OnToggleEnabled?.Invoke();
            else
                _audioMixerGroup.audioMixer.SetFloat(_parameterName, MinAmplitude);
        }
    }
}