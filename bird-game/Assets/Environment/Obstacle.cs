using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public enum ObstacleType
    {
        Top,
        Bottom
    };

    public float xCutoff = -5f;
    public float startX = 5f;
    public float gap = 2.4f;

    public float speed = 1f;
    public ObstacleData data;

    [SerializeField]
    private SpriteRenderer spr;
    [SerializeField]
    private Transform obstacle;

    // Start is called before the first frame update
    void Start()
    {
        spr.sprite = data.sprite;
        var random = Random.Range(1f, 1.5f);
        transform.position = new Vector3(startX, (data.type == ObstacleType.Top ? -1 : 1) * random * gap, 0);
        obstacle.localPosition = new Vector3(0, (data.type == ObstacleType.Top ? 1 : -1) * 1.19f, 0);
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position += Vector3.left * (speed * Time.deltaTime);
        if (transform.position.x < xCutoff)
        {
            Destroy(gameObject);
        }
    }
}
