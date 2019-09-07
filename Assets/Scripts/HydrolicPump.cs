using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HydrolicPump : MonoBehaviour
{
    Camera camera;
    Vector3 startPos;
    [SerializeField]
    Canvas canvas;
    RectTransform rectTransform;
    GameObject indicatorHandler, cutSceneManager;

    [SerializeField]
    float handleOffset;

    bool canHold;
    bool topPump;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        rectTransform = GetComponent<RectTransform>();
        startPos = rectTransform.position;
        indicatorHandler = GameObject.FindGameObjectWithTag("IndicatorHandler");
        cutSceneManager = GameObject.FindGameObjectWithTag("CutsceneManager");


    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
        if (hit)
        {
            if (hit.collider.name == "PumpHandle")
            {
                canHold = true;
            }
        }


        if (Input.GetMouseButton(0) && canHold)
        {
            Vector3 pos = Input.mousePosition;


            if (camera.ScreenToWorldPoint(pos).y <= 179.4 && camera.ScreenToWorldPoint(pos).y >= 110) {
                rectTransform.position = new Vector3(rectTransform.position.x, camera.ScreenToWorldPoint(pos).y - handleOffset, 79);
            }

            if (rectTransform.position.y >= 135 || rectTransform.position.y <= 80)
            {
                Pump();
                

            }

        } else if(Input.GetMouseButtonUp(0) && canHold)
        {
            canHold = false;
        }

    



    }


    void Pump()
    {
        if (rectTransform.position.y >= 135)
        {
            topPump = true;
        }

        if(rectTransform.position.y <= 80 &&  topPump)
        {
            Debug.Log("Pump");
            ExecuteEvents.Execute<ICustomMessage>(indicatorHandler, null, (x, y) => x.pumpingHydrolics());
            ExecuteEvents.Execute<ICustomMessage>(cutSceneManager, null, (x, y) => x.pumpingHydrolics());

            topPump = false;
        }

    }

}
