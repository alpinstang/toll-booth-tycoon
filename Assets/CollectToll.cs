using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectToll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        print("collided");
    }

    void OnTriggerEnter(Collider collider)
    {
        print(collider.tag);
        print("trigger");
        SendMessage("OnEnterTollbooth");
    }
}
