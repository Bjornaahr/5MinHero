using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControllPanel : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI alltiudeTxt, headingTxt, navTxt;

    [SerializeField]
    int heading, alt;

    [SerializeField]
    float NAV;

    Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //Ray hitting diffrent knobs to be truned
        //If scroll wheel is used we increment the diffrent values
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
        if (hit)
        {
            if (hit.collider.name == "VHFNAV Knob")
            {
                NAV += Input.mouseScrollDelta.y;
            }

            if (hit.collider.name == "HDG Knob")
            {
                heading += (int) Input.mouseScrollDelta.y;
                heading = heading % 360;

                if (heading < 0)
                {
                    heading = 359;
                }

            }

            if (hit.collider.name == "Alt Knob")
            {
                alt += (int) Input.mouseScrollDelta.y * 100;
            }
        }
        //Set the text
        navTxt.text = NAV.ToString("F2");
        alltiudeTxt.text = alt.ToString();
        headingTxt.text = heading.ToString();
    }
}
