using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
    public GameObject GameManager; //reference to our Game Manager
    public GameObject playership; //reference to our player ship
    public GameObject scoreMedalText; //reference to the Score Medal text
    public GameObject scoreMedal; //reference to the Score Medal

    Text scoreTextUI;
    int score;
    public int Score
    {
        get
        {
            return this.score;
        }
        set
        {
            this.score = value;
            UpdateScoreTextUI();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreTextUI = GetComponent<Text>();
    }

    void UpdateScoreTextUI()
    {
        string scoreStr = string.Format("{0:000}", score);
        scoreTextUI.text = scoreStr;

        //See if the player got 100pts in the game
        if (score >= 500)
        {
            GameManager.GetComponent<GameManager>().SetGameManagerState(global::GameManager.GameManagerState.GameOver);

            playership.gameObject.SetActive(false);

            scoreMedalText.gameObject.SetActive(true);

            scoreMedal.gameObject.SetActive(true);
        }
    }
}
