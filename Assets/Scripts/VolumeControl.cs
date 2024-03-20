using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Slider _volumeSlider;

    void Start()
    {
        _volumeSlider.value = _audioSource.volume;
        _volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }
    private void OnVolumeChanged(float volume)
    {
        _audioSource.volume = volume;
    }
}
