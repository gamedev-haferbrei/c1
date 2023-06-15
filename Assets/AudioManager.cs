using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] public AudioSource backgroundSource;
    [SerializeField] public AudioSource sounds;
    [SerializeField] public AudioClip laserSound;
    [SerializeField] public AudioClip playerHitSound;
    [SerializeField] public AudioClip godMode;
    [SerializeField] public AudioClip background;
    [SerializeField] public AudioClip enemyHitSound;
    // Start is called before the first frame update
    public void LaserAudio()
    {
        sounds.PlayOneShot(laserSound, 0.75f);
    }

    public void EnemyAudio()
    {
        sounds.PlayOneShot(enemyHitSound, 0.75f);
    }

    public void PlayerAudio()
    {
        sounds.PlayOneShot(playerHitSound, 0.75f);
    }

    public void GodModeAudio()
    {
        //sounds.clip = godMode;
        //backgroundSource.Play();
        sounds.PlayOneShot(godMode, 0.75f);
    }

    public void BackgroundAudio()
    {
        backgroundSource.clip = background;
        backgroundSource.Play();
    }

     void Start()
     {
        gameObject.tag = "AudioManager";

    }

     /*// Update is called once per frame
     void Update()
     {

     }*/
}
