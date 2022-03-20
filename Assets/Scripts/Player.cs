using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public ParticleSystem particle;
    public ParticleSystem.MainModule m;
    public GameObject player;
    public float timeC;
    public Camera cam;
    public float speed;
    public Rigidbody2D rb2d;
    float horizontalInput;
    public bool grounded;
    public SpriteRenderer sprite;
    public GameObject shoot;
    public GameObject shootSpecial;
    public Transform startR;
    public Transform startL;
    public Animator anima;
    public bool right;
    public float impulsePlayer;
    public ManagerGame managerGame;
    public Joystick joystick;
    public static bool countTime;
    public GameObject panelGameOver;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<Camera>();
        sprite = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
        particle = GameObject.FindObjectOfType<ParticleSystem>().GetComponent<ParticleSystem>();
        particle.gameObject.SetActive(false);
        m = particle.main;
        m.startColor = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.X))
        //{
        //    particle.gameObject.SetActive(true);
        //    timeC += Time.deltaTime;
        //    if (timeC >= 2)
        //    {
        //        m.startColor = Color.red;
        //    }
        //}
        //if (Input.GetKeyUp(KeyCode.X))
        //{
        //    particle.gameObject.SetActive(false);
        //    Shoot();
        //    anima.SetBool("shoot", true);
        //    timeC = 0;
        //    m.startColor = Color.green;
        //}
        cam.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        //horizontalInput = Input.GetAxis("Horizontal");
        horizontalInput = joystick.Horizontal;
        rb2d.velocity = new Vector2(horizontalInput * speed, rb2d.velocity.y);
        if (joystick.Horizontal >= 0.2f)
        {
            //anima.SetFloat("run", Mathf.Abs(horizontalInput));
            anima.SetBool("run", true);
            sprite.flipX = false;
        }
        else if (joystick.Horizontal <= -0.2f)
        {
            //anima.SetFloat("run", Mathf.Abs(horizontalInput));
            anima.SetBool("run", true);
            sprite.flipX = true;
        }
        else
        {
            horizontalInput = 0;
            anima.SetBool("run", false);
           
            //anima.SetFloat("run", Mathf.Abs(horizontalInput));
        }

        if(joystick.Vertical >= 0.2f && grounded)
        {
            Jump();
        }

        if(countTime)
        {
            timeC += Time.deltaTime;
            if(timeC >= 2)
            {
                m.startColor = Color.red;
            }
        }
    }

  
    void Jump()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x, speed);
       
        grounded = false;
        anima.SetBool("jump", true);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            grounded = true;
            anima.SetBool("jump", false);
        }
        if(collision.gameObject.tag == "toxic")
        {
            Destroy(player.gameObject);
            panelGameOver.SetActive(true);
            
        }
        if(collision.gameObject.tag == "zombie")
        {
            managerGame.lifePlayer();
        }

        if(collision.gameObject.tag == "damage")
        {
            Destroy(this.gameObject);
            panelGameOver.SetActive(true);
        }

        if(collision.gameObject.tag == "Impulse")
        {
            rb2d.AddForce(new Vector2(0, impulsePlayer), ForceMode2D.Impulse);
        }

        if(collision.gameObject.tag == "DoorOpen")
        {
            Debug.Log("Colidiu com a DoorOpen");
            SceneManager.LoadScene("ScreenVictory");
        }
        
    }

    public void Shoot()
    {
        if (!sprite.flipX)
        {
            Instantiate(shoot, startR);
        }
        else
        {
            Instantiate(shoot, startL);
        }
    }

    public void ShootSpecial()
    {
        if(!sprite.flipX)
        {
            Instantiate(shootSpecial, startR);
        }
        else
        {
            Instantiate(shootSpecial, startL);
        }
    }
}
