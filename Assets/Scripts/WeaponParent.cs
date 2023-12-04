using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    public Vector2 pointerPosition;
    Camera main;
    PlayerController player;
    [SerializeField] float rotationSpeed = 1;

    void Awake()
    {
        main = Camera.main;
        player = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        pointerPosition = main.ScreenToWorldPoint(Input.mousePosition);
        if (!player.isSwinging)
        {
            transform.right = (pointerPosition - (Vector2)transform.position).normalized;
        }
        else
        {
            if (PlayerPrefs.GetInt("activeWeapon") == 1)
            {
                transform.Rotate(0, 0, rotationSpeed*1000*Time.deltaTime);
            }
            if (PlayerPrefs.GetInt("activeWeapon") == 2)
            {
                transform.Rotate(2500*Time.deltaTime, 0, rotationSpeed*500*Time.deltaTime);
            }
        }
        //transform.rotation = Quaternion.Euler(Vector3.forward * 50);
        
    }
}
