using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // We need to import the SceneManagement library so that we can use its
//classes and methods to load and manage different scenes

public class Level : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 2f; // delay before loading the Game over scene

    public void LoadStartMenu()
    {
        /* The LoadScene method is found in the SceneManager class which is located in the SceneManagement
         * library - to use it we had to import the library.
         * LoadScene loads a scene either via its buildIndex or else via its name.
         * The StartMenu should always be the first scene and so we are loading the scene which is at index 0
         */
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("LaserDefender");
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
    }

    public void QuitGame()
    {
        print("quitting game!");
        Application.Quit(); //this will quit the executable game and not while testing in the Editor
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds); // once coroutine is called, return and come back after
        // the delay is up (e.g. 2 seconds) so that the Game Over scene can be loaded.

        SceneManager.LoadScene("GameOver");
    }
}
