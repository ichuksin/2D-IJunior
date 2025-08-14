using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Door : MonoBehaviour
{
    public const string IsOpen = nameof(IsOpen);

    [SerializeField] private float _directionOutward;

    public readonly int IsOpenIndex = Animator.StringToHash(IsOpen);


    private Animator _animator; 
    private bool _isOpen = false;

    public event UnityAction DoorOpen;
    public event UnityAction DoorClose;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Player>(out _))
        {
            if (!_isOpen)
            {
                _isOpen = true;
                _animator.SetTrigger(IsOpenIndex);
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
                _animator.ResetTrigger(IsOpen);
            }
        }
    }
}
