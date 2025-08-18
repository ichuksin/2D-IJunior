using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : MonoBehaviour
{
    [SerializeField] private float _directionOutward;
    [SerializeField] private DoorAnimator _animatorController;

    private bool _isOpen = false;

    public event Action DoorOpen;
    public event Action DoorClose;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Player>(out _))
        {
            if (!_isOpen)
            {
                _isOpen = true;
                _animatorController.DoorOpen();
                DoorOpen?.Invoke();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Player>(out _))
        {
            Vector2 contactPoint = collider.ClosestPoint(Vector2.zero);

            if (contactPoint.x < _directionOutward)
            {
                DoorClose?.Invoke();
                _isOpen = false;
                _animatorController.DoorClose();
            }
        }
    }
}
