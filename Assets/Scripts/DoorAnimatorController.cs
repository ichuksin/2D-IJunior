using UnityEngine;

public class DoorAnimatorController : MonoBehaviour
{
    public const string IsOpen = nameof(IsOpen);
    public readonly int IsOpenIndex = Animator.StringToHash(IsOpen);

    [SerializeField] private Animator _animator;

    public void DoorOpen()
    {
        _animator.SetTrigger(IsOpenIndex);
    }

    public void DoorClose()
    {
        _animator.ResetTrigger(IsOpen);
    }
}
