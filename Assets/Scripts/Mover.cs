using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class Mover : MonoBehaviour
{
    public const string Speed = nameof(Speed);
    public readonly int SpeedIndex = Animator.StringToHash(Speed);

    [SerializeField] private float _speed;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _flipAngle = 180;

    
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
        transform.Translate(_speed * Time.deltaTime, 0, 0);
        
        if (direction < 0)
            transform.rotation = Quaternion.Euler(0, _flipAngle, 0);    
        else
            transform.rotation = Quaternion.identity;
    }

    private void Stop()
    {
        _animator.SetFloat(SpeedIndex, _minSpeed);
    }
}
