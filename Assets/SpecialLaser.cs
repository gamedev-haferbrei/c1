using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialLaser : MonoBehaviour
{
    //[SerializeField] float timeToLive = 10f;

    [SerializeField] float damageCooldown = 0.1f;
    float currentCooldown = 0f;
    [SerializeField] int damage = 1;
    Rigidbody2D rb;
    float y;
    float timeElapsed;
    float x;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        y = transform.position.y;
        x = transform.position.x;
        timeElapsed = 0;

    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (currentCooldown > 0 || collider.gameObject.layer != LayerMask.NameToLayer("Enemy")) return;

        currentCooldown = damageCooldown;
        Enemy enemy = collider.gameObject.GetComponent<Enemy>();
        enemy.Damage(damage);
    }

    // Update is called once per frame
    void Update()
    {
        // rb.velocity = Vector2.left * Mathf.Sin(transform.position.x) * Time.deltaTime * 1000;
        //Vector3 sinusCurve = new Vector3(transform.position.x, Mathf.Sin(transform.position.x) * 10);
        //rb.MovePosition(transform.position - sinusCurve * Time.deltaTime * 10);
        //rb.velocity = new Vector2(transform.position.x, y + Mathf.Sin(Time.deltaTime * 10));
        timeElapsed += Time.deltaTime;
        transform.position = new Vector2(x, y + Mathf.Sin(timeElapsed * 5) * 5);
        x += 0.05f;
        

    }
}
