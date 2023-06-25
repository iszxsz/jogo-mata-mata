using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitBox : MonoBehaviour
{
    public Collider2D swordCollider;
    
    public float swordDamage = 1f;
    // Start is called before the first frame update

    public Vector3 faceRight = new Vector3(1, -0.9f, 0);

    public Vector3 faceLeft = new Vector3(-1, -0.9f, 0);


    void Start(){
        if(swordCollider == null){
            Debug.LogWarning("sword Collider not set");
        }
        swordCollider.GetComponent<Collider2D>();
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.CompareTag("slime")){
        col.collider.SendMessage("OnHit", swordDamage);
        Debug.Log("oiiiiiiiiiiiii");
        }
       
    }

    /*void OnTriggerEnter2D(Collider2D collider){
        collider.SendMessage("OnHit", swordDamage);
    }*/
    
    // Update is called once per frame
    void Update()
    {
    }

    void isFacingRight(bool isFacingRight){
        if(isFacingRight){
            gameObject.transform.position = faceRight;
        }
        else{
            gameObject.transform.position = faceLeft;
        }
    }
}
