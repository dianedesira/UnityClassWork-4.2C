using System.Collections;
using System.Collections.Generic;
using System.Xml;
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

    //global variables
    [SerializeField] float movementSpeed = 10f;
    [SerializeField] GameObject laserPrefab;

    float xMin;
    float xMax;
    float yMin;
    float yMax;

    // Start is called before the first frame update
    void Start()
    {
        // print("Hello this is the Start built-in method!");
        SetUpBoundaries();
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
        //local variables
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed;

        /*
         * To fetch properties from the Unity Editor the syntax is:
         *    object.ComponentName.Property
         * If the property is for the current object the script is controlling, the object does not need to be specified so:
         *     ComponentName.Property
         */

        /* Clamp restricts values to be between a set min and max. If the value is
         * within the range the same value will be returned, otherwiswe if the
         * value is less than the minimum, the minimum value is returned and if it
         * is higher than the maximum, the maximum will be returned.
         */

        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);

        transform.position = new Vector3(newXPos, newYPos, transform.position.z);

    }
    void SetUpBoundaries()
    {
        Camera gameCamera = Camera.main; // fetching the main camera
        float padding = 0.5f;

        /* ViewportToWorldPoint checks the camera's view at runtime and calculates
         * the actual coordinates but in our code we just refer to the minimum as
         * 0 and maximum as 1.
         * Thus, the code will always be camera size independent.
         */

        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    
    }
}


