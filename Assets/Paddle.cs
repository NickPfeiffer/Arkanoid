using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Paddle : MonoBehaviour
{
    //can be changed through editor, editor always overrides this
    //so setting it initial here is quite useless
    public float speed;
    
    private int score;
    public Text scoreValue;

    private float countdown = 3.0f;
    private int seconds;
    public bool countdownRunning = false;
    public Text countdownText;
    
    public int lifes;
    public Image[] hearts;
    private int ballCount = 1;
    public Transform paddleWidth;

    public GameObject ball;
    private int blockCount = 30;

    private float paddleSize;
    private float newX;
    private float playAreaSize;
    private float clampedX;
    private float maxX;
    public Transform playArea;
    // Start is called before the first frame update
    void Start()
    {
        playAreaSize = playArea.localScale.x * 10;
        paddleSize = transform.localScale.x * 1;      //*1 is not needed, just used for clarity
        countdownText.text = countdown.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        float dir = Input.GetAxis("Horizontal");
        //deltaTime is needed so there are no advantages with higher frames
        newX = transform.position.x + Time.deltaTime * speed * dir;
        
        //hardcoded border
        maxX = 0.5f * playAreaSize - 0.5f * paddleSize;
        clampedX = Mathf.Clamp(newX, -maxX, maxX);

        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
        
        //TODO hide and display timer
        if (countdownRunning)
        {
            if (countdown > 0)
            {
                countdown -= Time.deltaTime;
                seconds = Mathf.FloorToInt(countdown);
                countdownText.text = seconds.ToString();
            }
            else
            {
                countdown = 0;
                countdownRunning = false;
                countdown = 3;
                countdownText.text = countdown.ToString();
            }
        }
    }
    
    public void DecreaseLife()
    {
        if (ballCount > 1)
        {
            ballCount--;
        }
        else
        {
            ballCount--; //reduce ballCount to zero
            lifes--;
            
            if (lifes == 0)
            {
                SceneManager.LoadScene("End");
                //this also plays the sound that is added at the Canvas (because Play on Awake is ticked)
            }
            else
            {
                Destroy(hearts[lifes]);
                countdownRunning = true;
                Invoke(nameof(SpawnNewBall), 3);
                ballCount += 1; //add one to ballCount because a new one was created now
                GetComponent<AudioSource>().Play();
            }
        }
    }

    private void CountDown()
    {
        Debug.Log("COUNTDOWN");
        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
        }
        countdownText.text = countdown.ToString();
    }
    
    public void DecreaseBlockCount()
    {
        blockCount--;
        Debug.Log("blocks left:" + blockCount);
        if (blockCount == 0)
        {
            SceneManager.LoadScene("Win");
        }
    }

    //create ball on spawn
    private void SpawnNewBall()
    {
        Instantiate(ball, new Vector3(0, 0.25f, -1), Quaternion.identity);
    }
    
    public void IncreaseScore()
    {
        score += 100;
        scoreValue.text = score.ToString();
    }
    
    public void IncreaseBallCount()
    {
        ballCount += 2;
        Debug.Log("Increase ballCount, new ballCount:" + ballCount);
    }

    public void IncreasePaddleSize()
    {
        paddleWidth.transform.localScale = new Vector3(4.0f , 1.0f, 1.0f);
        paddleSize = 4;
        //resets paddle size after 5 seconds
        Invoke(nameof(ResetPaddleSize), 5.0f);
    }

    private void ResetPaddleSize()
    {
        paddleWidth.transform.localScale = new Vector3(3.0f , 1.0f, 1.0f);
        paddleSize = 3;
    }
}
