using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Wave wave = null;
    DamageTextController damageTextController;

    [SerializeField] int hp = 3;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // This should be on the projectile later. Just for quick and dirty testing!
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player Projectile"))
        {
            Damage(1);
        }
    }

    public void Damage(int amount)
    {
        hp -= amount;
        damageTextController.DrawText(transform.position, amount.ToString());
        if (hp <= 0) Die();
    }

    public void SetWave(Wave wave) => this.wave = wave;
    public void SetDamageTextController(DamageTextController damageTextController) => this.damageTextController = damageTextController;

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
