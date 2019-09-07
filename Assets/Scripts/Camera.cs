using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    [SerializeField]
    Transform plane;

    [SerializeField]
    float offsetY, offsetX, distance, smoothTime;

    private Vector3 velocity = Vector3.zero;
    Vector3 targetPos;

    private void Awake() {
    
    }

    // Start is called before the first frame update
    void Start()
    {
        plane = GameObject.FindGameObjectWithTag("Plane").transform;
    }
    
    private void FixedUpdate() {
        if(plane.position.y > 40f){
        targetPos = new Vector3(plane.position.x + offsetX, plane.position.y + offsetY, distance);
        } else {
            targetPos = new Vector3(plane.position.x + offsetX, 30, distance);
        }

        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }
}
