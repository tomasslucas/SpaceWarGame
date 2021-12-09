using UnityEngine;

public class AsteroideSpawner : MonoBehaviour
{
    public GameObject asteroide;

    float maxSpawnRateInSeconds = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnAsteroide", maxSpawnRateInSeconds);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnAsteroide()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        GameObject anAsteroide = (GameObject)Instantiate(asteroide);
        anAsteroide.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

        //schedule when to spawn the next asteroide
        ScheduleNextAsteroide();
    }

    void ScheduleNextAsteroide()
    {
        float spawnInSeconds;

        if (maxSpawnRateInSeconds > 1f)
        {
            spawnInSeconds = Random.Range(1f, maxSpawnRateInSeconds);
        }
        else
            spawnInSeconds = 1f;

        Invoke("SpawnAsteroide", spawnInSeconds);

        //If you need help.https://www.youtube.com/watch?v=k3GN3FuyqnQ&ab_channel=PixelelementGames
    }
}
