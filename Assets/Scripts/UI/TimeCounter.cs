using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    public GameObject GameManager; //reference to our Game Manager
    public GameObject playership; //reference to our player ship
    public GameObject TimeMedalText; //reference to the Time Medal text
    public GameObject TimeMedal; //reference to the time Medal

    Text timeUI;//Reference to TimeUI

    float StartTime; //The time when the player clicks on play
    float EllapseTime; //The ellapse time after th eplayer starts the game
    bool startCounter; //Flag to start the counter

    int seconds;

    // Start is called before the first frame update
    void Start()
    {
        //Set the flag to false
        startCounter = false;

        //Get the TextUi component from this object
        timeUI = GetComponent<Text>();
    }

    //Function to start the time counter
    public void StartTimeCounter()
    {
        StartTime = Time.time;
        startCounter = true;
    }

    //Function to stop the time counter
    public void StopTimeCounter()
    {
        startCounter = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (startCounter)
        {
            //Compute the ellapse time
            EllapseTime = Time.time - StartTime;

            seconds = (int)EllapseTime; //Get the seconds

            timeUI.text = string.Format("{0:000}", seconds);

            //See if the player got 100s in the game
            if (seconds >= 70)
            {
                GameManager.GetComponent<GameManager>().SetGameManagerState(global::GameManager.GameManagerState.GameOver);

                playership.gameObject.SetActive(false);

                TimeMedalText.gameObject.SetActive(true);

                TimeMedal.gameObject.SetActive(true);
            }
        }
    }
}
