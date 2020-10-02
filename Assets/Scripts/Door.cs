using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Door : MonoBehaviour
{
    [SerializeField] private float _directionOutward;

    private Animator _animator; 
    private bool _isOpen = false;

    public event UnityAction<bool> DoorOpen;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Player>())
        {
            if (!_isOpen)
            {
                _isOpen = true;
                _animator.SetTrigger("isOpen");
                DoorOpen?.Invoke(true);
            }
        }
    }
    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.GetComponent<Player>())
        {
            Vector2 contactPoint = collider.ClosestPoint(new Vector2(0, 0));
            if (contactPoint.x < _directionOutward)
            {
                DoorOpen?.Invoke(false);
                _isOpen = false;
                _animator.ResetTrigger("isOpen");
            }
        }
    }
}
