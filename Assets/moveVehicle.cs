using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveVehicle : MonoBehaviour
{
    public float speed = 10f;
    public int stoppedTime = 50;
    public bool stopped = false;
    int stoppedTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!stopped)
        {
            MoveCar();
        } else
        {
            stoppedTimer--;
            if(stoppedTimer == 0)
            {
                stopped = false;
                stoppedTimer = stoppedTime;
            }
        }
    }

    void MoveCar()
    {
        float xPos = transform.localPosition.x + speed * Time.deltaTime;
        transform.localPosition = new Vector3(xPos, transform.localPosition.y, transform.localPosition.z);
    }

    void CheckPosition()
    {
        
    }

    void OnEnterTollbooth()
    {
        stopped = true;
        stoppedTimer = stoppedTime;
        print("enter toll booth");
    }
}
