using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CutSceneManager : MonoBehaviour, ICustomMessage
{

    [SerializeField]
    GameObject cutScene, cockpit;
    [SerializeField]
    Sprite before, after;

    SpriteRenderer spriteRenderer;

    [SerializeField]
    TextMeshProUGUI flightAttendantText;

    [SerializeField]
    TextMeshProUGUI alltiudeTxt, headingTxt, navTxt;

    int index, flapsAngle;

    [SerializeField]
    GameObject m_Camera;

    bool septicPressed, blinkerFluid, hydrolic, voltage, landingGearDown;

    public void fillingBlinkerFluid()
    {
        if (!blinkerFluid)
        {
            FilledBlinker();
        }
    }

    public void flaps(int flapPos)
    {
        flapsAngle = flapPos;
    }

    public void landingGear(int landingGearPos)
    {
        landingGearDown = true;
    }

    public void pumpingHydrolics()
    {
        if (!hydrolic)
        {
            HydrolicPumped();
        }
    }

    public void sepitcDump()
    {
        if (!septicPressed)
        {
            SepticPressed();
        }

        if(index == 9)
        {
            SceneManager.LoadScene(1);
        }

    }

    public void turningGenerator()
    {
        if (!voltage) {
            GeneratorTurned();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = cutScene.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && index == 0){
            flightAttendantText.text = "All of our pilots are incapacitated, and we need one of you to pilot the plane";
            spriteRenderer.sprite = after;
            index++;
        }

         else if(Input.GetButtonDown("Fire1") && index == 1){
            flightAttendantText.text = "Don't worry ATC will tell you what to do";
            index++;
        } 

        else if(Input.GetButtonDown("Fire1") && index == 2){
            cutScene.SetActive(false);
            cockpit.SetActive(true);
            flightAttendantText.text = "ATC: This plane got alot of issues first thigs first try and dump the septic tank" +
                ". Should be a button to the right and down";
            index++;

        }

        if (voltage)
        {
            GetPlaneAround();
        }

    }

    void SepticPressed()
    {
        flightAttendantText.text = "ATC: Great, I see you're leaking blinker fluid." +
            " You need to refill or the plane will crash, try looking for a glass with something yellow in it";
        septicPressed = true;
    }

    void FilledBlinker()
    {
        flightAttendantText.text = "ATC: Fantastic remember that you need to do this often" +
            ". Right now I need you to pump some more hydrolic into the system";
        blinkerFluid = true;
    }

    void HydrolicPumped()
    {
        flightAttendantText.text = "Amazing, soon finished with the basics of keeping this plane in the air" +
            ". Now I need you to turn the generator so we get some more voltage in the circuts";
        hydrolic = true;
    }

    void GeneratorTurned()
    {
        flightAttendantText.text = "Okay, right now I'm going to give you the instructions to line up the plane" +
            "with the runway. Turn right heading 3";
        voltage = true;
    }


    void GetPlaneAround()
    {

        int heading = int.Parse(headingTxt.text);
        int alt = int.Parse(alltiudeTxt.text);

        Debug.Log(heading);

        if (index == 3 && heading == 3)
        {
            flightAttendantText.text = "Great job, now I need you to get the plane down to 10000ft";
            index++;
        }


        if (index == 4 && alt == 10000)
        {
            flightAttendantText.text = "Fantasitc, Now please extend the flaps to 10";
            index++;
        }


        if (index == 5 && flapsAngle == 10)
        {
            flightAttendantText.text = "Nice, please turn right heading 50";
            index++;
        }

        if (index == 6 && heading == 50)
        {
            flightAttendantText.text = "Okay, you are coming in a bit fast, lower your flaps to 30";
            index++;
        }


        if (index == 7 && flapsAngle == 30)
        {
            flightAttendantText.text = "Fantastic, now you can lower the landing gear";
            index++;
        }

        if (index == 8 && landingGearDown)
        {
            flightAttendantText.text = "Great, now just dump the septic tank one more time and we can land this plane";
            index++;
        }
    }


}
