using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Camera main;
    PlayerInputActions playerControls;
    private InputAction move;
    private InputAction fire;
    private InputAction dodge;
    private Vector2 moveDirection;
    private Rigidbody2D rb;
    public int playerHealth = 100;
    int currentHealth = 100;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float dodgeDuration = 2f;
    [SerializeField] private float dodgeTimer = 0f;
    [SerializeField] float weaponDuration = 2f;
    [SerializeField] private float weaponTimer = 0f;
    public int weaponDamage = 10;
    [SerializeField] GameObject weapon;
    bool isDodging = false;
    public bool isSwinging = false;
    BoxCollider2D bc;
    [SerializeField] float iframeTimer = 0;
    private void Awake()
    {
        playerControls = new PlayerInputActions();
        rb = GetComponent<Rigidbody2D>();
        main = Camera.main;
        bc = GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();

        fire = playerControls.Player.Fire;
        fire.Enable();
        fire.performed += Fire;

        dodge = playerControls.Player.Dodge;
        dodge.Enable();
        dodge.performed += Dodge;
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = move.ReadValue<Vector2>();

        if (isDodging)
        {
            dodgeTimer += Time.deltaTime;
            if (dodgeTimer > dodgeDuration)
            {
                isDodging = false;
                dodgeTimer = 0;
            }
        }

        if (isSwinging)
        {
            weaponTimer += Time.deltaTime;
            if (weaponTimer > weaponDuration)
            {
                isSwinging = false;
                weaponTimer = 0;
                weapon.SetActive(false);
            }
        }

        if (currentHealth != playerHealth)
        {
            bc.enabled = false;
            currentHealth = playerHealth;
        }

        if (!bc.enabled)
        {
            iframeTimer += Time.deltaTime;
            if (iframeTimer > 1)
            {
                bc.enabled = true;
                iframeTimer = 0;
            }
        }

        if (playerHealth <= 0)
        {
            PlayerDeath();
        }

        
    }

    void FixedUpdate()
    {
        if (!isDodging)
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    void PlayerDeath()
    {
        Time.timeScale = 0;

    }

    private void Fire(InputAction.CallbackContext context)
    {
        if(!isSwinging)
        {
            isSwinging = true;
            weapon.SetActive(true);
        }
    }

    private void Dodge(InputAction.CallbackContext context)
    {
        isDodging = true;
        rb.velocity += new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    void OnDisable()
    {
        move.Disable();

        fire.Disable();

        dodge.Disable();
    }

    
}
