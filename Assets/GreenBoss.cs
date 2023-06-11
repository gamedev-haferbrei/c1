using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBoss : MonoBehaviour
{
    [SerializeField] GameObject starProjectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StarBurst());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator StarBurst()
    {
        for (int burst = 0; burst < 3; burst++)
        {
            Vector3[] cannonPositions = new Vector3[]
            {
                new Vector3(-0.6f, -1f),
                new Vector3(-0.6f, +1f),
            };

            foreach (Vector3 cannonPosition in cannonPositions)
            {
                int anglesN = 6 + burst;
                float spanAngle = 74;
                for (int angle = 0; angle < anglesN; angle++)
                {
                    Instantiate(starProjectilePrefab, transform.position + cannonPosition, Quaternion.Euler(0, 0, angle * spanAngle / anglesN - spanAngle / 2));
                }
            }

            yield return new WaitForSeconds(0.7f);
        }
    }
}
