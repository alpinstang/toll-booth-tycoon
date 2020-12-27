using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnVehicles : MonoBehaviour
{
    public GameObject prefab;
    float time = 5f;
    bool creating = false;

    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!creating)
        {
            time = UnityEngine.Random.Range(5f, 15f);
            randomVehicle();
        }
    }

    private void randomVehicle()
    {
        creating = true;
        Invoke("CreateVehicleInstance", time);
    }

    void CreateVehicleInstance()
    {
        Instantiate(prefab, new Vector3(50f, 1.5f, 250f), Quaternion.identity);
        creating = false;
    }
}
