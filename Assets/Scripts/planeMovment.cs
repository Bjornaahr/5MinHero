using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class planeMovment : MonoBehaviour
{
    [SerializeField]
    float speed, gravity, pitchRate;
    [SerializeField]
    float zRotation;

    Rigidbody2D rigidBod2D;

    [SerializeField]
    ParticleSystem fireBall, smoke;

    bool landed = false;

    [SerializeField]
    TextMeshProUGUI success;

    [SerializeField]
    GameObject endBtn, restartBtn;

    int failed;


    void Awake()
    {
        failed = PlayerPrefs.GetInt("Failed");
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidBod2D = gameObject.GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Check if plane is not landed and did not fail controlling the plane
        if(!landed && failed != 1){
        if(Input.GetKey(KeyCode.A)){
            //Rotates the rigidbody according to the pitch rate of the plane
            zRotation = pitchRate * Time.deltaTime;
            rigidBod2D.MoveRotation(rigidBod2D.rotation + zRotation);
        }

        else if(Input.GetKey(KeyCode.D)){
            //Rotates the rigidbody according to the pitch rate of the plane
            zRotation = -pitchRate * Time.deltaTime;
            rigidBod2D.MoveRotation(rigidBod2D.rotation + zRotation);
        }
        //Moves the plane forward
        rigidBod2D.MovePosition(transform.position + -transform.right * speed * Time.deltaTime);
        } 

        //Plane landed
        else if(failed != 1){
            transform.rotation = Quaternion.RotateTowards(transform.rotation, new Quaternion(0,180,-1,0), 1f * Time.deltaTime);
            rigidBod2D.simulated = false;

        } else if (!landed && failed == 1) //Failed controlling the plane, resutling in crashing the plane
        {
            transform.localEulerAngles = new Vector3(0.6f, 180, 21);
            rigidBod2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        }


    }

    private void OnCollisionEnter2D(Collision2D coll) {
        //Check if missed the runway
        if(coll.gameObject.name == "Ground"){
            landed = true;
            rigidBod2D.simulated = false;
            Explode();
        }


            //Check if it hit the runway
          if(coll.gameObject.name == "Runway"){
            landed = true;
            //Check if the plane crashed into the runway
            if(transform.localEulerAngles.z <= 345  &&  transform.localEulerAngles.z >= 5){
                Explode();
            } else{
                success.gameObject.SetActive(true);
                ActivateUI();
                Debug.Log("Success");
            }
        }
    }

    //Plays  particle effects for explosion and set the text to failed
    void Explode(){
        Debug.Log("Explode");
        fireBall.Play();
        smoke.Play();

        success.text = "You failed saving 162 lives today, but still a hero in some eyes";
        success.gameObject.SetActive(true);

        ActivateUI();
    }

    //Activates the UI for restarting and quitting the game
    void ActivateUI()
    {
        endBtn.SetActive(true);
        restartBtn.SetActive(true);
    }


}
