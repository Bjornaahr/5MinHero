using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeMovment : MonoBehaviour
{
    [SerializeField]
    float speed, gravity, pitchRate;
    [SerializeField]
    float zRotation;

    Rigidbody2D rigidBod2D;

    bool landed = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidBod2D = gameObject.GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(!landed){
        if(Input.GetKey(KeyCode.A)){
            zRotation = pitchRate * Time.deltaTime;
            rigidBod2D.MoveRotation(rigidBod2D.rotation + zRotation);
        }

        else if(Input.GetKey(KeyCode.D)){
            zRotation = -pitchRate * Time.deltaTime;
            rigidBod2D.MoveRotation(rigidBod2D.rotation + zRotation);
        }
        
        rigidBod2D.MovePosition(transform.position + -transform.right * speed * Time.deltaTime);
        } 

        else{
            transform.rotation = Quaternion.RotateTowards(transform.rotation, new Quaternion(0,180,-1,0), 1f * Time.deltaTime);
            rigidBod2D.simulated = false;

        }

    }

    private void OnCollisionEnter2D(Collision2D coll) {
        if(coll.gameObject.name == "Ground"){
            landed = true;
            Debug.Log("Explode");
        }



          if(coll.gameObject.name == "Runway"){
            landed = true;
            Debug.Log("Success");
        }
    }

}
