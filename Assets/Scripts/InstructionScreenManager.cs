using UnityEngine;

public class InstructionScreenManager : MonoBehaviour
{
    public FreeNavigationCamera cameraManager;
    //public CameraManager cameraManager;
    public rewardManager rewardManager;
    public GameObject instructionPanel;
    public GameObject practicePanel; 
    public GameObject cuePanel;
    public GameObject newSeqPanel; //V: screen signalling sequence change
    public GameObject endPanel;
    public moveplayer player;
    public PracticePhase practicePhase;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("InstructionScreenManager Start() called");
        ShowInstruction();
    }

    public void ShowInstruction()
    {
        Debug.Log("ShowInstruction() called");
        instructionPanel.SetActive(true);
        practicePanel.SetActive(false);
        cuePanel.SetActive(false);
        newSeqPanel.SetActive(false);
        endPanel.SetActive(false);
        Time.timeScale = 0f; //V: pause everything else
    }

    public void OnInstrucButton()
    {
        instructionPanel.SetActive(false);
        newSeqPanel.SetActive(false);
        practicePanel.SetActive(false);
        cuePanel.SetActive(false);
        endPanel.SetActive(false);
        Time.timeScale = 1f;

        ShowCuePanel(); //V: show cue
    }

    public void ShowCuePanel()
    {
        player.inputEnabled = false;
        cuePanel.SetActive(true);
        practicePanel.SetActive(false);
        instructionPanel.SetActive(false);
        newSeqPanel.SetActive(false);
        endPanel.SetActive(false);

        //V: disable the minimap so we can see the cue
        cameraManager.DisableMiniMap();
        //V: make cue in the scene visible
        rewardManager.cueObject.SetActive(true);
    }

    public void OnCueButton()
    {
        rewardManager.HideCue();
        cuePanel.SetActive(false);
        practicePanel.SetActive(false);
        instructionPanel.SetActive(false);
        newSeqPanel.SetActive(false);
        endPanel.SetActive(false);

        PracticeInstructions();
    }

    public void PracticeInstructions()
    {
        practicePanel.SetActive(true);
        instructionPanel.SetActive(false);
        cuePanel.SetActive(false);
        newSeqPanel.SetActive(false);
        endPanel.SetActive(false);
        Time.timeScale = 0f;
    }

    public void OnPracButton()
    {
        practicePanel.SetActive(false);
        cuePanel.SetActive(false);
        instructionPanel.SetActive(false);
        newSeqPanel.SetActive(false);
        endPanel.SetActive(false);
        Time.timeScale = 1f;

        practicePhase.StartPractice(); //V start the practice phase

        //cameraManager.StartNewConfiguration(0); //V: actually start the game

    }

    public void NewSequenceInstructions()
    {
        
        Debug.Log("NewSequenceInstructions() called");
        newSeqPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OnContinueButton()
    {
        instructionPanel.SetActive(false);
        practicePanel.SetActive(false);
        cuePanel.SetActive(false);
        newSeqPanel.SetActive(false);
        Time.timeScale = 1f; //V: resume the game
        CameraManager camManager = FindFirstObjectByType<CameraManager>();
        FreeNavigationCamera freeNavCam = FindFirstObjectByType<FreeNavigationCamera>();

        if (camManager != null && camManager.enabled)
        {
            rewardManager.StartNextConfiguration();
            
        } else if (freeNavCam != null && freeNavCam.enabled)
        {
            freeNavCam._startGameAfterTransition = true;
            cameraManager.StartCameraTransition();
        }
    }

    public void EndScreen()
    {
        instructionPanel.SetActive(false);
        practicePanel.SetActive(false);
        newSeqPanel.SetActive(false);
        cuePanel.SetActive(false);
        endPanel.SetActive(true);
    }
}
