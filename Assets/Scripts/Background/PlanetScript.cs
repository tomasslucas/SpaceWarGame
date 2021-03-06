using UnityEngine;
using System.Collections;

public class PlanetScript : MonoBehaviour
{
    public float speed; //speed of the object
    public bool isMoving; //flag to make the planet go down the screen
    public float PlusY; //How much height you need to add to the planets position (The normal is *2)

    Vector2 min; //botton left of the screen
    Vector2 max; //top right of the screen

    void Awake()
    {
        isMoving = false;

        min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //add the planet sprite half height to max y
        //max.y = max.y + GetComponent<SpriteRenderer>().sprite.bounds.extents.y;
        //Because it was not working, I set it manually
        max.y = max.y + PlusY;

        //subtract the planet sprite half height to min y
        //min.y = min.y - GetComponent<SpriteRenderer>().sprite.bounds.extents.y
        min.y = min.y - PlusY;
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
