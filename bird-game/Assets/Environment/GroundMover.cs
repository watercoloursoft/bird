using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMover : MonoBehaviour
{
    private float time = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    void UpdateGroundPosition()
    {
        transform.position = new Vector3(4 - time * 8, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime / 2;
        time %= 1f;
        UpdateGroundPosition();
    }
}
