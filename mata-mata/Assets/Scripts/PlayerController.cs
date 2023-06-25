using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    /*bool isMoving{
        set{
            isMoving = value;
            _playerAnimator.SetBool("isMoving". isMoving);
        }
    }*/
    private Rigidbody2D _playerRigidbody2D;
    private Animator _playerAnimator;
    public float _playerPosition;
    public float _playerSpeed;
    public float maxSpeed = 8f;
    public float idleFriction = 0.9f;   
    //private Vector2 _playerDirection;//determina os eixos 

    public GameObject swordHitBox;
    
    Vector2 moveInput = Vector2.zero;
    SpriteRenderer spriteRenderer;
    bool canMove = true;

    Collider2D swordCollider;
    // Start is called before the first frame update
    void Start(){
        _playerRigidbody2D = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        swordCollider = swordHitBox.GetComponent<Collider2D>();
        
    }

    // Update is called once per frame
    void Update(){
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if(moveInput.sqrMagnitude > 0){
            _playerAnimator.SetInteger("Movimento", 1);
        }
        else{
            _playerAnimator.SetInteger("Movimento", 0);
        }

    }

    void FixedUpdate() {
        if(canMove == true && moveInput != Vector2.zero) {
            // Move animation and add velocity

            // Accelerate the player while run direction is pressed
            // BUT don't allow player to run faster than the max speed in any direction
           // _playerRigidbody2D.velocity = _playerRigidbody2D.velocity(_playerRigidbody2D.MovePosition + (moveInput * _playerSpeed * Time.deltaTime), maxSpeed);
            _playerRigidbody2D.MovePosition(_playerRigidbody2D.position + moveInput * _playerSpeed * Time.deltaTime);
            // Control whether looking left or right
            if(moveInput.x > 0) {
                spriteRenderer.flipX = false;
            } else if (moveInput.x < 0) {
                spriteRenderer.flipX = true;
            }

            //isMoving = true;

        } else {
            // No movement so interpolate velocity towards 0
            _playerRigidbody2D.velocity = Vector2.Lerp(_playerRigidbody2D.velocity, Vector2.zero, idleFriction);
            //isMoving = false;
        }
        
    }

    void OnFire(){
        _playerAnimator.SetTrigger("swordAttack");
    }

    void LockMovement(){
        canMove = false;
    }

    void UnlockMovement(){
        canMove = true;
    }
}
