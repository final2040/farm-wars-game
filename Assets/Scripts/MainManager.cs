using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif


public class MainManager : MonoBehaviour, IMainManager
{
    [SerializeField] private Controls controls = new Controls();
    public static IMainManager Instance { get; private set; }
    public string PlayerName { get; set; }
    public  ScoreBoard ScoreBoard { get; } = new ScoreBoard();

    public Controls Controls => controls;

    void Awake()
    {
        if (Instance == null)
        {
            Destroy(gameObject);
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

    }

    public void Play()
    {
        SceneManager.LoadScene(Constants.GameScene);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(Constants.MainMenuScene);
    }
}