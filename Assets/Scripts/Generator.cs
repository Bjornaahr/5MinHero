using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Generator : MonoBehaviour
{

    Camera camera;
    Vector3 startPos;
    [SerializeField]
    Canvas canvas;
    RectTransform rectTransform;
    GameObject indicatorHandler, cutSceneManager;
    bool canHold;
    float angle;
    bool fullRotationNext;


    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        rectTransform = GetComponent<RectTransform>();
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
            if (hit.collider.name == "GeneratorHandle")
            {
                canHold = true;
            }
        }

        if (Input.GetMouseButton(0) && canHold)
        {
            
            Vector3 pos = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y, 180)); //Makes pos the position of the handle of the gunblade in screen cooridinates
            Vector3 dir = Input.mousePosition - pos; //returns the position of the mouse relative to the gunblade handle
            float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) % 360; //Dir into angles

            transform.rotation = Quaternion.Euler(0, 180, -angle);

            checkRotation();

           

        }
        else if (Input.GetMouseButtonUp(0) && canHold)
        {
            canHold = false;
        }
    }


    void checkRotation()
    {
       // Debug.Log(transform.rotation.x);

        if(transform.rotation.x <= -0.70 && transform.rotation.x >= -0.77)
        {
            fullRotationNext = true;
        }

        if (transform.rotation.x <= 0.77 && transform.rotation.x >= 0.69 && fullRotationNext)
        {
            ExecuteEvents.Execute<ICustomMessage>(indicatorHandler, null, (x, y) => x.turningGenerator());
            ExecuteEvents.Execute<ICustomMessage>(cutSceneManager, null, (x, y) => x.turningGenerator());

            fullRotationNext = false;
        }
    }


}
