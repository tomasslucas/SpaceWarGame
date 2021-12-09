using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public GameObject Enemy_bullet; //this is the enemy bullet prefab

    // Start is called before the first frame update
    void Start()
    {
        //Fire a bullet after 1s
        Invoke("FireEnemyBullet", 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FireEnemyBullet()
    {
        //get a reference to the player ship
        GameObject playership = GameObject.Find("SpaceShip");

        if (playership != null) //if player is not dead
        {
            //instatiate a enemy bullet
            GameObject bullet = (GameObject)Instantiate(Enemy_bullet);

            //set the bullet initial position
            bullet.transform.position = transform.position;

            //compute the bullet to the direction of the player ship
            Vector2 direction = playership.transform.position - bullet.transform.position;

            //set the bullet diretion
            bullet.GetComponent<EnemyBullet>().SetDirection(direction);
        }
    }
}
