using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    [SerializeField] InputAction movementControls;
    [SerializeField] InputAction basicShootControls;
    // For the special attack controls look at Special Attack UI in the hierarchy

    [SerializeField] WaveManager waveManager;

    [SerializeField] GameObject laserPrefab;

    Vector2 moveDirection;
    Rigidbody2D rb;

    private void OnEnable()
    {
        movementControls.Enable();
        basicShootControls.Enable();

        basicShootControls.performed += ctx => ShootLaser();
    }

    private void OnDisable()
    {
        movementControls.Disable();
        basicShootControls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = movementControls.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDirection * moveSpeed;
    }

    public void ShootLaser()
    {
        Instantiate(laserPrefab, transform.position, Quaternion.Euler(0f, 0f, -90f));
    }

    public void ShootTripleLaser()
    {
        Instantiate(laserPrefab, transform.position + new Vector3(-0.3f, -0.3f), Quaternion.Euler(0f, 0f, -90f));
        Instantiate(laserPrefab, transform.position, Quaternion.Euler(0f, 0f, -90f));
        Instantiate(laserPrefab, transform.position + new Vector3(-0.3f, 0.3f), Quaternion.Euler(0f, 0f, -90f));
    }

    // This just kills the player in all cases, but maybe the player could have HP as well? Might get too complicated
    public void Damage(int damage)
    {
        waveManager.GameOver();
    }
}
