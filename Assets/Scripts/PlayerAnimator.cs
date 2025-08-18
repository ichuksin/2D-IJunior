using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public readonly int Speed = Animator.StringToHash(nameof(Speed));

    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Animator _animator;


    private float _minSpeed = 0;
    private float _maxSpeed = 1.0f;

    private void OnEnable()
    {
        _playerInput.Stop += Stop;
    }

    private void OnDisable()
    {
        _playerInput.Stop -= Stop;
    }

    public void Run()
    {
        _animator.SetFloat(Speed, _maxSpeed);
    }

    private void Stop()
    {
        _animator.SetFloat(Speed, _minSpeed);
    }
}
