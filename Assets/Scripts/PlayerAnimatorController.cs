using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    public const string Speed = nameof(Speed);
    public readonly int SpeedIndex = Animator.StringToHash(Speed);

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
        _animator.SetFloat(SpeedIndex, _maxSpeed);
    }

    private void Stop()
    {
        _animator.SetFloat(SpeedIndex, _minSpeed);
    }
}
