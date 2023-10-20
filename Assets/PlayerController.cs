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
    private Rigidbody2D wrb;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float dodgeDuration = 2f;
    [SerializeField] private float dodgeTimer = 0f;
    [SerializeField] float weaponDuration = 2f;
    [SerializeField] private float weaponTimer = 0f;
    [SerializeField] GameObject weapon;
    bool isDodging = false;
    bool isSwinging = false;
    private Vector2 mousePos;
    private void Awake()
    {
        playerControls = new PlayerInputActions();
        rb = GetComponent<Rigidbody2D>();
        main = Camera.main;
        //wrb = GetComponentInChildren<Rigidbody2D>();
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
        
        mousePos = main.ScreenToWorldPoint(Input.mousePosition);

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        //convert the input into an angle in radians, and convert that into degrees
        float rads = Mathf.Atan2(y, x);
        float degrees = rads * Mathf.Rad2Deg;

        //use trig to position sword
        weapon.transform.localPosition = new Vector3(Mathf.Cos(rads) * 1, 0, Mathf.Sin(rads) * 1); 

        weapon.transform.localEulerAngles = new Vector3(0, -degrees + 90, 0);
    }

    void FixedUpdate()
    {
        if (!isDodging)
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        
        //Vector2 lookDir = mousePos - rb.position;
        //float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        //wrb.rotation = angle;
        //weapon.transform.localPosition = new Vector3(lookDir.x, lookDir.y, 0);
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
        rb.velocity += new Vector2(moveDirection.x * moveSpeed * 100 * Time.deltaTime, moveDirection.y * moveSpeed);
    }

    void OnDisable()
    {
        move.Disable();

        fire.Disable();

        dodge.Disable();
    }
}
