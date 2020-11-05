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

    [SerializeField] float movementSpeed = 10f;


    // Start is called before the first frame update
    void Start()
    {
       // print("Hello this is the Start built-in method!");
    }

    // Update is called once per frame
    void Update()
    {
        // print("This is the Update method");
        Move();
    }

    /* This method will control the player's movement depending on the controls/input by the user
     */
    void Move()
    {
        /* GetAxis is a method, found in the Input class, which retrieves the particular axis settings which its name is passed
         * as a parameter.
         * This method waits for any user input made by the keys specified by the axis. If there is in fact user input, small
         * values (+ve or -ve) are returned. 
         * We are saving this return in the deltaX variable.
         */

        // The deltaTime property is used to make the movement frame independent since the method is being called in the Update
        // and the number of times Move will be called in one second depends on the frame rate
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed;

        /*
         * To fetch properties from the Unity Editor the syntax is:
         *    object.ComponentName.Property
         * If the property is for the current object the script is controlling, the object does not need to be specified so:
         *     ComponentName.Property
         */

        var newXPos = transform.position.x + deltaX;

        transform.position = new Vector3(newXPos, transform.position.y, transform.position.z);

    }
}
