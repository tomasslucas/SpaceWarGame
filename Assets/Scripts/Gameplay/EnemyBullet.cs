using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    float speed; //the bullet speed
    Vector2 _direction; //the direction of the bullet
    bool isReady; // to know when the bullet direction is set

    private void Awake()
    {
        speed = 5f;
        isReady = false;
    }

    //function to set the direction of the bullet
    public void SetDirection(Vector2 direction)
    {
        //set the direction normalized, to get a unit vector
        _direction = direction.normalized;

        isReady = true; //set flag to true
    }

    // Update is called once per frame
    void Update()
    {
        if (isReady)
        {
            //Get the bullet current position
            Vector2 position = transform.position;

            //compute the bullet new position
            position += _direction * speed * Time.deltaTime;

            //update bullet new position
            transform.position = position;

            //Remove the bullet if it gets outside of the screen
            //Botton left conner of the camera
            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

            //Top-right point of the screen
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

            //destroy the bullet if it wents outside of the screen
            if ((transform.position.x < min.x) || (transform.position.x > max.x) ||
                (transform.position.y < min.y) || (transform.position.y > max.y))
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Detect the collision with other things and what happens if that colision happens
        if (col.tag == "PlayerShip")
        {
            Destroy(gameObject);
        }
    }
}
