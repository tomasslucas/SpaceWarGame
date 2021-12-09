using UnityEngine;

public class AsteroideControl : MonoBehaviour
{
    public GameObject Explosion; //Explosion Prefab

    float speed; //For the asteroide speed
    // Start is called before the first frame update
    void Start()
    {
        speed = 5f; //set speed
    }

    // Update is called once per frame
    void Update()
    {
        //Get enemy current position
        Vector2 position = transform.position;

        //New position
        position = new Vector2(position.x, position.y - speed * Time.deltaTime);

        //update enemy position
        transform.position = position;

        //Botton left conner of the camera
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Detect the collision with other things and what happens if that colision happens
        if ((col.tag == "PlayerBullet") || (col.tag == "PlayerShip"))
        {
            PlayExplosion();

            Destroy(gameObject);
        }
    }

    //Function to initiate the explosion animation
    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(Explosion);

        //Set position of the explosion
        explosion.transform.position = transform.position;
    }
}
