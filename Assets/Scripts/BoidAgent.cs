using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidAgent : MonoBehaviour
{
    float speed;
    bool turning = false;
    public Collider2D fishcollider;
    // Start is called before the first frame update
    void Start()
    {

        speed = Random.Range(Boidtest.boidManager.minSpeed, Boidtest.boidManager.maxSpeed);
    }

    void OnTriggerEnter2D(Collider2D  col)
    {
        if(col.gameObject.CompareTag(("food")))
        {
            Destroy(col.gameObject);
            Boidtest.boidManager.isfood = false;
        }
    
    
    }


        // Update is called once per frame
        void Update()
    {
        GameObject[] AI;
        AI = Boidtest.boidManager.boids;
        Bounds b = new Bounds(Boidtest.boidManager.transform.position, Boidtest.boidManager.spawnLimits * 2);
        if (!b.Contains(transform.position))
        {
            turning = true;
        }
        else
        {
            turning = false;
        }
        if (turning == true)
        {
            Vector3 direction = Boidtest.boidManager.transform.position - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward, direction), Boidtest.boidManager.rotation * Time.deltaTime);
        }
        else
        {
            if (Random.Range(0, 100) < 10)
            {


                ApplyRules();
            }
        }
        this.transform.Translate(0, speed * Time.deltaTime, 0);
       
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
            if (Boidtest.boidManager.isfood == true)
            {
                vcentre = vcentre / groupSize + ((Vector3)Boidtest.boidManager.foodpos - this.transform.position); //+ ((Vector3)Boidtest.boidManager.food - this.transform.position)
            }
            else
                vcentre = vcentre / groupSize;


            speed = gSpeed / groupSize;
            Vector3 direction2 = (vcentre + vavoid) - transform.position;
            
            
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward, direction2), Boidtest.boidManager.rotation * Time.deltaTime);
        }
    }
}
