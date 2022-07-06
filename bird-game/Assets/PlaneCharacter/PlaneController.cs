using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float heightIncrease = 1f;
    public float tiltScale = 3f;
    public float gravity = -3f;

    private float yVelocity = 0f;

    bool IsRequestingJump()
    {
        return Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.touchCount > 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameState.instance.IsPlaying)
            return;
        yVelocity += gravity * Time.deltaTime;
        if (IsRequestingJump())
        {
            yVelocity = Mathf.Sqrt(heightIncrease * -2f * gravity);
        }
        transform.rotation = Quaternion.Euler(0, 0, yVelocity * tiltScale);
        transform.position += new Vector3(0, yVelocity * Time.deltaTime, 0);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ignore"))
            return;
        GameState.instance.Reload();
    }
}
