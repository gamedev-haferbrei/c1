using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Wave wave = null;
    DamageTextController damageTextController;

    [SerializeField] int hp = 3;
    //[SerializeField] GameObject audioGO;

    //[SerializeField] AudioManager audioManager;
    //AudioManager audioManagerIns;
    // [SerializeField] AudioSource source;
    //[SerializeField] AudioClip clip;
    //GameObject[] audioManager;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    public void Damage(int amount)
    {
        GameObject audioManagerF = GameObject.FindWithTag("AudioManager");
        AudioManager audioManager = audioManagerF.GetComponent<AudioManager>();
        //AudioManager audioManagerF = System.Convert.ToAudioManager(audioManager);
        //AudioManager audioManagerF = (AudioManager)audioManager;
        audioManager.EnemyAudio();
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
