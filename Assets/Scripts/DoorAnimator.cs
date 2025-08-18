using UnityEngine;

public class DoorAnimator : MonoBehaviour
{
    public readonly int IsOpen = Animator.StringToHash(nameof(IsOpen));

    [SerializeField] private Animator _animator;

    public void DoorOpen()
    {
        _animator.SetTrigger(IsOpen);
    }

    public void DoorClose()
    {
        _animator.ResetTrigger(IsOpen);
    }
}
