using UnityEngine;

public class AsteroideSpawner : MonoBehaviour
{
    public GameObject asteroide;

    float maxSpawnRateInSeconds = 3f;

    // Start is called before the first frame update
    void Start()
    {

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
            //Chosing a number between 1 and x
            spawnInSeconds = Random.Range(100f, maxSpawnRateInSeconds);
        }
        else
            spawnInSeconds = 1f;

        Invoke("SpawnAsteroide", spawnInSeconds);
    }

    //Function to increase the dificult of the game (but not really)
    public void IncreaseSpawnRate()
    {
        if (maxSpawnRateInSeconds > 1f)
            maxSpawnRateInSeconds--;
        if (maxSpawnRateInSeconds == 1f)
            CancelInvoke("IncreaseSpawnRate");
    }
    //Function to Start the Spawner
    public void ScheduleAsteroideSpawner()
    {
        maxSpawnRateInSeconds = 3f;

        Invoke("SpawnAsteroide", maxSpawnRateInSeconds);

        //increase spawnRate every 1s
        InvokeRepeating("IncreaseSpawnRate", 0f, 1f);
    }



    //Function to stop the AsteroideSpawner
    public void UnscheduleAsteroideSpawner()
    {
        CancelInvoke("SpawnAsteroide");
        CancelInvoke("IncreaseSpawnRate");
    }
}
