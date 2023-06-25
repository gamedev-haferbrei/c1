using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBoss : MonoBehaviour
{
    [SerializeField] GameObject enemyLaser;
    Rigidbody2D rb;
    float movementSpeed = 4;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = movementSpeed * new Vector2(0, Random.Range(0, 1) == 1 ? 1 : -1);
        InvokeRepeating(nameof(ShootLaser), /*Random.Range(0f, shootingFrequency)*/ 1 , 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ShootLaser()
    {
        Instantiate(enemyLaser, new Vector3(transform.position.x + Random.Range(-2f, 2f), 6f), Quaternion.identity);
        Instantiate(enemyLaser, new Vector3(transform.position.x + Random.Range(-2f, 2f), 4.5f), Quaternion.identity);
        Instantiate(enemyLaser, new Vector3(transform.position.x + Random.Range(-2f, 2f), 3f), Quaternion.identity);
        Instantiate(enemyLaser, new Vector3(transform.position.x + Random.Range(-2f, 2f), 1.5f), Quaternion.identity);
        Instantiate(enemyLaser, new Vector3(transform.position.x + Random.Range(-2f, 2f), 0f), Quaternion.identity);
        Instantiate(enemyLaser, new Vector3(transform.position.x + Random.Range(-2f, 2f), -1.5f), Quaternion.identity);
        Instantiate(enemyLaser, new Vector3(transform.position.x + Random.Range(-2f, 2f), -3f), Quaternion.identity);
        Instantiate(enemyLaser, new Vector3(transform.position.x + Random.Range(-2f, 2f), -4.5f), Quaternion.identity);
        Instantiate(enemyLaser, new Vector3(transform.position.x + Random.Range(-2f, 2f), -6f), Quaternion.identity);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider.gameObject.name);
        if (collider.gameObject.layer == LayerMask.NameToLayer("Walls"))
        {
            rb.velocity = -rb.velocity;
        }
    }
}
