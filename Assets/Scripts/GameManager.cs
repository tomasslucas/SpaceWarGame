using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PlayButton; //Reference to PlayButton
    public GameObject PlayerShip; //Reference to PlayerShip
    public GameObject AsteroideSpawner; //Reference to AsteroideSpawner
    public GameObject GameOverUI; //Reference to GameOverImage
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

                //Set Play Button to Active
                PlayButton.SetActive(true);

                break;
            case GameManagerState.Gameplay:
                //Hide PlayButton on Gameplay state
                PlayButton.SetActive(false);

                //Active PlayerShip
                PlayerShip.GetComponent<Player_Control>().Init();

                //Start the asteroideSpawner
                AsteroideSpawner.GetComponent<AsteroideSpawner>().ScheduleAsteroideSpawner();
                break;
            case GameManagerState.GameOver:
                //Stop AsteroideSpawner
                AsteroideSpawner.GetComponent<AsteroideSpawner>().UnscheduleAsteroideSpawner();

                //Display Game over
                GameOverUI.SetActive(true);

                //Change Game Manager State to Opening State after 8s
                Invoke("ChangeToOpeningState", 8f);
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
    //Function to cheange game manager state to opening state
    public void ChangeToOpeningState()
    {
        SetGameManagerState(GameManagerState.Opening);
    }
}
