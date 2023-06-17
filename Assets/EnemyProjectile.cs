using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] int damage = 1;
    bool godmode = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (!godmode)
            {
               
                Player player = collider.gameObject.GetComponent<Player>();
                player.Damage(damage);
                Destroy(gameObject);
            }
        }
    }
    /*public void Godmode()
    {
        if (Input.GetKeyDown("g"))
        {
            //audioManager.GodModeAudio();
            godmode = !godmode;
            Debug.Log("godmode on");
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("g"))
        {
            //audioManager.GodModeAudio();
            godmode = !godmode;
            Debug.Log("godmode on");
        }

    }
}
