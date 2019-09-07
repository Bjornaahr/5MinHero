using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LandingGear : MonoBehaviour
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

    bool canMoveX, canMoveY;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        rectTransform = GetComponent<RectTransform>();
        startPos = rectTransform.position;
        indicatorHandler = GameObject.FindGameObjectWithTag("IndicatorHandler");
        cutSceneManager = GameObject.FindGameObjectWithTag("CutsceneManager");
        canMoveY = true;

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
        if (hit)
        {
            if (hit.collider.name == "LandingGear")
            {
                canHold = true;
            }
        }


        if (Input.GetMouseButton(0) && canHold)
        {
            Vector3 pos = Input.mousePosition;

            // Debug.Log(pos);

            if (canMoveY)
            {
                rectTransform.position = new Vector3(rectTransform.position.x, camera.ScreenToWorldPoint(pos).y + handleOffset, 79);
            }

            if (canMoveX)
            {
                rectTransform.position = new Vector3(camera.ScreenToWorldPoint(pos).x, rectTransform.position.y, 79);
            }

            if (canMoveX && canMoveY)
            {
                rectTransform.position = new Vector3(camera.ScreenToWorldPoint(pos).x, camera.ScreenToWorldPoint(pos).y + handleOffset, 79);
            }

        }
        else if (Input.GetMouseButtonUp(0) && canHold)
        {
            canHold = false;
        }


              if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(rectTransform.position);
        }

        if (rectTransform.position.y <= 289)
        {
            Debug.Log("Can move x");
            canMoveX = true;
        } else
        {
            canMoveX = false;
        }

        //Checks if the landing gear lever is inside bounding box and blocks it from leaving
        if (rectTransform.position.x >= 1471)
        {
            canMoveY = false;
        }
        else canMoveY = true;

        if(rectTransform.position.x < 1435.6f)
        {
            rectTransform.position = new Vector3(1440.5f, rectTransform.position.y, 79);
        } else if (rectTransform.position.x > 1676.6f)
        {
            rectTransform.position = new Vector3(1660.5f, rectTransform.position.y, 79);
        }

        if (rectTransform.position.y > 601)
        {
            rectTransform.position = new Vector3(rectTransform.position.x, 590, 79);
        } else if (rectTransform.position.y < 271)
        {
            rectTransform.position = new Vector3(rectTransform.position.x, 281, 79);
        }


        if(rectTransform.position.x > 1646)
        {
            ExecuteEvents.Execute<ICustomMessage>(indicatorHandler, null, (x, y) => x.landingGear(1));
            ExecuteEvents.Execute<ICustomMessage>(cutSceneManager, null, (x, y) => x.landingGear(1));
        } 


    }
}
