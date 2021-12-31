using UnityEngine;

public class AsteroideSpawner : MonoBehaviour
{
    public GameObject asteroide;

    float maxSpawnRateInSeconds = 1f;

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
            //Chosing a number between 1 and maxSpawnRateInSeconds
            spawnInSeconds = Random.Range(0.1f, maxSpawnRateInSeconds);
        }
        else
            spawnInSeconds = 0.1f;

        Invoke("SpawnAsteroide", spawnInSeconds);
    }

    //Function to increase the dificult of the game (but not really)
    public void IncreaseSpawnRate()
    {
        //How long it takes to invoke another asteroid
        if (maxSpawnRateInSeconds > 1f)
            maxSpawnRateInSeconds = maxSpawnRateInSeconds - 0.1f;
        if (maxSpawnRateInSeconds == 0.1f)
        {
            CancelInvoke("IncreaseSpawnRate");
        }
    }
    //Function to Start the Spawner
    public void ScheduleAsteroideSpawner()
    {
        //reset max spawn rate
        maxSpawnRateInSeconds = 1.5f;

        Invoke("SpawnAsteroide", maxSpawnRateInSeconds);

        //increase spawnRate every 1s
        InvokeRepeating("IncreaseSpawnRate", 0f, 5f);
    }



    //Function to stop the AsteroideSpawner
    public void UnscheduleAsteroideSpawner()
    {
        CancelInvoke("SpawnAsteroide");
        CancelInvoke("IncreaseSpawnRate");
    }
}
