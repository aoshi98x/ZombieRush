using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    public string sceneName, nextLevel; 
    public bool doAction;
    Scene currentScene;
    private bool isPaused;
    [SerializeField] FollowCam camSc;
    [SerializeField] ManageData counts;
    [SerializeField] PlayerController playerSc;
    [SerializeField] GameObject deadScreen, offUI;
    [SerializeField] GameObject transition;
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
        counts.damageToPlayer = 0;
        counts.damageToEnemy = 0;
        counts.enemyDestroy = 0;
    }

    private void Update() {
        
        if(playerSc.life <=0)
        {
            Time.timeScale = 0.0f;
            deadScreen.SetActive(true);
            offUI.SetActive(false);
        }
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
    public void CheckLevel()
    {
        transition.GetComponent<Animator>().SetBool("newLevel", true);
        SceneManager.LoadScene(nextLevel);
    }
}
