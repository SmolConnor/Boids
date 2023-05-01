using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidAgent : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
       
    }

    void Sepperation()
    {
        GameObject[] AI;
        AI = Boidtest.boidManager.boids;
        foreach (GameObject boy in AI)
        {
            if (boy != this.gameObject)
            {
                float distance = Vector2.Distance(boy.transform.position, this.transform.position);
                if (distance <= Boidtest.boidManager.spaceBetween)
                {
                    Vector2 direction = transform.position - boy.transform.position;
                    transform.Translate(direction * Time.deltaTime);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Sepperation();
    }
}
