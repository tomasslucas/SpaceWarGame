using UnityEngine;

public class AsteroideControl : MonoBehaviour
{
    public GameObject scoreTextUI; //Reference to score text UI;

    public GameObject Explosion; //Explosion Prefab

    float speed; //For the asteroide speed
    // Start is called before the first frame update
    void Start()
    {
        speed = 8f; //set speed

        //Get the score text tag
        scoreTextUI = GameObject.FindGameObjectWithTag("ScoreTextTag");
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
            PlayExplosion(); //Play Explosion animation

            //add 10 point to the score
            scoreTextUI.GetComponent<GameScore>().Score += 10;

            //Destoy this gameobject (asteoride)
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
