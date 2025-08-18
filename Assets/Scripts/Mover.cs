using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class Mover : MonoBehaviour
{
    [SerializeField] private PlayerAnimator _animatorController;
    [SerializeField] private float _speed;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private float _flipAngle = 180;

    private void OnEnable()
    {
        _playerInput.MoveHorizontal += Move;
    }

    private void OnDisable()
    {
        _playerInput.MoveHorizontal -= Move;
    }

    private void Move(float direction)
    {
        transform.Translate(_speed * Time.deltaTime, 0, 0);
        
        if (direction < 0)
            transform.rotation = Quaternion.Euler(0, _flipAngle, 0);    
        else
            transform.rotation = Quaternion.identity;

        _animatorController.Run();
    }
}
