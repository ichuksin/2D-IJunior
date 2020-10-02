using UnityEngine;
public class Siren : MonoBehaviour
{
    [SerializeField] private Door _door;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _increaseVolumeInSeconds;
    
    private float _currentVolume = 0;
    private bool _reduction = false;

    private void OnEnable()
    {
        _door.DoorOpen += OnDoorOpen;
    }
    private void OnDisable()
    {
        _door.DoorOpen -= OnDoorOpen;
    }

    private void OnDoorOpen(bool doorOpen)
    {
        if (doorOpen)
        {
            _audioSource.volume = _currentVolume;
            _reduction = false;
            if (!_audioSource.isPlaying)
                _audioSource.Play();
        }
        else
        {
            _reduction = true;
        }
    }

    private void Update()
    {
        if (_audioSource.isPlaying)
        {
            if (!_reduction)
            {
                if (_currentVolume < 1.0f)
                {
                    _currentVolume += Mathf.Lerp(0, 1, Time.deltaTime / _increaseVolumeInSeconds);
                    _audioSource.volume = _currentVolume;
                }
            }
            else
            {
                if (_currentVolume > 0.0f)
                {
                    _currentVolume -= Mathf.Lerp(0, 1, Time.deltaTime / _increaseVolumeInSeconds);
                    _audioSource.volume = _currentVolume;
                }
                else
                {
                    _reduction = false;
                    _currentVolume = 0;
                    _audioSource.Stop();
                }
            }
        }
    }
}
