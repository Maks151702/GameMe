using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Charater : MonoBehaviour 
	{
                public float posx=0;
                public float posy=0;
		public float maxSpeed = 10f;
        public float jumpForce = 700f;
        bool facingRight = true;
        bool grounded = false;
        public Transform groundCheck;
        public float groundRadius = 0.2f;
        public LayerMask whatIsGround;
        public float move;
				private Animator anim;
 				private Rigidbody2D rb;
 				private Collider2D coll;
 				public GameObject currentCheckpoint;
 				public LevelManager levelManager;
 				
        // Use this for initialization
        void Start () {
        				levelManager=FindObjectOfType<LevelManager>();
 						rb = GetComponent<Rigidbody2D>();
 						anim = GetComponent<Animator>();
 						coll = GetComponent<Collider2D>();
        				coll.isTrigger = true;
        }

        // Update is called once per frame
        void FixedUpdate () {


                grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);

                anim.SetBool ("Ground", grounded);
				//устанавливаем в аниматоре значение скорости взлета/падения
				anim.SetFloat ("vSpeed", GetComponent<Rigidbody2D>().velocity.y);
		        //если персонаж в прыжке - выход из метода, чтобы не выполнялись действия, связанные с бегом
		        if (!grounded)
		            return;

                move = Input.GetAxis ("Horizontal");

                anim.SetFloat("Speed", Mathf.Abs(move));

        }

        void Update(){

        		posx=rb.position.x;
                        posy=rb.position.y;
                if (grounded && (Input.GetKeyDown (KeyCode.W)||Input.GetKeyDown (KeyCode.UpArrow))) {

                        rb.AddForce (new Vector2(0f,jumpForce));
                        anim.Play("Jump");
                }
								
                rb.velocity = new Vector2 (move * maxSpeed, rb.velocity.y);

                if (move > 0 && !facingRight)
                        Flip ();
                else if (move < 0 && facingRight)
                        Flip ();

                if (Input.GetKey(KeyCode.R))
                {
                        levelManager.RespawnPlayer();
                }


        }

     	    private void OnTriggerEnter2D(Collider2D collision)
		{
    	    coll.isTrigger = rb.velocity.y > 0;
    	    if(Input.GetKey(KeyCode.S)||Input.GetKeyDown (KeyCode.DownArrow)){
    	    	coll.isTrigger = false;
    	    }
   		 }
 
  		  private void OnCollisionExit2D(Collision2D collision)
  		  {
    	    coll.isTrigger = true;
    	    
   		 }

        void Flip(){
                facingRight = !facingRight;
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
        }

        
}
