using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    int score = 0; // the game score and it is going to be set as private to keep it secure and avoid any
    //unintended errors

    private void Awake()
    {
        /* GameSession will hold the score for the current game. The score needs to be also displayed in the Game
         * Over Scene. Since whenever scenes are switched all of the objects (and their values) are destroyed, we
         * need to make sure that the current game session is not destroyed when we redirect to the Game Over 
         * scene, so that the value of the current score remains.
         * Also, we need to ensure that we only have one game session and we don't allow any new game sessions to
         * be created inside the Game Over scene (thus, using singleton).
         */
        SetUpSingleton();
    }

    void SetUpSingleton()
    {
        if (FindObjectsOfType<GameSession>().Length > 1)
        {
            Destroy(gameObject);
        }
        else 
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void AddToScore(int scoreValue)
    {
        score += scoreValue; // score = score + scoreValue;
    }

    public void ResetGame()
    {
        /* Since the GameSession object is not destroyed when scenes are switched, an issue will be caused when
         * the user decides to play again. Reason being, the score of the previous game play will remain and not
         * reset. Therefore, when the user chooses to play again, the current game session is to be deleted, so that
         * a new game session (with reset values) can be recreated and the score will be back to 0.
         */
        Destroy(gameObject);
    }
}
