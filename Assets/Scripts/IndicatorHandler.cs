using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorHandler : MonoBehaviour, ICustomMessage
{
    [SerializeField]
    GameObject[] blinkerIndicators, electricIndicators, hydrolicIndicators, septicIndicators;

    [SerializeField]
    float blinkerLeakRate, electricDropRate, hydrolicLeakRate, septicFillRate;

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

    public void flaps(int flapPos)
    {
        throw new System.NotImplementedException();

    }

    public void landingGear(int landingGearPos)
    {
        throw new System.NotImplementedException();
    }

    public void pumpingHydrolics()
    {
        if (hydrolicIndicators[0].transform.rotation.z <= 0.513)
        {
            hydrolicIndicators[0].transform.Rotate(Vector3.forward, 1.5f);
            hydrolicIndicators[1].transform.Rotate(Vector3.forward, 1.5f);
            hydrolicIndicators[2].transform.Rotate(Vector3.forward, 1.5f);
            hydrolicIndicators[3].transform.Rotate(Vector3.forward, 1.5f);

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
        Debug.Log("Turned 360");
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


        if (blinkerIndicators[0].transform.rotation.z <= -0.33f || septicIndicators[0].transform.rotation.z <= -0.33f)
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


}
