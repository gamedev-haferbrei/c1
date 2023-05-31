using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkipToWaveButtons : MonoBehaviour
{
    [SerializeField] GameObject skipToWaveButtonPrefab;
    [SerializeField] int waves = 15;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < waves; i++)
        {
            GameObject button = Instantiate(skipToWaveButtonPrefab, transform);
            button.GetComponentInChildren<TextMeshProUGUI>().text = $"{i}";
            button.GetComponent<PlayButton>().requestedWave = i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
