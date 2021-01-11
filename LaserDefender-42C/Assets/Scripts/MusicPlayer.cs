using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    /* Awake() is a built-in method and it is very similar to the Start() since it is called automatically by 
     * the Unity Compiler when the game loads. The difference between the Start and the Awake is that the Start
     * is called when the current object is ready and completley initialised and set (so all components are loaded
     * properly) and this is something which in general is important.
     * In the case of the Awake(), the method is called once the object has been noted and before all components
     * are loade. Thus, Awake is called before the Start.
     */
    private void Awake()
    {
        SetUpSingleton();
    }

    void SetUpSingleton()
    {
        /* FindObjectsOfType finds a LIST of objects which contain the indicated script (music player) - so all
         * music players will be placed in a list
         * The if statement is checking whether the list contains more than one music player
         */
        if (FindObjectsOfType<MusicPlayer>().Length > 1)
        {
            //if there is more than one music player, then destroy the current music player so that we keep the
            //first one and the song will continue from where it left off in the previous scene (the new one would
            //restart the song
            Destroy(gameObject);
        }
        else // would mean that this is the first music player so we should ensure that this music player 
        //remains playing during the life time of this game play
        {
            /* DontDestroyOnLoad is a method which enforces the compiler not the destroy the object, passed as a
            * parameter, once a new scene is loaded. Since the normal procedure is that all objects in the current
            * scene are destroyed once a new scene is loaded.
            */
            DontDestroyOnLoad(gameObject);
        }
    }
}
