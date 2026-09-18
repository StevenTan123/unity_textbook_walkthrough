using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public GameObject prefab;
    public GameObject shootPoint;

    public void OnFire(InputValue value) {
        if (value.isPressed) {
            Instantiate(prefab, shootPoint.transform.position, shootPoint.transform.rotation);
        }
    }
}
