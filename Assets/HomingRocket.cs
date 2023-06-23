using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingRocket : MonoBehaviour
{
    [SerializeField] float timeToLive = 10f;

    [SerializeField] float damageCooldown = 0.1f;
    float currentCooldown = 0f;
    [SerializeField] int damage = 1;

    GameObject target;
    WaveManager waveManager = null;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        waveManager = GameObject.FindGameObjectWithTag("WaveManager").GetComponent<WaveManager>();   

        rb = GetComponent<Rigidbody2D>();
    }

    void SeekNewTarget()
    {
        var enumerator = waveManager.GetActiveWave().GetActiveEnemies().GetEnumerator();
        if (enumerator.MoveNext())
        {
            target = enumerator.Current.gameObject;
        }
        enumerator.Dispose();
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
        rb.velocity = transform.rotation * Vector2.up * 6;

        if (target == null) SeekNewTarget();
        else
        {
            Vector3 targetDirection = target.transform.position - transform.position;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Vector3.forward, targetDirection), 0.03f);
        }

        currentCooldown = Mathf.Max(0f, currentCooldown - Time.deltaTime);
        timeToLive -= Time.deltaTime;
        if (timeToLive <= 0f) Destroy(gameObject);
    }
}
