using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public const string Horizontal = nameof(Horizontal);

    public event Action<float> MoveHorizontal;
    public event Action Stop;
    private float _previousDirection;

    private void Update()
    {
        float move = Input.GetAxisRaw(Horizontal);
        
        if (move != 0.0f)
        {
            MoveHorizontal?.Invoke(move);
            _previousDirection = move;
        }
        else if (_previousDirection != 0.0f)
        {
            Stop.Invoke();
        } 
    }
}
