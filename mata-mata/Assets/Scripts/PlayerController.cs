using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _playerRigidbody2D;
    private Animator _playerAnimator;
    private SpriteRenderer _spriteRenderer;
    private Collider2D _swordCollider;
    private bool _canMove = true;

    public float _playerSpeed;
    public float maxSpeed = 8f;
    public float idleFriction = 0.9f;

    private Vector2 _moveInput = Vector2.zero;

    void Start()
    {
        _playerRigidbody2D = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _swordCollider = GetComponentInChildren<Collider2D>();
    }

    void Update()
    {
        _moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (_moveInput.sqrMagnitude > 0)
        {
            _playerAnimator.SetInteger("Movimento", 1);
        }
        else
        {
            _playerAnimator.SetInteger("Movimento", 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnFire();
        }
    }

    void FixedUpdate()
    {
        if (_canMove && _moveInput != Vector2.zero)
        {
            _playerRigidbody2D.MovePosition(_playerRigidbody2D.position + _moveInput * _playerSpeed * Time.deltaTime);

            if (_moveInput.x > 0)
            {
                _spriteRenderer.flipX = false;
            }
            else if (_moveInput.x < 0)
            {
                _spriteRenderer.flipX = true;
            }
        }
        else
        {
            _playerRigidbody2D.velocity = Vector2.Lerp(_playerRigidbody2D.velocity, Vector2.zero, idleFriction);
        }
    }

    void OnFire()
    {
        _playerAnimator.SetTrigger("swordAttack");
    }

    void OnDie()
    {
        _playerAnimator.SetTrigger("death");
    }

    void LockMovement()
    {
        _canMove = false;
    }

    void UnlockMovement()
    {
        _canMove = true;
    }
}
