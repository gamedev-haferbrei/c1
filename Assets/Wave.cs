using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    WaveManager waveManager = null;
    int liveEnemies = 0;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Enemy enemy in GetComponentsInChildren<Enemy>())
        {
            enemy.SetWave(this);
            enemy.SetDamageTextController(waveManager.GetDamageTextController());
            liveEnemies++;
        }
    }

    public void SetWaveManager(WaveManager waveManager) => this.waveManager = waveManager;

    // Update is called once per frame
    void Update()
    {
    }

    public void RegisterDeath()
    {
        liveEnemies--;
        if (liveEnemies == 0)
        {
            waveManager.LoadNextWave();
            Destroy(gameObject);
        }
    }
}
