using UnityEngine;
using UnityEngine.UI;

public class Player_Control : MonoBehaviour
{
    public GameObject GameManager; //reference to our Game Manager
    //To implement the shield
    private bool shielded;
    [SerializeField]
    private GameObject shield;
    //This could be just a "public GameOject shield;"

    public Transform firePoint; //Where the bullet appears
    public GameObject bulletPrefab; //Bullet Prefab
    public GameObject Explosion; //Explosion Prefab

    //Forces
    public float bulletForce = 20f;
    public float moveSpeed = 5f;

    //Movement
    public Rigidbody2D rb;
    Vector2 movement;

    //Lives
    public Text LivesUIText;
    const int MaxLives = 3; //Player lives (max)
    int Lives; //Cuurent player lives

    //Don't let the ship get off screen
    float ShipBondaryRadius = 1f;

    //Sound
    public AudioSource Sound; //Get audio source sound

    public void Init()
    {
        Lives = MaxLives;

        //Update the lives UI text
        LivesUIText.text = Lives.ToString();

        //Reset the player position
        transform.position = new Vector2(0, -4);

        //Set the player lives to active
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if shield is up
        CheckShield();

        // Horizontal Movement
        movement.x = Input.GetAxisRaw("Horizontal");

        // For vertical implent below
        //movement.y = Input.GetAxisRaw("Vertical");

        //Get the spaceship position
        Vector2 position = transform.position;

        //Make the camera bounderies
        float ScreenRatio = (float)Screen.width / (float)Screen.height;
        float width0rtho = Camera.main.orthographicSize * ScreenRatio;

        //Restrict the ship movement base on camera bounderies (x)
        if (position.x + ShipBondaryRadius > width0rtho)
        {
            position.x = width0rtho - ShipBondaryRadius;
        }
        if (position.x - ShipBondaryRadius < -width0rtho)
        {
            position.x = -width0rtho + ShipBondaryRadius;
        }

        //Set new spaceship position
        transform.position = position;

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
    }
    void Shoot()
    {
        //Play the bullet sound effect
        Sound.Play();

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); //Instatiate bullet prefab
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>(); //Get Rigidbody of the bullet
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse); //Add force to the bullet rigidbody
    }

    //Function for the shield
    void CheckShield()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && !shielded)
        {
            shield.SetActive(true);
            shielded = true;
            //Code to turn off shield
            Invoke("NoShield", 3f);
        }
    }
    void NoShield()
    {
        shield.SetActive(false);
        shielded = false;
    }

    //Collisions
    void OnTriggerEnter2D(Collider2D col)
    {
        //Detect the collision with other things and what happens if that colision happens
        if ((col.tag == "EnemyShip") || (col.tag == "EnemyBullet") || (col.tag == "Other_things"))
        {
            if (!shielded)
            {
                PlayExplosion();

                Lives--; //subtract one live
                LivesUIText.text = Lives.ToString(); //Update lives UI text

                if (Lives == 0) // If the player don't have lives left
                {
                    //Change Game State to GameOver State;
                    GameManager.GetComponent<GameManager>().SetGameManagerState(global::GameManager.GameManagerState.GameOver);

                    //Hide the player ship
                    gameObject.SetActive(false);
                }

            }
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
