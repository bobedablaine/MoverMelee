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
    private InputAction pause;
    private Vector2 moveDirection;
    private Rigidbody2D rb;
    public float playerHealth = 100;
    float currentHealth = 100;
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
    [SerializeField] GameObject deathScreen;
    [SerializeField] GameObject pauseScreen;
    [SerializeField] RectTransform healthbarForeGround;
    float healthbarMaxWidth = 247.58f;
    float maxHealth = 100f;
    private void Awake()
    {
        playerControls = new PlayerInputActions();
        rb = GetComponent<Rigidbody2D>();
        main = Camera.main;
        bc = GetComponent<BoxCollider2D>();
        Time.timeScale = 1;
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

        pause = playerControls.Player.Pause;
        pause.Enable();
        pause.performed += Pause;
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
            healthbarForeGround.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, healthbarMaxWidth * (playerHealth/maxHealth));
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
        deathScreen.SetActive(true);
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

    private void Pause(InputAction.CallbackContext context)
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
    }

    void OnDisable()
    {
        move.Disable();

        fire.Disable();

        dodge.Disable();
    }

    
}
