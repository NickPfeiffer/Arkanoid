using UnityEngine;

public class Powerup : MonoBehaviour
{
    private Vector3 velocity;
    
    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector3(0, 0, -3);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += velocity * Time.deltaTime;  
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
