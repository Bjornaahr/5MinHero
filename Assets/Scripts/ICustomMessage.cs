using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface ICustomMessage : IEventSystemHandler
{

    void fillingBlinkerFluid();
    void turningGenerator();
    void pumpingHydrolics();
    void landingGear(int landingGearPos);
    void sepitcDump();
    void flaps(int flapPos);
}
