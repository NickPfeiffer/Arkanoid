using UnityEngine;

public class Ball : MonoBehaviour
{
    private Vector3 velocity;

    //speed
    public float maxX;
    public float maxZ;
    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector3(0, 0, -maxZ);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += velocity * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        //TODO change sounds of paddle or breakable hit
        if (other.CompareTag("Paddle"))
        {
            float maxDist = other.transform.localScale.x * 1 * 0.5f + transform.localScale.x * 1 * 0.5f;
            float dist = transform.position.x - other.transform.position.x; //actual distance
            //normalize distance to -1 to 1
            float nDist = dist / maxDist;
            velocity = new Vector3(nDist * maxX, velocity.y, -velocity.z);
            GetComponent<AudioSource>().Play();
        }
        
        else if (other.CompareTag("Breakable"))
        {
            FindObjectOfType<Paddle>().IncreaseScore();
            other.GetComponent<Block>().Hit();
            velocity = new Vector3(velocity.x, velocity.y, -velocity.z);
            GetComponent<AudioSource>().Play();
        }
        
        else if (other.CompareTag("TopWall"))
        {
            velocity = new Vector3(velocity.x, velocity.y, -velocity.z);
        }
        
        else if (other.CompareTag("Wall"))
        {
            velocity = new Vector3(-velocity.x, velocity.y, velocity.z);
        }
        
        else if (other.CompareTag("Finish"))
        {
            FindObjectOfType<Paddle>().DecreaseLife();
        }
    }
}
