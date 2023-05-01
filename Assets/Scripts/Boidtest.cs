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
    
    // Start is called before the first frame update
    void Start()
    {
        boids = new GameObject[numBoid];
        for (int i = 0; i < numBoid; i++)
        {
            boids[i] = Instantiate(boidAgent, this.transform.position, this.transform.rotation);
        }
        boidManager = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
