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
    [SerializeField] float laserSpeed = 20f;
    [SerializeField] float laserDelay = 0.3f;

    [SerializeField] int playerHealth = 100;

    [SerializeField] GameObject laserPrefab;

    Coroutine firingCoroutine;

    float xMin;
    float xMax;
    float yMin;
    float yMax;

    // Start is called before the first frame update
    void Start()
    {
        // print("Hello this is the Start built-in method!");
        SetUpBoundaries();

        //To call a coroutine, we need to use the StartCoroutine method.
        //StartCoroutine(PrintAndWait());
    }

    // Update is called once per frame
    void Update()
    {
        // print("This is the Update method");
        Move();
        Fire();
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

    void Fire()
    {
        /* The GetButtonDown method returns true whenever as soon as the user presses down on the key/s 
         * represented by the given button name. The method is executed only once per one key down.
         * (GetButton would keep on running while the user keeps on holding the button)
         */

        if (Input.GetButtonDown("Fire1")) //if(Input.GetButtonDown("Fire1") == true)
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }

        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
            //StopAllCoroutines();
        }
    }

    /* Coroutines are special methods used to allow processes to continue with the rest of the
     * application rather than pausing due to the current method requiring a delay or a wait
     * for a condition. If the process would stop, the whole or most of the application would
     * seems as if it froze.
     * Coroutines tell the process to return to the other tasks and come back after an amount
     * of time or after a condition is met by using the yield return keywords and one of the
     * types which fall under IEnumerator (WaitForSeconds, WaitUntil, WaitWhile etc).
     */
    IEnumerator PrintAndWait()
    {
        print("Message 1 has been sent!");

        yield return new WaitForSeconds(3f);

        print("Message 2 has been sent!");
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            /* The Instantiate method generates a clone/copy of the object which is passed as the first
             * parameter. There are different ways on how we can call this method, we needed to indicate
             * the position where the clone/copy will be created in the scene (we need it to appear in the
             * same position as the player ship).
             * Quaternion.identity refers to no rotation (0,0,0)
             * 
             * Instantiate returns a reference to the clone which has just been generated.
             */

            GameObject laserClone = Instantiate(laserPrefab, transform.position, Quaternion.identity);

            laserClone.GetComponent<Rigidbody2D>().velocity = new Vector2(0, laserSpeed);

            yield return new WaitForSeconds(laserDelay);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //We are retrieving the damage dealer of the current laser which hit the enemy since different
        //lasers CAN have different damage values
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();

        if (!damageDealer) //checking if the damageDealer variable is empty/null
        {
            return; // makes the method stop and return back, thus ProcessHit() will never be called IF
            // the damageDealer is empty.
        }

        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        playerHealth -= damageDealer.GetDamage(); // health = health - damagedDealer.GetDamage();
        // A -= B; => A = A - B;
        damageDealer.Hit();

        if (playerHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}


