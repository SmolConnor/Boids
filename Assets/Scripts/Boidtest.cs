using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boidtest : MonoBehaviour
{
    public GameObject[] boids;
    public GameObject boidAgent;
    public int numBoid;
    public static Boidtest boidManager;
    public float spaceBetween = 1.5f;
    public Vector2 spawnLimits = new Vector2(5, 5);
    [Header("the boys")]
    [Range(0.0f, 5.0f)]
    public float minSpeed;
    [Range(0.0f, 5.0f)]
    public float maxSpeed;
    [Range(1.0f, 10.0f)]
    public float neighborD;
    [Range(1.0f, 5.0f)]
    public float rotation;

    // Start is called before the first frame update
    void Start()
    {
        boids = new GameObject[numBoid];
        for (int i = 0; i < numBoid; i++)
        {
            Vector2 pos = (Vector2)this.transform.position + new Vector2(Random.Range(-spawnLimits.x, spawnLimits.x), Random.Range(-spawnLimits.y, spawnLimits.y));
            boids[i] = Instantiate(boidAgent, pos, this.transform.rotation);
        }
        boidManager = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
