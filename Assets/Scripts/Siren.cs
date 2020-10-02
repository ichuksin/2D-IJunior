using UnityEngine;
using DG.Tweening;

public class Siren : MonoBehaviour
{
    [SerializeField] private Door _door;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _increaseVolumeInSeconds;
    
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
            if (!_audioSource.isPlaying)
                _audioSource.Play();
            _audioSource.DOFade(1, _increaseVolumeInSeconds);
        }
        else
        {
            _audioSource.DOFade(0, _increaseVolumeInSeconds).onComplete += OnComplete ;            
        }
    }
    
    private void OnComplete()
    {
        _audioSource.Stop();
    }
}
