using System.Collections;
using UnityEngine;

public class Siren : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _volumeChangeInSeconds;
    [SerializeField] private float _minVolume = 0;
    [SerializeField] private float _maxVolume = 1.0f;

    private Coroutine _coroutine;
    private float _currentVolume = 0;

    public void Enable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        if (_audioSource.isPlaying == false)
            _audioSource.Play();

        _coroutine = StartCoroutine(ChangeVolume(_maxVolume) );
    }

    public void Disable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeVolume(_minVolume) );
    }

    private IEnumerator ChangeVolume(float targetVolume)
    {
        while (_currentVolume != targetVolume)
        {
            _currentVolume = Mathf.MoveTowards(_currentVolume, targetVolume, Time.deltaTime / _volumeChangeInSeconds);
            _audioSource.volume = _currentVolume;
            yield return null;
        }

        if (targetVolume == _minVolume)
            _audioSource.Stop();
    }
}
