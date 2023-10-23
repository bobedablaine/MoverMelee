using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    public Vector2 pointerPosition;
    Camera main;

    void Awake()
    {
        main = Camera.main;
    }

    void Update()
    {
        pointerPosition = main.ScreenToWorldPoint(Input.mousePosition);
        transform.right = (pointerPosition - (Vector2)transform.position).normalized;
    }
}
