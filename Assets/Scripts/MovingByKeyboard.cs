using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingByKeyboard : MonoBehaviour
{ 
    public Animator animator;

    public ShieldController shieldControll;

    public ManaBar manabar;

    public HpBar hpbar;

    public GameObject player;

    public float moveHorizontal;

    public float jumpVelocity = 2.9f; // jump value.

    public float speed = 0.5f; // movement's value.

    float movement; // variable responsible for the value of movement.

    bool isCrouch = false; // Variable responsible for checking if player is couching.

    bool isAir = false; // Variable responsible for checking if player is in the air.

    bool isManaEmpty = false; // Variable responsible for checking if player's mana is empty. (Connected with ShieldController and ManaBar Class)

    bool isCrouchPressed = false; // Variable needed for chcecking if crouch button is pressed.

    Rigidbody2D rB2D;

    SpriteRenderer SR;

    void Start()
    {

        SR = GetComponent<SpriteRenderer>();

        rB2D = GetComponent<Rigidbody2D>();
    }

    // Main Function responsible for animation and movement.
    void Update()
    {
        Movement();

        Animation();
    }


    //------------------ Used for calculations, a character controller ------------------
    void Movement()
    {
        movement = Input.GetAxisRaw("Horizontal");
        this.transform.position += new Vector3(movement * speed * Time.deltaTime, 0, 0);

        Debug.Log(movement);
        // Removes the player when his health drops to zero.
        if (hpbar.hp.hpAmount == 0)
        {
            Destroy(player);
        }

        // If the player crouch, he can not move.
        if (isCrouch == true)
        {
            movement = 0;
            jumpVelocity = 0;
        }
        else
        {
            jumpVelocity = 2.9f;
        }
        
        // Change the sprite direction of the player, depending on the direction of movement (movement)
        if (movement > 0)
        {
            SR.flipX = false;

        }
        else if (movement < 0)
        {
            SR.flipX = true;
        }

        // The jump mechanics function.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        // Mechanics of crouching
        if (isCrouchPressed == true || Input.GetKey(KeyCode.S))
        {
            // If the player does not have mana, then crouching mechanics are interrupted.
            if (isManaEmpty == true)
            {
                speed = .5f;
                isCrouch = false;
                return;
            }

            // If the player is in the air, disable all mechanisms and shields.
            if (isAir == true) { return; }

            manabar.ShieldWhenS();
            speed = 0;
            isCrouch = true;
            shieldControll.Enable();

            // If we use mana, bool isManaEmpty = true, it causes mana regeneration to start, Class::ManaBar
            if (manabar.mana.manaAmount <= 2)
            {
                isManaEmpty = true;
            }
            return;
        }
        else
        {
            // When mana is over 50%, player is able to restart the crouch.
            if (manabar.mana.manaAmount > 50)
            {
                isManaEmpty = false;
            }

            // isManaEmpty = false.
            // Enables walking, disables crouching and shield.
            speed = .5f;
            isCrouch = false;
            shieldControll.Disable();
        }

        // Enables walking with the joystick.
        this.transform.position += new Vector3(movement * Time.deltaTime, 0, 0);
    }

    //------------------ Script to animate the character ------------------
    void Animation()
    {

        // Jump animation

        // When velocity y is greater than 0.1, turns on the jump animation and sets isAir to true - the first phase of the jump. (rising)
        if (rB2D.velocity.y > 0.1f)
        {
            animator.SetBool("IsJump", true);
            isAir = true;
        }

        // When velocity y is less than -0.1, it activates the falling animation and disables the jump.
        // Sets isAir to true - the second phase of the jump. (falling)
        else if (rB2D.velocity.y < -0.1f)
        {
            animator.SetBool("IsFall", true);
            animator.SetBool("IsJump", false);
            isAir = true;
        }

        // When velocity y equals 0, it disables the falling and jump animation.
        // Sets also isAir to false.
        else if (rB2D.velocity.y == 0)
        {
            animator.SetBool("IsFall", false);
            animator.SetBool("IsJump", false);
            isAir = false;
        }

        // When crouching is active, it activates animation of it.
        if (isCrouchPressed == true || Input.GetKey(KeyCode.S))
        {
            // Disables the animation if mana is equal to 0.
            if (isManaEmpty == true)
            {
                animator.SetBool("IsCrouch", false);
                return;
            }

            // Does not enable animation if we are in the air.
            if (isAir == true) { return; }
            animator.SetBool("IsCrouch", true);
            animator.SetFloat("Speed", 0);
            return;
        }
        else

        // When crouching is inactive, turn off the animation.
        {
            animator.SetBool("IsCrouch", false);
        }

        // Walking animation - Joystick.
        animator.SetFloat("Speed", Mathf.Abs(movement));
    }

    //Button - Jump
    public void Jump()
    {
        // Gives values ​​to the jump if velocity y is equal to 0.
        if (rB2D.velocity.y == 0)
        {
            rB2D.AddForce(transform.up * jumpVelocity, ForceMode2D.Impulse);
        }
    }

    //Button - Crouching
    public void CrouchDown()
    {
        isCrouchPressed = true;
    }

    //Button - Stand up
    public void CrouchUp()
    {
        isCrouchPressed = false;
    }

    // For testing - full mana button.
    public void FullMana()
    {
        manabar.mana.manaAmount = 100;

        isManaEmpty = false;
    }

    // For testing - full hp button.
    public void FullHp()
    {
        hpbar.hp.hpAmount = 100;
    }
}