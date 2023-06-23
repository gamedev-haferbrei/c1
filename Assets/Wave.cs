using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    WaveManager waveManager = null;
    HashSet<Enemy> activeEnemies = new HashSet<Enemy>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (Enemy enemy in GetComponentsInChildren<Enemy>())
        {
            enemy.SetWave(this);
            enemy.SetDamageTextController(waveManager.GetDamageTextController());
            activeEnemies.Add(enemy);
        }
    }

    public void SetWaveManager(WaveManager waveManager) => this.waveManager = waveManager;

    public HashSet<Enemy> GetActiveEnemies() => activeEnemies;

    // Update is called once per frame
    void Update()
    {
    }

    public void RegisterDeath(Enemy enemy)
    {
        activeEnemies.Remove(enemy);
        if (activeEnemies.Count == 0)
        {
            waveManager.LoadNextWave();
            Destroy(gameObject);
        }
    }
}
