using UnityEngine;
using UnityEngine.Audio;

public class OptionPanel : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _audioMixer;

    private string _masterVolume = "MasterVolume";
    private string _musicVolume = "MusicVolume";
    private string _soundVolume = "SoundVolume";
    private float _maxVolume = 1f;
    private float _minVolume = 0.0001f;

    private bool _isMusicToggleOn = true;
    private bool _isSoundToggleOn = true;

    public void ToggelMusic(bool enabled)
    {
        if (enabled)
        {
            _audioMixer.audioMixer.SetFloat(_musicVolume, Mathf.Log10(_maxVolume) * 20);
            _isMusicToggleOn = true;
        }
        else
        {
            _audioMixer.audioMixer.SetFloat(_musicVolume, Mathf.Log10(_minVolume) * 20);
            _isMusicToggleOn = false;
        }
    }

    public void ToggelSound(bool enabled)
    {
        if (enabled)
        {
            _audioMixer.audioMixer.SetFloat(_soundVolume, Mathf.Log10(_maxVolume) * 20);
            _isSoundToggleOn = true;
        }
        else
        {
            _audioMixer.audioMixer.SetFloat(_soundVolume, Mathf.Log10(_minVolume) * 20);
            _isSoundToggleOn = false;
        }
    }

    public void ChangeMasterVolume(float volume)
    {
        if (volume < _minVolume)
            volume = _minVolume;

        _audioMixer.audioMixer.SetFloat(_masterVolume, Mathf.Log10(volume) * 20);
    }

    public void ChangeMusicVolume(float volume)
    {
        if (_isMusicToggleOn == false)
            return;

        if (volume < _minVolume)
            volume = _minVolume;

        _audioMixer.audioMixer.SetFloat(_musicVolume, Mathf.Log10(volume) * 20);
    }

    public void ChangeSoundVolume(float volume)
    {
        if (_isSoundToggleOn == false)
            return;

        if (volume < _minVolume)
            volume = _minVolume;

        _audioMixer.audioMixer.SetFloat(_soundVolume, Mathf.Log10(volume) * 20);
    }
}
