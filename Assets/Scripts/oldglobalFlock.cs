using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalFlock : MonoBehaviour
{
    public GameObject fishPrefab;
    public GameObject goalPrefab;
    public static int tankSize = 20;

    public static Vector3 centre = new Vector3(0, -tankSize, 0);

    static int numFish = 30;
    public static GameObject[] allFish = new GameObject[numFish];

    public static Vector3 goalPos = centre;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numFish; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-tankSize + centre.x, tankSize + centre.x),
                                        Random.Range(-tankSize + centre.y, tankSize + centre.y),
                                        Random.Range(-tankSize + centre.z, tankSize + centre.z));
            allFish[i] = (GameObject)Instantiate(fishPrefab, pos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Changes goalPos every 50 in 10000 times
        if (Random.Range(1,10000) < 50)
        {
            goalPos = new Vector3(Random.Range(-tankSize + centre.x, tankSize + centre.x),
                                        Random.Range(-tankSize + centre.y, tankSize + centre.y),
                                        Random.Range(-tankSize + centre.z, tankSize + centre.z));
            //goal marker
            goalPrefab.transform.position = goalPos;
        }
    }
}
