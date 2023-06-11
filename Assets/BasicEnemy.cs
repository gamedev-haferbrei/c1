using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5;
    [SerializeField] float shootingFrequency;
    [SerializeField] GameObject projectilePrefab;

    bool movingDown;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = movementSpeed * new Vector2(0, Random.Range(0, 1) == 1 ? 1 : -1);

        InvokeRepeating(nameof(Shoot), Random.Range(0f, shootingFrequency), shootingFrequency);
    }

    void Shoot()
    {
        Instantiate(projectilePrefab, transform.position, Quaternion.Euler(0f, 0f, -90f));
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider.gameObject.name);
        if (collider.gameObject.layer == LayerMask.NameToLayer("Walls"))
        {
            rb.velocity = -rb.velocity;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
