using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public float interval = 0.5f;

    private float elapsed = 0f;
    [SerializeField]
    private GameObject obstaclePrefab;
    [SerializeField]
    private List<ObstacleData> data;

    // Start is called before the first frame update
    void Start()
    {

    }

    void SpawnObstacle()
    {
        var random = Random.Range(0, data.Count);
        var obstacle = Instantiate(obstaclePrefab, new Vector3(5f, 0, 0), Quaternion.identity, transform);
        // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
        obstacle.GetComponent<Obstacle>().data = data[random];
        // obstacle.transform.position = new Vector3(5, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if (!(elapsed >= interval)) return;
        elapsed -= interval;
        // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
        SpawnObstacle();
    }
}
