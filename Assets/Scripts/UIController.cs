using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI heightTxt, speedTxt, distanceToAirfield;

    Vector3 prevPos;
    //Point at the start of the runway
    [SerializeField]
    Transform runway;

    // Start is called before the first frame update
    void Start()
    {
        prevPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        heightTxt.text = "Alltitude: " + (transform.position.y * 10).ToString("F0") + "feet";

        Vector3 velocity =  (transform.position - prevPos) / Time.fixedDeltaTime;

        speedTxt.text = "Speed: " + (velocity.magnitude * 10).ToString("F2") + "knots";

        prevPos = transform.position;

        distanceToAirfield.text = "Distance to runway: " + Mathf.Abs((transform.position.x - runway.position.x)).ToString("F0") + " km";


    }
}
