using UnityEngine;

public class PracticePhase : MonoBehaviour
{
    public moveplayer player;
    public InstructionScreenManager instructionScreenManager;
    public FreeNavigationCamera freeNavCamera;
    private int rotationsCompleted = 0;
    private float lastYRotation;
    private float accumulatedRotation = 0f;
    private bool practiceComplete = false;
    private bool practiceStarted = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartPractice()
    {
        practiceStarted = true;
        //V: set the player position
        player.transform.position = new Vector3(5f, 1f, 15.3f);
        freeNavCamera.StartCameraTransition(); // start the transition
        //V: ensure inputs are enabled but only possible to rotate (vs also moving)
        player.inputEnabled = true;
        player.rotateOnly = true;
        lastYRotation = player.transform.eulerAngles.y; //V: initialise the current rotation direction
    }

    void Update()
    {
        if (practiceStarted && !practiceComplete)
        {
            CheckRotations();
        }
    }

    void CheckRotations()
    {
        //V: check if we have done all the rotations needed
        if (rotationsCompleted == 3 && practiceComplete != true)
        {
            practiceComplete = true;
            //V: call game start screen and disable player movement
            player.inputEnabled = false;
            //instructionScreenManager.ShowCuePanel();
            freeNavCamera.StartNewConfiguration(0);
        }
        else
        {
            float currentY = player.transform.eulerAngles.y;
            float delta = Mathf.DeltaAngle(lastYRotation, currentY);
            accumulatedRotation += Mathf.Abs(delta);
            lastYRotation = currentY;

            if (accumulatedRotation >= 360f)
            {
                rotationsCompleted ++;
                accumulatedRotation = 0;
            }
        }
    }
}
