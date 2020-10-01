using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D collider)
    {
        Vector2 contactPOint = collider.ClosestPoint(new Vector2(0, 0));
        Debug.Log(contactPOint.x);
    }
    public void OnTriggerExit2D(Collider2D collider)
    {
        Vector2 contactPOint = collider.ClosestPoint(new Vector2(0, 0));
        Debug.Log("Выход " + contactPOint.x);
    }
}
