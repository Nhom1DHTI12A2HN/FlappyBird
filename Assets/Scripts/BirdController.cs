using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float flyFower;
    GameObject obj;
    GameObject gameController;

    public AudioClip flyClip;
    public AudioClip gameOverClip;

    private AudioSource audioSource;

    public Animator anim;
    
    
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        flyFower = 20;

        audioSource = obj.GetComponent<AudioSource>();
        audioSource.clip = flyClip;


        anim = obj.GetComponent<Animator>();
        anim.SetFloat("flyPower", 0);
        anim.SetBool("isDead", false);

        if (gameController == null)
        {
            gameController = GameObject.FindGameObjectWithTag("GameController");
        }    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (gameController.GetComponent<GameController>().isEndGame == false)
            {
                audioSource.Play();
            }  
            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, flyFower));

            
        }
        anim.SetFloat("flyPower", obj.GetComponent<Rigidbody2D>().velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EndGame();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameController.GetComponent<GameController>().getPoint();
    }
    void EndGame()
    {
        
        Debug.Log("End Game");
        audioSource.clip = gameOverClip;
        audioSource.Play();

        anim.SetBool("isDead", true);

        gameController.GetComponent<GameController>().EndGame();
    }
}
