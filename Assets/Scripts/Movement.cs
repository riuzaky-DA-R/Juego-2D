using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    private string SceneName;
    public float speed;
    public float jumpforce;
    public Transform feet;
    public LayerMask MovingPlatform;
    public LayerMask IsGround;
    public float Check;
    public float Jumptime;
    public Transform SideA;
    public Transform SideB;
    public Transform SideA1;
    public Transform SideB1;
    public int CurrentLevel;
    public float CurrentScore;
    //public float position;
    public GameObject player;
    public GameObject Platform;
    private bool landed;
    public Text score;
    private bool EndLevel =false;
    public Canvas Endscreen;


    public int nextlevel;
    private bool Platformed;
    private bool BumpingA;
    private bool BumpingB;
    private bool BumpingA1;
    private bool BumpingB1;
    private bool BA;
    private bool BA1;
    private bool BB;
    private bool BB1;
    private bool IsJumping;
    private bool grounded= true;
    private float jumpTimeCounter;
    private Rigidbody2D rb;
    //private bool facingright = true;
    private float direction;
    private void Start()
    {
        Endscreen.enabled = false;
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        SceneName = SceneManager.GetActiveScene().name;
        if (SceneName == "SampleScene")
        {
            CurrentLevel = 1;
            nextlevel = 2;
            CurrentScore = 0;
            SavePlayerData();
        }
        else if (SceneName=="Level2")
        {
            Loadplayer();
            CurrentLevel = 2;
            nextlevel = 3;
            SavePlayerData();
        }
        else if (SceneName == "Level3")
        {
            Loadplayer();
            CurrentLevel = 3;
            nextlevel = 0;
            SavePlayerData();
        }
    }
    public void Score()
    {

    }
    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        score.text = "score: " + CurrentScore.ToString();
    }
      private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        //Running
        BumpingA = Physics2D.OverlapCircle(SideA.position,Check,IsGround);
        BumpingB = Physics2D.OverlapCircle(SideB.position, Check, IsGround);
        BumpingA1 = Physics2D.OverlapCircle(SideA1.position, Check, IsGround);
        BumpingB1 = Physics2D.OverlapCircle(SideB1.position, Check, IsGround);
        BA = Physics2D.OverlapCircle(SideA.position, Check, MovingPlatform);
        BB = Physics2D.OverlapCircle(SideB.position, Check, MovingPlatform);
        BA1 = Physics2D.OverlapCircle(SideA1.position, Check, MovingPlatform);
        BB1 = Physics2D.OverlapCircle(SideB1.position, Check, MovingPlatform);
        if (BumpingA == true || BumpingB == true || BumpingA1 == true || BumpingB1 == true || BA == true || BB == true || BA1 ==true || BB1 == true)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(direction * speed, rb.velocity.y);
        }
        //Jumping
        Platformed = Physics2D.OverlapCircle(feet.position, Check, MovingPlatform);
        grounded = Physics2D.OverlapCircle(feet.position, Check, IsGround);
        if (grounded == true || Platformed == true)
        {
            landed = true;
        }
        else
        {
            landed = false;
        }

        if ( landed==true && IsJumping==true)
        {
            jumpTimeCounter = Jumptime;
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpforce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                IsJumping = false;
            }
        }
        //if is on amoving paltform 
        if (Platformed == true)
        {
            player.transform.parent = Platform.transform;
        }
        else if (Platformed == false)
        {
            player.transform.parent = null;
        }

    }

    private void ProcessInputs()
    {
        direction = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IsJumping = true;
            jumpTimeCounter = Jumptime;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            IsJumping = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Goldcoin"))
        {
            Destroy(other.gameObject);
            CurrentScore = CurrentScore + 10;
            EndLevel = !EndLevel;
            Endscreen.enabled = EndLevel;
            Time.timeScale = (EndLevel) ? 0 : 1f;
            CurrentLevel = nextlevel;
            SavePlayerData();
        }
        else if (other.gameObject.CompareTag("Silvercoin"))
        {
            Destroy(other.gameObject);
            CurrentScore = CurrentScore + 1;

        }
    }
    public void SavePlayerData()
    {
        SaveSystem.SavePlayer(this);
    }

    public void Loadplayer()
    {
        SavedData Data = SaveSystem.LoadPlayer();
        CurrentLevel = Data.level;
        CurrentScore = Data.Score;
    }
    //character flip  code 
    //private void Flipcharacter()
    //{
    //    facingright = !facingright;
    //    transform.Rotate(0f, 180f, 0f);
    //}
}
