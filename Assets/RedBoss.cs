using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBoss : MonoBehaviour
{
    [SerializeField] GameObject enemyLaser;
    // Start is called before the first frame update
    void Start()
    {
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
}
