using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveVehicle : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 1F;
    public float speed = 65f;
    public float timeAtBooth = 3f;
    public float tollCost = 2.5f;

    private bool leavingBooth = false;
    private float xVelocity = 1F;
    private float xPos;
    private bool pauseVehicle = false;

    public int scoreValue;
    private GameController gameController;

    void Start()
    {
        GameObject tollBoothObject = GameObject.FindWithTag("Toll Booth");
        target = tollBoothObject.GetComponent<Transform>();
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void Update()
    {
        if (!leavingBooth)
        {
            SlowOverTime();
        }
        else if (pauseVehicle)
        {
            StartCoroutine(ExampleCoroutine());
        }
        else if (leavingBooth)
        {
            SpeedUpOverTime();
        }
    }

    private void SpeedUpOverTime()
    {
        float newPosition = Mathf.SmoothDamp(transform.position.x, 600f, ref xVelocity, smoothTime + 1f);
        transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);
    }

    void SlowOverTime()
    {
        float newPosition = Mathf.SmoothDamp(transform.position.x, target.position.x, ref xVelocity, smoothTime);
        transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Toll Booth")
        {
            PayToll();
            leavingBooth = true;
            pauseVehicle = true;
        }

        if (other.tag == "Destructor")
        {
            Destroy(gameObject);
        }
    }

    private void PayToll()
    {
        print("paying toll");
        float costBasedOnVehicleType = getCost();
        gameController.AddScore(costBasedOnVehicleType);
    }

    private float getCost()
    {
        float cost = 0f;
        string tag = gameObject.tag.ToString();
        switch (tag)
        {
            case "car":
                cost = 2.5f;
                break;
            case "suv":
                cost = 3.5f;
                break;
            case "truck":
                cost = 5f;
                break;
            case "smuggler":
                cost = 15f;
                break;
            default:
                break;
        }
        return cost;
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(timeAtBooth);
        pauseVehicle = false;
    }
}