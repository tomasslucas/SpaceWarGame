using System.Collections.Generic; // for Queue
using System.Collections;
using UnityEngine;

public class PlanetControl : MonoBehaviour
{
    public GameObject[] Planets; //an array of the planet Prefab

    //queue to hold the planets
    Queue<GameObject> availablePlanets = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        //Had the planets to the queue (enqueue them)
        availablePlanets.Enqueue(Planets[0]);
        availablePlanets.Enqueue(Planets[1]);
        availablePlanets.Enqueue(Planets[2]);

        InvokeRepeating("MovePlanetDown", 0, 20f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Function to Dequeue the planet and set the flag isMoving to true
    //So that the planet scrols down the screen
    void MovePlanetDown()
    {
        EnqueuePlanets();

        //If the queue is empty then return
        if (availablePlanets.Count == 0)
            return;

        //get a planet from the queue
        GameObject aPlanet = availablePlanets.Dequeue();

        //set the isMoving flag to true
        aPlanet.GetComponent<PlanetScript>().isMoving = true;
    }

    void EnqueuePlanets()
    {
        foreach (GameObject aPlanet in Planets)
        {
            //If the planet is below the screen and not moving
            if ((aPlanet.transform.position.y < 0) && (!aPlanet.GetComponent<PlanetScript>().isMoving))
            {
                //Reset the planet position
                aPlanet.GetComponent<PlanetScript>().ResetPosition();

                //Enqueue the planet
                availablePlanets.Enqueue(aPlanet);
            }
        }
    }
}
