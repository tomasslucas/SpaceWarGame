using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    void Awake()
    {
        Destroy(gameObject, 3);
    }
    void Update()
    {
        //top-right point of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //destroy the bullet if it wents outside of the screen on the top
        if (transform.position.y > max.y)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Detect the collision with other things and what happens if that colision happens
        if ((col.tag == "EnemyShip") || (col.tag == "Other_things"))
        {
            Destroy(gameObject);
        }
    }
}
