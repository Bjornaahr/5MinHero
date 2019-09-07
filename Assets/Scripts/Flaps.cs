using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Flaps : MonoBehaviour
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
            if (hit.collider.name == "Flaps")
            {
                canHold = true;
            }
        }


        if (Input.GetMouseButton(0) && canHold)
        {
            Vector3 pos = Input.mousePosition;

            // Debug.Log(pos);

            if (Input.mousePosition.y >= 220.0f && Input.mousePosition.y <= 460.0f)
            {
                rectTransform.position = new Vector3(rectTransform.position.x, camera.ScreenToWorldPoint(pos).y + handleOffset, 79);
            }

        }
        else if (Input.GetMouseButtonUp(0) && canHold)
        {
            canHold = false;
        }

  


        if(rectTransform.position.y <= 240)
        {
            ExecuteEvents.Execute<ICustomMessage>(indicatorHandler, null, (x, y) => x.flaps(0));
            ExecuteEvents.Execute<ICustomMessage>(cutSceneManager, null, (x, y) => x.flaps(0));

        }
        else if(rectTransform.position.y <= 305)
        {
            ExecuteEvents.Execute<ICustomMessage>(indicatorHandler, null, (x, y) => x.flaps(10));
            ExecuteEvents.Execute<ICustomMessage>(cutSceneManager, null, (x, y) => x.flaps(10));

        }
        else if (rectTransform.position.y <= 340)
        {
            ExecuteEvents.Execute<ICustomMessage>(indicatorHandler, null, (x, y) => x.flaps(20));
            ExecuteEvents.Execute<ICustomMessage>(cutSceneManager, null, (x, y) => x.flaps(20));

        }
        else if (rectTransform.position.y <= 400)
        {
          ExecuteEvents.Execute<ICustomMessage>(indicatorHandler, null, (x, y) => x.flaps(30));
            ExecuteEvents.Execute<ICustomMessage>(cutSceneManager, null, (x, y) => x.flaps(30));

        }
        else
        {
          ExecuteEvents.Execute<ICustomMessage>(indicatorHandler, null, (x, y) => x.flaps(35));
          ExecuteEvents.Execute<ICustomMessage>(cutSceneManager, null, (x, y) => x.flaps(35));

        }


    }
}
