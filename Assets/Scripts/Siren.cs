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
    private float _targetVolume = 0;

    public void Enable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        if (_audioSource.isPlaying == false)
            _audioSource.Play();

        _targetVolume = _maxVolume;
        _coroutine = StartCoroutine(nameof(ChangeVolume) );
    }

    public void Disable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _targetVolume = _minVolume;
        _coroutine = StartCoroutine(nameof(ChangeVolume) );
    }

    private IEnumerator ChangeVolume()
    {
        while (_currentVolume != _targetVolume)
        {
            _currentVolume = Mathf.MoveTowards(_currentVolume, _targetVolume, Time.deltaTime / _volumeChangeInSeconds);
            SetVolume();
            yield return null;
        }

        if (_targetVolume == 0.0f)
            _audioSource.Stop();
    }

    private void SetVolume()
    {
        _audioSource.volume = _currentVolume;
    }
}
