using UnityEngine;

using Valve.VR;

public class vive_buttons : MonoBehaviour
{
    public SteamVR_Input_Sources handType;

    public SteamVR_Action_Boolean clutchAction;
    public SteamVR_Action_Boolean stopAction;
    public SteamVR_Action_Boolean grabAction;
    public SteamVR_Action_Boolean vibrModeAction;
    public SteamVR_Action_Vector2 vibrLevelAction;
    public SteamVR_Action_Vibration vibrateAction;
    public SteamVR_Action_Pose poseAction;

    public bool clutch = false;
    public bool stop = false;
    public bool grab = false;
    public bool freqMode = false;
    public Vector2 vibrLevel = new Vector2();


    void Update()
    {
        UpdateClutch();
        UpdateStop();
        UpdateGrab();
        UpdateVibration();
    }

    private void UpdateClutch()
    {
        clutch = clutchAction.GetState(handType);
    }

    private void UpdateStop()
    {
        stop = stopAction.GetStateDown(handType);
    }

    public void UpdateGrab()
    {
        grab = grabAction.GetState(handType);
    }

    private void UpdateVibration()
    {
        freqMode = vibrModeAction.GetState(handType);
        vibrLevel = vibrLevelAction.GetAxis(handType);
        if (vibrLevel.magnitude > 0)
        {
            vibrLevel += new Vector2(1, 1);
            vibrLevel /= 2;
        }

    }

    public void TriggerHapticPulse(float duration, float frequency, 
        float amplitude)
    {
        vibrateAction.Execute(0f, duration, frequency, amplitude, handType);
    }
}
