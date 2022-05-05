using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianMovement : MonoBehaviour
{
    public float timeToDirectionChange = 1;
    public float moveSpeed = 10;
    private Vector3 direction;
    float lastDirectionChange = 0;
    Rigidbody pedestrian;

    private void Start()
    {
        direction = (new Vector3(Random.Range(-1.0f, 1.0f), 0.0f, Random.Range(-1.0f, 1.0f))).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}
