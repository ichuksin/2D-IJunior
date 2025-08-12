using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;


    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
            _animator.SetFloat("Speed", 1.0f);
            _spriteRenderer.flipX = true;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(_speed * Time.deltaTime , 0, 0);
            _animator.SetFloat("Speed", 1.0f);
            _spriteRenderer.flipX = false;
        }
        else
        {
            _animator.SetFloat("Speed", 0f);
        }
    }
}
