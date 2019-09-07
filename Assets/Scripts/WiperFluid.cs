using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WiperFluid : MonoBehaviour
{
    Camera camera;
    Vector3 startPos;
    [SerializeField]
    Canvas canvas;
    RectTransform rectTransform;
    GameObject indicatorHandler;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        rectTransform = GetComponent<RectTransform>();
        startPos = rectTransform.position;
        indicatorHandler = GameObject.FindGameObjectWithTag("IndicatorHandler");

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
        if (hit)
        {
            if (hit.collider.name == "BlinkerFluid")
            {
                if (Input.GetMouseButton(0))
                {
                    Vector3 pos = camera.ScreenToWorldPoint(Input.mousePosition);
                    transform.position = new Vector3(pos.x, pos.y, 79);

                }
            }
            else
            {
                rectTransform.position = camera.ScreenToWorldPoint(startPos);
            }
        }
        else
        {
            rectTransform.position = camera.ScreenToWorldPoint(startPos);
        }

    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if(coll.name == "BlinkerFluidHolder")
        {
            ExecuteEvents.Execute<ICustomMessage>(indicatorHandler, null, (x,y)=>x.fillingBlinkerFluid());
        }
    }

}
