using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    [SerializeField]
    private GameObject pipePrefab;

    private float pipeSpawnPeriod = 4f;   // кожні 4 секунди
    private float pipeCountdown;

    void Start()
    {
        pipeCountdown = pipeSpawnPeriod;
        SpawnPipe();
    }
    void Update()
    {
        pipeCountdown -= Time.deltaTime;
        if(pipeCountdown <= 0)
        {
            pipeCountdown = pipeSpawnPeriod;
            SpawnPipe();
        }
    }
    private void SpawnPipe()
    {
        var pipe = GameObject.Instantiate(pipePrefab);  // ~ new pipePrefab
        pipe.transform.position = 
            this.transform.position + 
                Vector3.up * Random.Range(-1.7f, 1.7f);
    }
}
/* Д.З. Реалізувати декілька префабів з різним проміжком між
 * компонентами труби. При генерації труб випадково обирати
 * один з префабів.
 */