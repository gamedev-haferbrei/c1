using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTextController : MonoBehaviour
{
    [SerializeField] GameObject damageTextPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void DrawText(Vector3 position, string text)
    {
        GameObject textGO = Instantiate(damageTextPrefab, position, Quaternion.identity, transform);
        textGO.GetComponent<DamageText>().SetText(text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
