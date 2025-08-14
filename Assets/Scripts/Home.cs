using UnityEngine;

public class Home : MonoBehaviour
{
    [SerializeField] private Door _door;
    [SerializeField] private Siren _siren;

    private void OnEnable()
    {
        _door.DoorOpen += OnDoorOpen;
        _door.DoorClose += OnDoorClose;
    }

    private void OnDisable()
    {
        _door.DoorOpen -= OnDoorOpen;
        _door.DoorClose -= OnDoorClose;
    }

    private void OnDoorOpen()
    {
        _siren.Enable();
    }

    private void OnDoorClose()
    {
        _siren.Disable();
    }

}
