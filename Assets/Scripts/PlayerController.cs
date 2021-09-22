using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float velocityX = 10;
    public float jumpforce = 50;

    public GameObject rightBall;
    public GameObject leftBall;

    public List<AudioClip> audioClips;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    
    private ScoreController _scoreController;

    private AudioSource _audioSource;
    
    private Animator _animator;

    private bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _scoreController = FindObjectOfType<ScoreController>();
        _audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            _animator.SetInteger("Estado",0);

            if (Input.GetKey(KeyCode.RightArrow))
            {
                rb.velocity=new Vector2(velocityX, rb.velocity.y);
                sr.flipX = false;
                _animator.SetInteger("Estado",1);
            }
            
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb.velocity=new Vector2(-velocityX, rb.velocity.y);
                sr.flipX = true;
                _animator.SetInteger("Estado",1);
            }
            
            if (Input.GetKeyUp(KeyCode.Space))
            {
                rb.AddForce(Vector2.up*jumpforce,ForceMode2D.Impulse);
                _animator.SetInteger("Estado",2);
                _audioSource.PlayOneShot(audioClips[1]);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                rb.velocity = Vector2.right*velocityX;
                sr.flipX = false;
                _animator.SetInteger("Estado",3);
            }
            
            if (Input.GetKeyUp(KeyCode.C))
            {
                var bullet = sr.flipX ? leftBall : rightBall;
                var position = new Vector2(transform.position.x,transform.position.y);
                var rotation = rightBall.transform.rotation;
                Instantiate(bullet, position, rotation);
                _audioSource.PlayOneShot(audioClips[0]);
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MonedaBronce"))
        {
            Destroy(collision.gameObject);
            _scoreController.PlusBronce(1);
            Debug.Log(_scoreController.GetBronce());
            _audioSource.PlayOneShot(audioClips[2]);
            SceneManager.LoadScene("Scene02");
        }
        
        if (collision.gameObject.CompareTag("MonedaPlata"))
        {
            Destroy(collision.gameObject);
            _scoreController.PlusPlata(1);
            Debug.Log(_scoreController.GetPlata());
            _audioSource.PlayOneShot(audioClips[2]);
        }
        
        if (collision.gameObject.CompareTag("MonedaOro"))
        {
            Destroy(collision.gameObject);
            _scoreController.PlusOro(1);
            Debug.Log(_scoreController.GetOro());
            _audioSource.PlayOneShot(audioClips[2]);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        /*else if (collision.gameObject.CompareTag("Enemigo"))
        {
            isDead = true;
            _animator.SetInteger("Estado",-1);
            Time.timeScale = 0f;
        }*/
        
    }
    
}