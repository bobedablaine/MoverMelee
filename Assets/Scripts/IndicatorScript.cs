using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorScript : MonoBehaviour
{
    PlayerController player;
    Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {   
        player = FindObjectOfType<PlayerController>();
        enemy = GetComponentInParent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.isAttacking)
            transform.right = ((Vector2)player.transform.position - (Vector2)transform.position).normalized;
    }
}
