using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 10f; 
    private float movementX;
    private Rigidbody2D myBody;
    private Animator aim;
    private SpriteRenderer spriteRenderer;
    private const string WALK_ANIMATION = "Walk";
    private static string GROUND_TAG = "Ground";
    public static string ENEMY_TAG = "Enemy";
    [SerializeField]
    private bool isGrounded;
    private void Awake() {
        myBody = GetComponent<Rigidbody2D>();
        aim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
    }
    private void PlayerMoveKeyboard(){
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f)*Time.deltaTime*moveForce;
    }
    private void FixedUpdate() {
        PlayerJump();
    }
    private void AnimatePlayer(){
       if (movementX >0)
       {
            aim.SetBool(WALK_ANIMATION, true);
            //spriteRenderer.flipX = false;
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
       else if(movementX<0)
       {
            aim.SetBool(WALK_ANIMATION, true);
            // spriteRenderer.flipX = true;
            transform.localScale = new Vector3(-1f, 1f, 1f);

        }
        else{

            aim.SetBool(WALK_ANIMATION, false);
        }
    }
    private void PlayerJump(){
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse); 
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
       if (other.gameObject.CompareTag(GROUND_TAG))
            isGrounded = true;
       else if(other.gameObject.CompareTag(ENEMY_TAG))
            Destroy(gameObject); 
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag(ENEMY_TAG))
            Destroy(gameObject);
    }
}
