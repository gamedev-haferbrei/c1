using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunshinNoJutsu : MonoBehaviour
{
    [SerializeField] Player playerGO;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] AudioManager audioManager;


    public void ShootLaser()
    {
        Instantiate(laserPrefab, transform.position, Quaternion.Euler(0f, 0f, -90f));
        audioManager.LaserAudio();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LaserBarrage());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, Time.deltaTime*2, 0);
        if (transform.position.y > 5) { Destroy(this.gameObject); }
    }
    IEnumerator LaserBarrage()
    {
        while (true) 
        { 
            ShootLaser();
            yield return new WaitForSeconds(0.5f);
        }
        
    }
}
