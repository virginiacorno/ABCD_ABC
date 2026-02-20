using UnityEngine;

public class PracticePhase : MonoBehaviour
{
    public moveplayer player;
    public InstructionScreenManager instructionScreenManager;
    private int rotationsCompleted = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //V: set the player position
        player.transform.position = new Vector3(5f, 1f, 15.3f);
        //V; ensure inputs are enabled but only possible to rotate (vs also moving)
        player.inputEnabled = true;
        player.rotateOnly = true;
    }

    void Update()
    {
        //V: check if we have done all the rotations needed
        if (rotationsCompleted == 3)
        {
            //V: call game start screen
        }
        else
        {
            //V: check for keyboard presses
        }
    }
}
