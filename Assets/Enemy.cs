using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Wave wave = null;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // This should be on the projectile later. Just for quick and dirty testing!
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player Projectile"))
        {
            Die();
        }
    }

    public void SetWave(Wave wave) => this.wave = wave;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die()
    {
        if (wave != null) wave.RegisterDeath();
        Destroy(gameObject);
    }
}
