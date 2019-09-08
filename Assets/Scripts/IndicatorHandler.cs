using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    //Fills blinker fluid
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

    //Set flap position according to flap lever position
    public void flaps(int flap)
    {

        flapPos = flap;
    }

    public void landingGear(int landingGearPos)
    {
        
    }

    //Increments hyrdolic indicators as player is pumping
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

    //Starts dumping septic tank
    public void sepitcDump()
    {
        if (septicIndicators[0].transform.rotation.z <= 0.513)
        {
            dumping = true;
        }
    }

    //Increments the electric indicator when generator is turned
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


        //Checks if blinker and septic is empty/full
        if (blinkerIndicators[0].transform.rotation.z <= -0.40f || septicIndicators[0].transform.rotation.z <= -0.40f)
        {
            Failed();
            Debug.Log("Failed");
        }

        //Check if we got no electric charge or hydrolic pressure
        if (electricIndicators[0].transform.rotation.z <= -0.33f || hydrolicIndicators[0].transform.rotation.z <= -0.33f)
        {
            Failed();
            Debug.Log("Failed");
        }

        //Dumps the septic tank
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

    //Rotates the blinker indicators towards empty
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


    //Sets the flap indicator according to flap degrees
    void SetFlaps()
    {
        if (flapPos == 0)
        {
            flapsIndicator.transform.localEulerAngles = new Vector3(0,0, 68.384f);

        }
        else if (flapPos == 10)
        {

            flapsIndicator.transform.localEulerAngles = new Vector3(0, 0, 35.35f);

        }
        else if (flapPos == 20)
        {
       
            flapsIndicator.transform.localEulerAngles = new Vector3(0, 0, -41.266f);

        }
        else if (flapPos == 30)
        {

            flapsIndicator.transform.localEulerAngles = new Vector3(0, 0, -113.735f);

        }
        else if (flapPos == 35)
        {
   
            flapsIndicator.transform.localEulerAngles = new Vector3(0, 0, 0.449f);

        }
    }

    void Failed()
    {
        PlayerPrefs.SetInt("Failed", 1);
        SceneManager.LoadScene(1);
    }

}
