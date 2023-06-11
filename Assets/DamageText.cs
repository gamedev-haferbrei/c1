using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour
{
    TextMeshProUGUI text;
    string textToAssign;
    float creationTime;
    float totalLifetime = 1;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = textToAssign;
        creationTime = Time.time;
    }

    public void SetText(string newText) => textToAssign = newText; 

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime);

        float age = Time.time - creationTime;
        text.alpha = 1 - (age / totalLifetime);
        if (age >= totalLifetime)
        {
            Destroy(gameObject);
        }
    }
}
