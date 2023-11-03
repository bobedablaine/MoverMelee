using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    public Vector2 pointerPosition;
    Camera main;
    PlayerController player;

    void Awake()
    {
        main = Camera.main;
        player = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        pointerPosition = main.ScreenToWorldPoint(Input.mousePosition);
        if (!player.isSwinging)
            transform.right = (pointerPosition - (Vector2)transform.position).normalized;
    }
}
