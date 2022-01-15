using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;
    public Transform lastPlatform;
    Vector3 lastPosition;
    Vector3 newPosition;
    bool stop = false;
    public static PlatformSpawner instance;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = lastPlatform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartSpawningPlatforms()
    {
        StartCoroutine(SpawnPlatform());
    }

    IEnumerator SpawnPlatform()
    {
        while (!stop)
        {
            GeneratePosition();

            Instantiate(platform, newPosition, Quaternion.identity);

            lastPosition = newPosition;

            yield return new WaitForSeconds(0.1f);
        }
    }

    void GeneratePosition()
    {
        newPosition = lastPosition;

        int rand = Random.Range(0, 2);

        if (rand > 0)
        {
            newPosition.x += 2f;
        }
        else
        {
            newPosition.z += 2f;
        }
    }
}
