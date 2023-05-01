using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boidtest : MonoBehaviour
{
    public GameObject[] boids;
    public GameObject boidAgent;
    public int numBoid;
    public static Boidtest boidManager;
    public Vector3 randomrotation;
    public float spaceBetween = 1.5f;
    public Vector2 spawnLimits = new Vector2(5, 5);
    public Vector2 foodpos = Vector2.zero;
    public bool isfood = false;
    public GameObject food;
    [Header("the boys")]
    [Range(0.0f, 10.0f)]
    public float minSpeed;
    [Range(0.0f, 10.0f)]
    public float maxSpeed;
    [Range(1.0f, 15.0f)]
    public float neighborD;
    [Range(1.0f, 5.0f)]
    public float rotation;

    // Start is called before the first frame update
    void Start()
    {
        randomrotation = new Vector3(0, 0, Random.Range(-180, 180));
        boids = new GameObject[numBoid];
        for (int i = 0; i < numBoid; i++)
        {
            Vector2 pos = (Vector2)this.transform.position + new Vector2(Random.Range(-spawnLimits.x, spawnLimits.x), Random.Range(-spawnLimits.y, spawnLimits.y));
            boids[i] = Instantiate(boidAgent, pos, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
        }
        boidManager = this;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Random.Range(0,10000)< 10)
        {
            if (isfood == false)
            {
                foodpos = (Vector2)this.transform.position + new Vector2(Random.Range(-spawnLimits.x, spawnLimits.x ), Random.Range(-spawnLimits.y , spawnLimits.y ));
                Instantiate(food, foodpos, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
                isfood = true;
            }
        }
    }
}
