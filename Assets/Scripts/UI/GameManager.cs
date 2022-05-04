using UnityEngine;

public class GameManager : MonoBehaviour
{
    //References
    public GameObject PlayButton; //Reference to PlayButton
    public GameObject PlayerShip; //Reference to PlayerShip
    public GameObject AsteroideSpawner; //Reference to AsteroideSpawner
    public GameObject GameOverUI; //Reference to GameOverImage
    public GameObject scoreTextUI; //Reference to score text UI;
    public GameObject timeCounter; //Reference to time counter gameObject;
    public GameObject GameTitle; //Reference to Game title
    public GameObject scoreMedalText; //reference to the Score Medal text
    public GameObject TimeMedalText; //reference to the Time Medal text
    public GameObject SoundButton; //Reference to SoundButton
    public enum GameManagerState
    {
        Opening,
        Gameplay,
        GameOver
    }

    GameManagerState GMState;

    // Start is called before the first frame update
    void Start()
    {
        GMState = GameManagerState.Opening;
    }

    // Update GameManager State
    void UpdateGameManagerState()
    {
        switch (GMState)
        {
            case GameManagerState.Opening:
                //Hide GameOverDisplay
                GameOverUI.SetActive(false);

                //Show SoundButton
                SoundButton.SetActive(true);

                //Set Play Button to Active
                PlayButton.SetActive(true);

                //Set Game Title to Active
                GameTitle.SetActive(true);

                //Set ScoreMedalText to Active
                scoreMedalText.SetActive(false);

                //Set TimeMedalText to Active
                TimeMedalText.SetActive(false);

                break;
            case GameManagerState.Gameplay:
                //Hide Game Title
                GameTitle.SetActive(false);

                //Rest the Score
                scoreTextUI.GetComponent<GameScore>().Score = 0;

                //Hide PlayButton on Gameplay state
                PlayButton.SetActive(false);

                //Active PlayerShip
                PlayerShip.GetComponent<Player_Control>().Init();

                //Start the asteroideSpawner
                AsteroideSpawner.GetComponent<AsteroideSpawner>().ScheduleAsteroideSpawner();

                //Start the time counter
                timeCounter.GetComponent<TimeCounter>().StartTimeCounter();

                break;
            case GameManagerState.GameOver:
                //Stop the time Counter
                timeCounter.GetComponent<TimeCounter>().StopTimeCounter();

                //Stop AsteroideSpawner
                AsteroideSpawner.GetComponent<AsteroideSpawner>().UnscheduleAsteroideSpawner();

                //Display Game over
                GameOverUI.SetActive(true);

                //Change Game Manager State to Opening State after 8s
                Invoke("ChangeToOpeningState", 3f);
                break;
        }
    }

    //Set the gameManager State
    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState();
    }

    //The PlayButton will call this function
    public void StartGamePlay()
    {
        GMState = GameManagerState.Gameplay;
        UpdateGameManagerState();
    }
    //Function to change game manager state to opening state
    public void ChangeToOpeningState()
    {
        SetGameManagerState(GameManagerState.Opening);
    }
}
