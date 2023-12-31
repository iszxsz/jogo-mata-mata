using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{

    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _rotationSpeed;

    private Rigidbody2D _rigidbody;
    private PlayerAwareness _playerAwernessController;
    private Vector2 _targetDirection;

    // Start is called before the first frame update
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerAwernessController = GetComponent<PlayerAwareness>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
    }

    private void UpdateTargetDirection(){
        if(_playerAwernessController.AwareOfPlayer){
            _targetDirection = _playerAwernessController.DirectionToPlayer;
        }
        else{
            _targetDirection = Vector2.zero;
        }
    }

    private void RotateTowardsTarget(){
        if(_targetDirection == Vector2.zero){
            return;
        }
        else{
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _targetDirection);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        
            _rigidbody.SetRotation(rotation) ;
        }
    }

    private void SetVelocity(){
        if(_targetDirection == Vector2.zero){
            _rigidbody.velocity = Vector2.zero;
        }
        else{
            _rigidbody.velocity = transform.up * _speed;
        }
    }
}
