using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveManager : MonoBehaviour
{
    [SerializeField] GameObject[] wavePrefabs;
    [SerializeField] DamageTextController damageTextController;

    Wave activeWave;
    int currentWave = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentWave = Globals.requestedWave;
        LoadCurrentWave();
    }

    public DamageTextController GetDamageTextController() => damageTextController;

    public void LoadNextWave()
    {
        currentWave++;
        LoadCurrentWave();
    }

    void LoadCurrentWave()
    {
        if (currentWave >= wavePrefabs.Length)
        {
            GameOver();
            return;
        }

        GameObject waveGO = Instantiate(wavePrefabs[currentWave], transform.position, Quaternion.identity, transform);
        activeWave = waveGO.GetComponent<Wave>();
        activeWave.SetWaveManager(this);
    }

    public void GameOver()
    {
        int toBeat = PlayerPrefs.HasKey("Highscore") ? PlayerPrefs.GetInt("Highscore") : 0;
        if (currentWave > toBeat) PlayerPrefs.SetInt("Highscore", currentWave);

        SceneManager.LoadScene("Menu");
    }

    public Wave GetActiveWave() => activeWave;

    // Update is called once per frame
    void Update()
    {
        
    }
}
