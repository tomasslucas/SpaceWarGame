using UnityEngine;

public class StarControl : MonoBehaviour
{
    public float speed; //Speed of the star

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Get enemy current position
        Vector2 position = transform.position;

        //New position
        position = new Vector2(position.x, position.y + speed * Time.deltaTime);

        //update enemy position
        transform.position = position;

        //Botton left point of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //Top right point of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        if (transform.position.y < min.y)
        {
            //Get the star back on the top of the screen but in a random position
            transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
        }
    }
}
