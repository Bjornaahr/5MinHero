using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorHandler : MonoBehaviour, ICustomMessage
{
    [SerializeField]
    GameObject[] blinkerIndicators, electricIndicators, hydrolicIndicators, septicIndicators;

    [SerializeField]
    GameObject flapsIndicator;

    [SerializeField]
    float blinkerLeakRate, electricDropRate, hydrolicLeakRate, septicFillRate;

    int flapPos;

    bool dumping;

    public void fillingBlinkerFluid()
    {
        if (blinkerIndicators[0].transform.rotation.z <= 0.513)
        {
            blinkerIndicators[0].transform.Rotate(Vector3.forward, 0.2f);
            blinkerIndicators[1].transform.Rotate(Vector3.forward, 0.2f);
            blinkerIndicators[2].transform.Rotate(Vector3.forward, 0.2f);
            blinkerIndicators[3].transform.Rotate(Vector3.forward, 0.2f);

        }

    }

    public void flaps(int flap)
    {

        flapPos = flap;
    }

    public void landingGear(int landingGearPos)
    {
        
    }

    public void pumpingHydrolics()
    {
        if (hydrolicIndicators[0].transform.rotation.z <= 0.513)
        {
            hydrolicIndicators[0].transform.Rotate(Vector3.forward, 5.5f);
            hydrolicIndicators[1].transform.Rotate(Vector3.forward, 5.5f);
            hydrolicIndicators[2].transform.Rotate(Vector3.forward, 5.5f);
            hydrolicIndicators[3].transform.Rotate(Vector3.forward, 5.5f);

        }
    }

    public void sepitcDump()
    {
        if (septicIndicators[0].transform.rotation.z <= 0.513)
        {
            dumping = true;
        }
    }

    public void turningGenerator()
    {
        if (electricIndicators[0].transform.rotation.z <= 0.513)
        {
            electricIndicators[0].transform.Rotate(Vector3.forward, 3.5f);
            electricIndicators[1].transform.Rotate(Vector3.forward, 3.5f);
            electricIndicators[2].transform.Rotate(Vector3.forward, 3.5f);
            electricIndicators[3].transform.Rotate(Vector3.forward, 3.5f);

        }
    }

    void Start()
    {
    }

    void Update()
    {


        LeakBlinker();
        VoltageDrop();
        HydrolicLeak();
        SepticFilling();
        SetFlaps();


        if (blinkerIndicators[0].transform.rotation.z <= -0.40f || septicIndicators[0].transform.rotation.z <= -0.40f)
        {
            Debug.Log("Failed");
        }

        if (electricIndicators[0].transform.rotation.z <= -0.33f || hydrolicIndicators[0].transform.rotation.z <= -0.33f)
        {
            Debug.Log("Failed");
        }


        if (dumping)
        {
            septicIndicators[0].transform.Rotate(Vector3.forward, 0.4f);
            septicIndicators[1].transform.Rotate(Vector3.forward, 0.4f);
            septicIndicators[2].transform.Rotate(Vector3.forward, 0.4f);
            septicIndicators[3].transform.Rotate(Vector3.forward, 0.4f);

            if (septicIndicators[0].transform.rotation.z >= 0.513)
            {
                dumping = false;
            }


        }

    }


    void LeakBlinker()
    {
        blinkerIndicators[0].transform.Rotate(Vector3.forward, blinkerLeakRate);
        blinkerIndicators[1].transform.Rotate(Vector3.forward, blinkerLeakRate);
        blinkerIndicators[2].transform.Rotate(Vector3.forward, blinkerLeakRate);
        blinkerIndicators[3].transform.Rotate(Vector3.forward, blinkerLeakRate);
    }


    void VoltageDrop()
    {
        electricIndicators[0].transform.Rotate(Vector3.forward, electricDropRate);
        electricIndicators[1].transform.Rotate(Vector3.forward, electricDropRate);
        electricIndicators[2].transform.Rotate(Vector3.forward, electricDropRate);
        electricIndicators[3].transform.Rotate(Vector3.forward, electricDropRate);
    }

    void HydrolicLeak()
    {
        hydrolicIndicators[0].transform.Rotate(Vector3.forward, hydrolicLeakRate);
        hydrolicIndicators[1].transform.Rotate(Vector3.forward, hydrolicLeakRate);
        hydrolicIndicators[2].transform.Rotate(Vector3.forward, hydrolicLeakRate);
        hydrolicIndicators[3].transform.Rotate(Vector3.forward, hydrolicLeakRate);
    }

    void SepticFilling()
    {
        septicIndicators[0].transform.Rotate(Vector3.forward, septicFillRate);
        septicIndicators[1].transform.Rotate(Vector3.forward, septicFillRate);
        septicIndicators[2].transform.Rotate(Vector3.forward, septicFillRate);
        septicIndicators[3].transform.Rotate(Vector3.forward, septicFillRate);

    }


    void SetFlaps()
    {
        if (flapPos == 0)
        {


          /*  Vector3 pos = Camera.main.WorldToScreenPoint(new Vector3(flapsIndicator.transform.position.x, flapsIndicator.transform.position.y, 0)); //Makes pos the position of the handle of the gunblade in screen cooridinates
            Vector3 dir = new Vector3(379.9f, 451.4f, 0) - pos; //returns the position of the mouse relative to the gunblade handle
            float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) % 360; //Dir into angles

           Quaternion newDir = Quaternion.Euler(0, 180, -angle + 90);*/

           // flapsIndicator.transform.rotation =  Quaternion.RotateTowards(flapsIndicator.transform.rotation, newDir, 10.0f);
            flapsIndicator.transform.localEulerAngles = new Vector3(0,0, 68.384f);

        }
        else if (flapPos == 10)
        {
            // Debug.Log(flapsIndicator.transform.rotation.z + " 10");
            // 0.311
            flapsIndicator.transform.localEulerAngles = new Vector3(0, 0, 35.35f);

        }
        else if (flapPos == 20)
        {
            // Debug.Log(flapsIndicator.transform.rotation.z + " 20");
            // 0.342
            flapsIndicator.transform.localEulerAngles = new Vector3(0, 0, -41.266f);

        }
        else if (flapPos == 30)
        {
            // Debug.Log(flapsIndicator.transform.rotation.z + " 30");
            // 0.834
            flapsIndicator.transform.localEulerAngles = new Vector3(0, 0, -113.735f);

        }
        else if (flapPos == 35)
        {
            // Debug.Log(flapsIndicator.transform.rotation.z + " 35");
            //  0.016
            flapsIndicator.transform.localEulerAngles = new Vector3(0, 0, 0.449f);

        }
    }



}
