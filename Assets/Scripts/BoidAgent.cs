using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidAgent : MonoBehaviour
{
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(Boidtest.boidManager.minSpeed, Boidtest.boidManager.maxSpeed);
    }



  

    // Update is called once per frame
    void Update()
    {
        
        ApplyRules();
        this.transform.Translate(0, speed*Time.deltaTime, 0);
      
        
    }
    void ApplyRules()
    {
        Vector3 vcentre = Vector3.zero;
        Vector3 vavoid = Vector3.zero;
        float gSpeed = 0.01f;
        int groupSize = 0;
        GameObject[] AI;
        AI = Boidtest.boidManager.boids;
        foreach (GameObject boy in AI)
        {
            if (boy != this.gameObject)
            {
                float distance = Vector2.Distance(boy.transform.position, this.transform.position);
                if (distance <= Boidtest.boidManager.neighborD)
                {
                    vcentre += boy.transform.position;
                    groupSize++;

                    if (distance < 1.0f)
                    {
                        vavoid = vavoid + (this.transform.position - boy.transform.position);
                    }

                    BoidAgent otheAgent = boy.GetComponent<BoidAgent>();
                    gSpeed = gSpeed + otheAgent.speed;
                }
            }
        }
        if (groupSize > 0)
        {
            vcentre = vcentre / groupSize;
            speed = gSpeed / groupSize;
            Vector2 direction2 = (vcentre + vavoid) - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction2), Boidtest.boidManager.rotation * Time.deltaTime);
        }
    }
}
