using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Block : MonoBehaviour
{
    public int hits;

    public GameObject ball;

    public Material otherMaterial;  //to be able to change material  
    public Material[] materials;    //array for cracked materials
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hit()
    {
        //TODO change range back to 0 to 30
        int random = Random.Range(0, 5);
        if (random == 1)
        {
            SpawnPowerup(0);    //spawns multiball
        } 
        else if (random == 2)
        {
            SpawnPowerup(1);
        }
        hits--;
        if (hits == 0)
        {
            FindObjectOfType<Paddle>().DecreaseBlockCount();
            Destroy(gameObject);
        }
    }
    
    private void SpawnPowerup(int powerup)
    {
        Debug.Log("spawn powerup");
        //multiball, spawns two additional balls
        if (powerup == 0)
        {
            Debug.Log("multiball");
            Instantiate(ball, ball.transform.position + new Vector3(1, 0, 0), Quaternion.identity);
            Instantiate(ball, ball.transform.position - new Vector3(1, 0, 0), Quaternion.identity);
            FindObjectOfType<Paddle>().IncreaseBallCount();
        }
        //bigger paddle
        if (powerup == 1)
        {
            FindObjectOfType<Paddle>().IncreasePaddleSize();
        }
    }
}
