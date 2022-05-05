using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianSpawner : MonoBehaviour
{
    public Rigidbody pedestrian;
    public float speed = 10;
    private List<Rigidbody> _clones = new List<Rigidbody>();

    void Start()
    {
        InvokeRepeating("SpawnNow", 10, 0.1f);
        _clones.Add(pedestrian);
    }

    void Update()
    {
        if (_clones.Count == 2000)
        {
            CancelInvoke();
        }
    }
    Vector3 getRandomPos()
    {
        float _x = Random.Range(-2000, 2000); //choose x position from random range
        float _y = 3.0f;
        float _z = Random.Range(-2000, 2000); //choose y position from random range

        Vector3 newPos = new Vector3(_x, _y, _z); //set the new position
        return newPos;
    }
    
    void SpawnNow()
    {
        Instantiate(pedestrian, getRandomPos(), Quaternion.identity); //spawn the pedestrian at the position specified
    }
}
