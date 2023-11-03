using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5;
    [SerializeField] float lungeSpeed = 5;
    [SerializeField] int enemyDamage = 20;
    public int enemyHealth = 50;
    Vector3 distanceToPlayer;
    public bool isAttacking = false;
    bool isLunging = false;
    float lungeTimer = 0;
    float enemyRange = 7;
    float timer = 0;
    float windupTimer = 0;
    PlayerController player;
    Rigidbody2D rb;
    GameObject indicator;
    EnemyManager enemyMan;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        indicator = transform.GetChild(0).GetChild(0).gameObject;
        enemyMan = FindObjectOfType<EnemyManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAttacking)
        {
            timer += Time.deltaTime;
            transform.position = 
            Vector2.MoveTowards(transform.position, player.transform.position, Time.deltaTime * moveSpeed);
        }
        distanceToPlayer = transform.position - player.transform.position;
        

        if (distanceToPlayer.magnitude < enemyRange && timer > 3)
        {   
            isAttacking = true;
            
            timer = 0;
        }

        if (isLunging)
        {
            lungeTimer += Time.deltaTime;
            if (lungeTimer > 2)
            {
                rb.velocity = Vector2.zero;
                lungeTimer = 0;
            }
        }

        if (isAttacking)
        {
            windupTimer += Time.deltaTime;
            indicator.SetActive(true);
            if (windupTimer > 1.5)
            {
                Attack();
                isAttacking = false;
                windupTimer = 0;
                indicator.SetActive(false);
            }
        }
        
        if (enemyHealth <= 0)
            EnemyDeath();
        
    }

    private void Attack()
    {
        isLunging = true;
        Vector2 lookDir = new Vector2(player.transform.position.x, player.transform.position.y) - rb.position;
        rb.AddForce(lookDir.normalized * lungeSpeed, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            player.playerHealth -= enemyDamage;
        }
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Weapon"))
        {
            enemyHealth -= player.weaponDamage;
        }
    }

    void EnemyDeath()
    {
        enemyMan.numOfEnemies--;
        Destroy(gameObject);
    }
}
