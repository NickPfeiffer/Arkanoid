using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class Block : MonoBehaviour
{
    public int hits;

    public GameObject ball;

    public Material otherMaterial;
    
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
        GetComponent<MeshRenderer>().material = otherMaterial;
        
        hits--;
        if (hits == 0)
        {
            FindObjectOfType<Paddle>().DecreaseBlockCount();
            Destroy(gameObject);
        }
        
        //TODO change range back to 0 to 30
        int random = Random.Range(0, 5);
        if (random == 1)
        {
            SpawnPowerup(0);    //multiball
        } 
        else if (random == 2)
        {
            SpawnPowerup(1);    //bigger paddle
        }
    }
    
    private void SpawnPowerup(int powerup)
    {
        Debug.Log("spawn powerup");
        //multiball, spawns two additional balls
        if (powerup == 0)
        {
            Debug.Log("multiball");
            var position = ball.transform.position;
            Instantiate(ball, position + new Vector3(1, 0, 0), Quaternion.identity);
            Instantiate(ball, position - new Vector3(1, 0, 0), Quaternion.identity);
            FindObjectOfType<Paddle>().IncreaseBallCount();
        }
        //bigger paddle
        if (powerup == 1)
        {
            FindObjectOfType<Paddle>().IncreasePaddleSize();
        }
    }
}
