using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour
{
    public static FlockManager FM;
    public GameObject sheepPrefab;
    public int numSheep = 10;
    public GameObject[] allSheep;
    public Vector3 roamLimit = new Vector3(2, 0, 2);
    public Vector3 goalPos = Vector3.zero;
    public GameObject player;

    [Header("Sheep Settings")]
    [Range(0.1f, 1.0f)]
    public float minSpeed;
    [Range(0.1f, 1.0f)]
    public float maxSpeed;
    [Range(0.1f, 10.0f)]
    public float neighbourDistance;
    [Range(0.1f, 1.0f)]
    public float rotationSpeed;


    // Start is called before the first frame update
    void Start()
    {
        allSheep = new GameObject[numSheep];
        for (int i = 0; i < numSheep; i++)
        {
            Vector3 pos = this.transform.position + new Vector3(Random.Range(-roamLimit.x, roamLimit.x),
                                                                Random.Range(-roamLimit.y, roamLimit.y),
                                                                Random.Range(-roamLimit.z, roamLimit.z));
            allSheep[i] = Instantiate(sheepPrefab, pos, Quaternion.identity);
        }
        FM = this;

        goalPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 100) < 10)
        {
            goalPos = this.transform.position + new Vector3(Random.Range(-roamLimit.x, roamLimit.x),
                                                                Random.Range(-roamLimit.y, roamLimit.y),
                                                                Random.Range(-roamLimit.z, roamLimit.z));

        }
    }
}
