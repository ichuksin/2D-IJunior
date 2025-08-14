using System.Collections;

using UnityEngine;
public class Siren : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _volumeChangeInSeconds;
    [SerializeField] private float _volumeChangeStep;
    [SerializeField] private float _minVolume = 0;
    [SerializeField] private float _maxVolume = 1.0f;

    private Coroutine _coroutine;
    private float _timeDelay ;
    private float _currentVolume = 0;

    public void Enable()
    {
        if (_coroutine != null) 
            StopCoroutine(_coroutine);
        
        if (_audioSource.isPlaying == false)
            _audioSource.Play();
        
        _coroutine = StartCoroutine(nameof(ChangeVolumeToMax));
    }

    public void Disable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(nameof(ChangeVolumeToMin));
    }

    private void Start()
    {
        _timeDelay = _volumeChangeInSeconds / _volumeChangeStep;
    }

    private IEnumerator ChangeVolumeToMax()
    {
        var wait = new WaitForSeconds(_timeDelay);

        while (_currentVolume < _maxVolume)
        {
            _currentVolume += Mathf.MoveTowards(0, 1, Time.deltaTime / _volumeChangeInSeconds);
            SetVolume();
            yield return wait;
        }

        yield break;
    }

    private IEnumerator ChangeVolumeToMin()
    {
        var wait = new WaitForSeconds(_timeDelay);

        while (_currentVolume > _minVolume)
        {
            _currentVolume -= Mathf.MoveTowards(0, 1, Time.deltaTime / _volumeChangeInSeconds);
            SetVolume();
            yield return wait;
        }
        
        _currentVolume = 0;
        _audioSource.Stop();
        yield break;
    }

    private void SetVolume()
    {
        _audioSource.volume = _currentVolume;
    }
}
