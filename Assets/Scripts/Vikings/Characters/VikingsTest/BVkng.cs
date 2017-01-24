using UnityEngine;
using System.Collections;

public class BVkng : MonoBehaviour
{


    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private Transform[] groundPoints;

    private FacingDirection facingDirection;

    [SerializeField]
    private float goundRadius;

    [SerializeField]
    private LayerMask whatisGround;

    //private bool isGrounded;// removed for refactoring
    //private bool jump;// removed for refactoring
    //private bool jumpAttack;// removed for refactoring
    //private bool attack;// removed for refactoring

    [SerializeField]
    private bool airControl;

    [SerializeField]
    private float jumpForce;

    private Animator myAnimator;
    //private bool slide;// removed for refactoring

    public InputState InputState { get; set; }
    public Rigidbody2D MyRigidBody { get; set; }

    public bool Attack { get; set; }
    public bool Slide { get; set; }
    public bool Jump { get; set; }
    public bool OnGround { get; set; }


    // Use this for initialization
    void Start()
    {
        facingDirection = FacingDirection.RIGHT;
        MyRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    void updt()
    {
        HandleInput();
    }



    void fxdUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        OnGround = IsGrounded();
        HandleMovement(horizontal);
        Flip(horizontal);
        //handleAttacks();// removed for refactoring
        HandleLayers();
        //reset();// removed for refactoring
    }




    // Update is called once per frame
    void Update()
    {

    }

    private void HandleMovement(float horizontal)
    {

        if (MyRigidBody.velocity.y < 0)
        {
            myAnimator.SetBool("land", true);
        }

        if (!Attack && !Slide && (OnGround || airControl))
        {
            MyRigidBody.velocity = new Vector2(horizontal * movementSpeed, MyRigidBody.velocity.y);
        }

        if (Jump && MyRigidBody.velocity.y == 0)
        {
            MyRigidBody.AddForce(new Vector2(0, jumpForce));
        }

        myAnimator.SetFloat("speed", Mathf.Abs(horizontal));



        //if (myRigidBody.velocity.y < 0)// removed for refactoring
        //{
        //    myAnimator.SetBool("land", true);
        //}
        //if (!myAnimator.GetBool("slide") && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Attacking"))
        //{
        //    myRigidBody.velocity = new Vector2(horizontal * movementSpeed, myRigidBody.velocity.y);

        //}
        //else if (!this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Slide"))
        //{
        //    myAnimator.SetBool("slide", false);

        //}

        //myAnimator.SetFloat("speed", Mathf.Abs(horizontal));
    }

    //private void handleAttacks()// removed for refactoring
    //{
    //    if (attack && isGrounded && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
    //    {
    //        myAnimator.SetTrigger("attack");
    //        myRigidBody.velocity = Vector2.zero;
    //    }

    //    if (jumpAttack && isGrounded && this.myAnimator.GetCurrentAnimatorStateInfo(1).IsName("JumpAttack"))
    //    {
    //        myAnimator.SetBool("jumpAttack", true);
    //    }
    //    if (!jumpAttack && !this.myAnimator.GetCurrentAnimatorStateInfo(1).IsName("JumptAttack"))
    //    {
    //        myAnimator.SetBool("jumpAttack", false);
    //    }
    //}

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myAnimator.SetTrigger("jump");
            //jump = true;// removed for refactoring
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            myAnimator.SetTrigger("attack");
            //attack = true;// removed for refactoring
            //jumpAttack = true;// removed for refactoring
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            myAnimator.SetTrigger("slide");
            //slide = true;// removed for refactoring
        }
    }

    private void Flip(float horizontal)
    {
        if (horizontal > 0 && facingDirection == FacingDirection.LEFT || horizontal < 0 && facingDirection == FacingDirection.RIGHT)
        {
            switch (facingDirection)
            {
                case FacingDirection.RIGHT:
                    facingDirection = FacingDirection.LEFT;
                    break;
                case FacingDirection.LEFT:
                    facingDirection = FacingDirection.RIGHT;
                    break;
            }
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;

        }
    }

    //void Reset()// removed for refactoring
    //{
    //    attack = false;
    //    slide = false;
    //    jump = false;
    //    jumpAttack = false;

    //}

    private bool IsGrounded()
    {
        if (MyRigidBody.velocity.y <= 0)
        {
            foreach (Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, goundRadius, whatisGround);
                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                        //myAnimator.ResetTrigger("jump");
                        //myAnimator.SetBool("land", false); // removed for refactoring
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private void HandleLayers()
    {
        if (!OnGround)
        {
            myAnimator.SetLayerWeight(1, 1);
        }
        else
        {
            myAnimator.SetLayerWeight(1, 0);
        }
    }
}
