using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPlatformer : MonoBehaviour
{
    [SerializeField] public float maxSpeed;
    [SerializeField] float speedUpLerpValue;
    [SerializeField] float jumpHeight;
    [SerializeField] float slowDownForce;
    [SerializeField] float damageWaitForSeconds;
    [SerializeField] Canvas gameOver;

    [SerializeField] public GameObject heldObject;
    
    InputAction movementAction;
    InputAction throwAction;
    Rigidbody2D rb;
    SpriteRenderer sprite;
    Animator animator;
    
    bool canJump = false;
    bool canThrow = true;
    bool damageSlowDown = false;
    public bool swinging = false;

    public bool Grounded { get { return canJump; } }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movementAction = GetComponent<PlayerInput>().actions["move"];
        throwAction = GetComponent<PlayerInput>().actions["throw"];
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        //AudioManager.Instance.MusicUnpause();
    }

    public void FixedUpdate()
    {
        //if (!GameManager.Instance.isPlaying())
        //    return;


        if (Physics2D.Raycast(transform.position, Vector2.down, 1.5f))
            canJump = true;
        else
            canJump = false;

        float dir = movementAction.ReadValue<float>();
        //Debug.Log(dir);

        if (!damageSlowDown)
            rb.velocity = Vector2.Lerp(rb.velocity, new(dir * maxSpeed, rb.velocity.y), Time.fixedDeltaTime * speedUpLerpValue);
        else
            rb.velocity = Vector2.Lerp(rb.velocity, new((dir * maxSpeed)/2.0f, rb.velocity.y), Time.fixedDeltaTime * speedUpLerpValue);

        animator.SetBool("GoingUp", rb.velocity.y > 0);

        if (dir != 0)
        {
            animator.SetBool("Running", true);
            animator.SetBool("Flip", dir < 0);
        }
        else if ((int) Math.Abs(rb.velocity.x) == 0)
            animator.SetBool("Running", false);

        if (heldObject != null)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            Vector3 direction = (mousePos - transform.position);
            direction.Normalize();

            float dist = Vector2.Distance(mousePos, transform.position);

            if (PickupManager.Instance != null && dist < PickupManager.Instance.PickupRadius)
                heldObject.transform.position = mousePos;
            else
                heldObject.transform.position = transform.position + direction * PickupManager.Instance.PickupRadius;

            Rigidbody2D objRB = heldObject.GetComponent<Rigidbody2D>();
            Collider2D collider = heldObject.GetComponent<Collider2D>();

            if (objRB.gravityScale != 0)
                objRB.gravityScale = 0;

            if (!objRB.freezeRotation)
                objRB.freezeRotation = true;

            if (collider.enabled)
                collider.enabled = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.CompareTag("Obstacle"))
        //{
        //    damageSlowDown = true;
        //    rb.AddForce(new(-(rb.velocity.x)/2.0f, 0), ForceMode2D.Impulse);
        //    Camera.main.GetComponent<CameraFollow>().SetDamageCameraTimer(damageWaitForSeconds);
        //    //wallOfDeath.DamageGainOnPlayer(damageWaitForSeconds);
        //    //StopAllCoroutines();
        //    StartCoroutine(DamageBlink());
        //}

        //if (collision.CompareTag("WallOfDeath"))
        //{
        //    //GameManager.Instance.GameOver();
        //    AudioManager.Instance.MusicPause();
        //    AudioManager.Instance.FXDefeat();
        //    Debug.Log("Game Over >:(");
        //    gameOver.enabled = true;
        //}
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetTrigger("Land");
    }

    public void PickupObject(GameObject obj)
    {
        heldObject = obj;

        //StartCoroutine(PickupTimeout());
    }

    IEnumerator PickupTimeout()
    {
        canThrow = false;
        yield return new WaitForSeconds(0.5f);
        canThrow = true;
    }

    IEnumerator DamageBlink()
    {
        animator.SetTrigger("Ouchie");
        //AudioManager.Instance.FXObjectHit();
        for (int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(damageWaitForSeconds / 8.0f);
            sprite.color = new(sprite.color.r, sprite.color.g, sprite.color.b, 0.5f);
            yield return new WaitForSeconds(damageWaitForSeconds / 8.0f);
            sprite.color = new(sprite.color.r, sprite.color.g, sprite.color.b, 1f);
        }
        damageSlowDown = false;
        yield return null;
    }

    public void Jump(InputAction.CallbackContext context) 
    {
        if (swinging && context.action.ReadValue<float>() != 0)
        {
            animator.SetBool("Swinging", false);
            GetComponentInParent<Vine>().ExitVine(this);
            return;
        }

        if (canJump && context.action.ReadValue<float>() != 0)
        {
            animator.SetTrigger("Jump");
            rb.AddForce(new(0, jumpHeight), ForceMode2D.Impulse);
            canJump = false;
        }
    }

    public void ThrowObject(InputAction.CallbackContext context)
    {
        if (heldObject == null)
            return;
        
        Rigidbody2D objRB = heldObject.GetComponent<Rigidbody2D>();
        Collider2D objCollider = heldObject.GetComponent<Collider2D>();

        Debug.Log(context.action.ReadValue<float>());

        if (canThrow && context.action.ReadValue<float>() != 0)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            Vector3 direction = (mousePos - transform.position);
            direction.Normalize();

            objRB.AddForce(direction * maxSpeed, ForceMode2D.Impulse);
            objRB.gravityScale = 2;
            objRB.freezeRotation = false;
            objCollider.enabled = true;
            heldObject = null;
        }
    }

    public void DropObject(InputAction.CallbackContext context)
    {
        if (heldObject == null)
            return;

        Rigidbody2D objRB = heldObject.GetComponent<Rigidbody2D>();
        Collider2D objCollider = heldObject.GetComponent<Collider2D>();

        Debug.Log(context.action.ReadValue<float>());

        if (canThrow && context.action.ReadValue<float>() != 0)
        {
            objRB.gravityScale = 2;
            objRB.freezeRotation = false;
            objCollider.enabled = true;
            heldObject = null;
        }
    }
}
