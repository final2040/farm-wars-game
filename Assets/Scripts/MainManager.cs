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

    public Controls Controls => controls;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(this);
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }

    public void Attack()
    {

    }
}