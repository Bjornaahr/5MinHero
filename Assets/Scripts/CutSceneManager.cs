using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CutSceneManager : MonoBehaviour
{

    [SerializeField]
    GameObject cutScene;
    [SerializeField]
    Sprite before, after;

    SpriteRenderer spriteRenderer;

    [SerializeField]
    TextMeshProUGUI flightAttendantText;

    int index;

    [SerializeField]
    GameObject m_Camera;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = cutScene.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && index == 0){
            flightAttendantText.text = "All of our pilots are incapacitated, and we need one of you to pilot the plane";
            spriteRenderer.sprite = after;
            index++;
        }

         else if(Input.GetButtonDown("Fire1") && index == 1){
            flightAttendantText.text = "Don't worry ATC will tell you what to do";
            index++;
        } 

        else if(Input.GetButtonDown("Fire1") && index == 2){
            m_Camera.transform.position = new Vector3(21,0,-1);
        }

    }
}
