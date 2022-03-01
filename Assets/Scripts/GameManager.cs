
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameUI ui;

    private IMainManager mainManager;
    private bool isPaused;
    private int score;

    public static GameManager Instance { get; private set; }

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        mainManager = MainManager.Instance;
        ui.PauseMenu.OnMainMenu += PauseMenu_OnMainMenu;
        ui.PauseMenu.OnQuit += PauseMenu_OnQuit;
        ui.PauseMenu.OnResume += PauseMenu_OnResume;
        UpdateScore();
    }

    void Update()
    {
        if (Input.GetKeyDown(mainManager.Controls.Pause))
        {
            PauseResume();
        }
    }

    private void PauseResume()
    {
        if (isPaused)
            Resume();
        else
            Pause();

    }

    private void Pause()
    {
        ui.PauseMenu.Show();
        Time.timeScale = 0;
    }

    private void Resume()
    {
        ui.PauseMenu.Hide();
        Time.timeScale = 1;

    }

    private void PauseMenu_OnResume()
    {
        Resume();
    }

    private void PauseMenu_OnQuit()
    {

        mainManager.Quit();
    }

    private void PauseMenu_OnMainMenu()
    {
        mainManager.MainMenu();
    }

    public void UpdatePlayerLife(int currentLife, int maxLife)
    {
        ui.Life = string.Format(Constants.LifeText, currentLife, maxLife);
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScore();
    }

    private void UpdateScore()
    {
        ui.Score = string.Format(Constants.ScoreText, score);
    }
}
