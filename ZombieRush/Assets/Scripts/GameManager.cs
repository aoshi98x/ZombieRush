using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    public string sceneName; 
    public bool doAction = false;
    Scene currentScene;
    private bool isPaused;
    FollowCam camSc;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        
    }
    private void Start() {
        
        camSc = GameObject.Find("CameraTracking").GetComponent<FollowCam>();
    }

    void Update()
    {
        
    }

    public void UpdateState()
    {
        isPaused = !isPaused;
        if(isPaused)
        {
            Time.timeScale = 0.0f;
            camSc.enabled=false;
        }
        else
        {
            Time.timeScale = 1.0f;
            camSc.enabled=true;
            
        }
        
    }

    public bool PauseOnChecker()
    {
        return isPaused;
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void RestartScene()
    {
        currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void CanAction()
    {
        doAction = true;
    }

    public void RestartAction()
    {
        doAction = false;
    }
}
