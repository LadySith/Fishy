using System.Collections;
using UnityEngine;

public class flock : MonoBehaviour
{
    public float speed = 0.001f;
    float rotationSpeed = 4.0f;
    Vector3 averageHeading;
    Vector3 averagePosition;
    float neighbourDistance = 3.0f;

    bool turning = false;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(0.5f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, globalFlock.centre) >= globalFlock.tankSize)
        {
            turning = true;
        }
        else
            turning = false;

        if (turning)
        {
            Vector3 direction = globalFlock.centre - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(direction),
                rotationSpeed * Time.deltaTime);
            speed = Random.Range(0.5f, 1);
        }
        else
        {
            //If fish flock too much, this can be reduced by increasing the maximum range
            if (Random.Range(0,5) < 1)
            {
                ApplyRules();
            }
            transform.Translate(0, 0, Time.deltaTime * speed);
        }
    }

    void ApplyRules()
    {
        GameObject[] gos;
        gos = globalFlock.allFish;

        Vector3 vcentre = globalFlock.centre;
        Vector3 vavoid = globalFlock.centre;
        float gSpeed = 0.1f;

        Vector3 goalPos = globalFlock.goalPos;

        float dist;
        int groupSize = 0;

        foreach (GameObject go in gos)
        {
            if(go != this.gameObject)
            {
                dist = Vector3.Distance(go.transform.position, this.transform.position);
                if(dist <= neighbourDistance)
                {
                    vcentre += go.transform.position;
                    groupSize++;

                    if(dist < 1.0f)
                    {
                        vavoid = vavoid + (this.transform.position - go.transform.position);
                    }

                    flock anotherFlock = go.GetComponent<flock>();
                    gSpeed += anotherFlock.speed;
                }
            }
        }

        if(groupSize > 0)
        {
            vcentre = vcentre/groupSize + (goalPos - this.transform.position);
            speed = gSpeed/groupSize;

            Vector3 direction = (vcentre + vavoid) - this.transform.position;
            if(direction != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
            }
        }
    }
}
