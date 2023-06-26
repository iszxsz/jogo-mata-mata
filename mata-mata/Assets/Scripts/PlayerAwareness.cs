using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwareness : MonoBehaviour
{
    public bool AwareOfPlayer { get; private set; }

    public Vector2 DirectionToPlayer {get; private set;}

    [SerializeField]
    private float _playerAwernessDistance;

    private Transform _player;

    private void Awake(){
        _player = FindObjectOfType<PlayerMovement>().transform;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayerVector = _player.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector.normalized;

        if(enemyToPlayerVector.magnitude <= _playerAwernessDistance){
            AwareOfPlayer = true;
        }
        else {
             AwareOfPlayer = false;
        }
    }
}
