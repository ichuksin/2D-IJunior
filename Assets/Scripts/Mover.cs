using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private PlayerInput _playerInput;

    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public const string Speed = nameof(Speed);
    public readonly int SpeedIndex = Animator.StringToHash(Speed);
    
    private float _minSpeed = 0;
    private float _maxSpeed = 1.0f;

    private void OnEnable()
    {
        _playerInput.MoveHorizontal += Move;
        _playerInput.Stop += Stop;
    }

    private void OnDisable()
    {
        _playerInput.MoveHorizontal -= Move;
        _playerInput.Stop -= Stop;
    }

    private void Move(float direction)
    {
        _animator.SetFloat(SpeedIndex, _maxSpeed);
        transform.Translate(_speed * Time.deltaTime * direction, 0, 0);
        _spriteRenderer.flipX = (direction < 0);
    }

    private void Stop()
    {
        _animator.SetFloat(Speed, _minSpeed);
    }
}
