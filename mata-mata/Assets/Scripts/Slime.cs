using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{

    
    Animator animator; 
    bool isAlive = true; 

    public float Health {
        set {
            if(value < _health){
                animator.SetTrigger("hit");
            }

            _health = value;

            if(_health <= 0){
                animator.SetBool("isAlive", false);
            }
        }
        get{
            return _health;
        }
    
    }

    public float _health = 3;

    public void Start(){
        animator = GetComponent<Animator>();
        animator.SetBool("isAlive", isAlive);
    }

    void OnHit(float damage){
        Health -= damage;
        Debug.Log("Slime hit for " + damage);
       
    }
    // Start is called before the first frame update

    
}
