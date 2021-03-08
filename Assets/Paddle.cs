using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //can be changed through editor, editor always overrides this
    //so setting it initial here is quite useless
    public float speed;

    public Transform playArea;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKey(KeyCode.A)) //keyCodes are bad practice
        float dir = Input.GetAxis("Horizontal");
        float newX = transform.position.x + Time.deltaTime * speed * dir;
        float playAreaSize = playArea.localScale.x * 10;    //play and paddleSize can be put in Start for performance improvement
        float paddleSize = transform.localScale.x * 1;      //*1 is not needed, just used for clarity
        
        float maxX = 0.5f * playAreaSize - 0.5f * paddleSize;  //hardcoded border
        float clampedX = Mathf.Clamp(newX, -maxX, maxX);
        
        //deltaTime is needed so there are no advantages with higher frames
        // transform.position += new Vector3(Time.deltaTime*speed*dir, 0, 0);
        
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}
