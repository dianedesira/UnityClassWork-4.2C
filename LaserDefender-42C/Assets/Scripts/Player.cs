using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /* In Unity we will be using 2 types of methods; Built-in Methods and User Defined methods.
     * Built in: These methods have their names already setup by Unity since the Unity compiler knows when 
     * the method should be called during the game execution. We only need to implement the code which will
     * be executed upon method call.
     * Note: Upon method definition we need to make sure that the method name is written without spelling 
     * mistakes and in the proper casing.
     * User Defined: These methods are created by the current developer to better organise the code.
     * Since the name will be invented it is important that we don't use the same name which is already
     * used for other built-in methods, keywords and variables.
     * Since the Unity compiler does not call these methods, it is important to remember that we, as
     * developers call the method where is required.
     */


    // Start is called before the first frame update
    void Start()
    {
        print("Hello this is the Start built-in method!");
    }

    // Update is called once per frame
    void Update()
    {
        print("This is the Update method");
    }
}
