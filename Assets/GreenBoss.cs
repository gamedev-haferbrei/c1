using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBoss : MonoBehaviour
{
    [SerializeField] GameObject starProjectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AttackLoop());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator AttackLoop()
    {
        while (true)
        {
            yield return StartCoroutine(StarBurst());
            yield return new WaitForSeconds(1f);
            yield return StartCoroutine(SinePattern());
            yield return new WaitForSeconds(1f);
        }
    }

    Vector3[] cannonPositions = new Vector3[]
    {
        new Vector3(-1.4f, -2f),
        new Vector3(-1.4f, +2f),
    };

    IEnumerator StarBurst()
    {
        for (int burst = 0; burst < 3; burst++)
        {
            foreach (Vector3 cannonPosition in cannonPositions)
            {
                int anglesN = 3 + burst;
                float spanAngle = 74;
                for (int angle = 0; angle < anglesN; angle++)
                {
                    Instantiate(starProjectilePrefab, transform.position + cannonPosition, Quaternion.Euler(0, 0, angle * spanAngle / anglesN - spanAngle / 2));
                }
            }

            yield return new WaitForSeconds(0.7f);
        }
    }

    IEnumerator SinePattern()
    {
        float totalTimeElapsed = 0;
        float timeSinceLastStar = 0;

        const float totalSineTime = 8f;
        const float timeBetweenStars = 0.3f;

        Vector3 origin = transform.position;

        while (true)
        {
            yield return null;

            totalTimeElapsed += Time.deltaTime;
            timeSinceLastStar += Time.deltaTime;

            transform.position = origin + new Vector3(0, 4 * Mathf.Sin(totalTimeElapsed / totalSineTime * 3 * Mathf.PI));

            if (totalTimeElapsed > totalSineTime) break;
            if (timeSinceLastStar < timeBetweenStars) continue;    
            
            timeSinceLastStar -= timeBetweenStars;

            foreach (Vector3 cannonPosition in cannonPositions)
            {
                Instantiate(starProjectilePrefab, transform.position + cannonPosition, Quaternion.identity);
            }

        }

        transform.position = origin;
    }
}
