using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Animator animator;

    public AudioSource aud;

    public int Health = 3;
    private float Xinput;
    private float Yinput;
    public float speed = 3f;
    public float drag;
    public Vector2 movement;
    private bool isFacingRight = true;
    public Rigidbody2D body;
    private bool isSprinting = false;
    private bool isdashing = false;
    [SerializeField] public TrailRenderer tr;
    [SerializeField] private SpriteRenderer SpriteRenderer;

    public int Coins = 0;

    public float ActiveMoveSpeed;
    public float dashSpeed;
    public float dashLength = .5f, dashCooldown = 1f;

    public float dashCounter;
    public float dashCoolCounter;

    private string scenetoLoad;

    public CharacterDatabase characterDB;

   

    public SpriteRenderer artworkSprite;

    private int selectedOption = 0;
    // Start is called before the first frame update
    void Start()
    {
        ActiveMoveSpeed = speed;
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }

        else
        {
            Load();
        }
        UpdateCharacter(selectedOption);

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        if (isdashing == true)
        {
            return;
        }

        movement.x = horizontalInput;
        movement.y = verticalInput;

    

        movement.Normalize();

        body.velocity = movement * ActiveMoveSpeed;

        if (horizontalInput != 0)
        {
            SpriteRenderer.flipX = horizontalInput < 0f;
        }

        animator.SetFloat("Move", Mathf.Abs(movement.x));

        animator.SetFloat("yMove", Mathf.Abs(movement.y));


        if (Input.GetKeyDown(KeyCode.LeftShift) && isSprinting == false )
        {
            isSprinting = true;
            Sprint();
        }

        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isSprinting = false;
            ActiveMoveSpeed = ActiveMoveSpeed/2;
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dashCoolCounter <=0 && dashCounter <= 0)
            {
                isdashing = true;
                tr.emitting = true;    
                ActiveMoveSpeed = dashSpeed;
                dashCounter = dashLength;
                isdashing = false;
                Dashtrail();
                
            }
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                ActiveMoveSpeed = speed;
                dashCoolCounter = dashCooldown;
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
     
        if (Health == 0) 
        {
            SceneManager.LoadScene(scenetoLoad = "Main Game");
            Debug.Log("Death");
        }

    }

    public void Sprint()
    {
         if (isSprinting == true){
            ActiveMoveSpeed = ActiveMoveSpeed * 2;
        }
    }
   

    private IEnumerator Dashtrail()
    {
        
            
        yield return new WaitForSeconds(dashLength);
       
        tr.emitting = false;



    }


    private void UpdateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.charactersprite;
       
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Merchant" || Input.GetKeyDown(KeyCode.E))
        {
            Coins = 0;
            Debug.Log("What are you buying?");
        }

       

        if (collision.gameObject.tag == "Chest" || Input.GetKeyDown(KeyCode.E))
        {
            Coins += 1;
            Debug.Log("What are you buying?");
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Merchant" || Input.GetKeyDown(KeyCode.E))
        {

            Debug.Log("What are you buying?");
        }

        if (collision.gameObject.tag == "Transport" || Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Touch");
            SceneManager.LoadScene(scenetoLoad = "Level 1");
        }

        if (collision.gameObject.tag == "Transport2" || Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Touch");
            SceneManager.LoadScene(scenetoLoad = "Level 2");
        }

        if (collision.gameObject.tag == "TransportShop" || Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Touch");
            SceneManager.LoadScene(scenetoLoad = "Shop");
        }

        if (collision.gameObject.tag == "Transport3" || Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Touch");
            SceneManager.LoadScene(scenetoLoad = "Level 3");
        }

        if (collision.gameObject.tag == "Transport4" || Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Touch");
            SceneManager.LoadScene(scenetoLoad = "End");
        }

        if (collision.gameObject.tag == "Win" || Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Touch");
            SceneManager.LoadScene(scenetoLoad = "Final Boss");
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Hurt");
            Health -= 1;
            
        }
    }
}
