using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScript : MonoBehaviour
{
    public float speed; //speed of the object
    public bool isMoving; //flag to make the planet go down the screen

    Vector2 min; //botton left of the screen
    Vector2 max; //top right of the screen

    private void Awake()
    {
        isMoving = false;
        
        min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //add the planet sprite half height to max y
        max.y = max.y + GetComponent<SpriteRenderer>().sprite.bounds.extents.y;

        //subtract the planet sprite half height to min y
        min.y = min.y + GetComponent<SpriteRenderer>().sprite.bounds.extents.y;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving)
            return;

        //Get the current position of the planet
        Vector2 position = transform.position;

        //Compute new planet position
        position = new Vector2(position.x, position.y + speed * Time.deltaTime);

        //Update planet position
        transform.position = position;

        if (transform.position.y < min.y)
        {
            isMoving = false;
        }

    }

    public void ResetPosition()
    {
        //Where it spawns
        transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
    }
}
