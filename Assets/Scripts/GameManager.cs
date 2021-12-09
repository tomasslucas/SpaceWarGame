using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PlayButton;
    public GameObject PlayerShip;
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
                break;
            case GameManagerState.Gameplay:
                break;
            case GameManagerState.GameOver:
                break;
        }
    }

    //Set the gameManager State
    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState();
    }
}