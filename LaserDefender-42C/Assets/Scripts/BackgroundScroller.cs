using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] float backgroundScrollSpeed = 0.02f; //the speed of the image scrolling
    Material myMaterial; // variable to store the Quad's (Background's) material - which is the Space image
    Vector2 offset; //offset refers to change in position of an image so we will use it to move the image on
                    //the quad

    // Start is called before the first frame update
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
        offset = new Vector2(0f, backgroundScrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        myMaterial.mainTextureOffset += offset * Time.deltaTime;
        //fetching the offset value from the material and applying a small change on the y every frame.
        //whenever we have any movement, it needs to be frame independent and thus, movement should always
        //be multiplied by Time.deltaTime (distance * time eliminates frame dependancy)
    }
}
