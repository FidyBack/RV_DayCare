using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ball;
    void Start()
    {
        Instantiate(ball, transform.position, Quaternion.identity);
    }
}
