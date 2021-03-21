using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class Block : MonoBehaviour
{
    public GameObject multiballDrop;
    public GameObject paddleDrop;
    public Material otherMaterial;
    
    public int hits;
    private Vector3 brickPos;

    // Start is called before the first frame update
    void Start()
    { 
        brickPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Hit()
    {
        GetComponent<MeshRenderer>().material = otherMaterial;
        
        hits--;
        if (hits == 0)
        {
            FindObjectOfType<Paddle>().DecreaseBlockCount();
            Destroy(gameObject);
        }
        
        int random = Random.Range(0, 30);
        if (random == 1)
        {
            Debug.Log("multiball");
            Instantiate(multiballDrop, brickPos, Quaternion.identity);
        } 
        else if (random == 2)
        {
            Debug.Log("paddleSize");
            Instantiate(paddleDrop, brickPos, Quaternion.identity);
        }
    }
}
