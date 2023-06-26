using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject _slime;

    [SerializeField]
    private float _minSpawnTime;

    [SerializeField]
    private float _maxSpawnTime;

    private float _timeUntilSpawn;
    // Start is called before the first frame update
    void Awake()
    {
        SetTimeUntilSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        _timeUntilSpawn -= Time.deltaTime;

        if(_timeUntilSpawn <= 0){
            if (_slime != null) // Verifica se o objeto _slime ainda existe
            {
                Instantiate(_slime, transform.position, Quaternion.identity);
                SetTimeUntilSpawn();
            }
        }
    }
    private void SetTimeUntilSpawn(){
        _timeUntilSpawn = Random.Range(_minSpawnTime, _maxSpawnTime);
    }
}
