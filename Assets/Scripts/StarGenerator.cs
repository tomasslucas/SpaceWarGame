using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour
{
    public GameObject star; //Star prefab
    public int MaxStars; //The max of stars in the screen

    // Start is called before the first frame update
    void Start()
    {
        //Botton left point of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //Top right point of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //loop to create stars
        for (int i = 0; i < MaxStars; ++i)
        {
            GameObject Star = (GameObject)Instantiate(star);
            //Set the star position
            Star.transform.position = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));

            //Set random speed of the star
            Star.GetComponent<StarControl>().speed = -(1f * Random.value + 0.5f);
        }

        //Set the star a child of Star Generator
        star.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
