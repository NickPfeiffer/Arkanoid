using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int hits;

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

    private void OnTriggerEnter(Collider other)
    {
        hits--;
        if (hits == 0)
        {
            Destroy(gameObject); 
        }
    }
}
