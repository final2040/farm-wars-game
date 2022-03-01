
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameUI ui;
    [SerializeField] private Bounds worldBounds;
    [SerializeField] private Player player;


    private IMainManager mainManager;
    private bool isPaused;
    private int score;
    private int currentWave;

    public static GameManager Instance { get; private set; }

    public Bounds WorldBounds => worldBounds;

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

        if (!FindObjectsOfType<Enemy>().Any())
        {
            currentWave++;
            SpawnManager.Create.EnemyWave(currentWave, player);
            ui.Wave = string.Format(Constants.WaveText, currentWave);
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

    public void GameOver()
    {
        throw new System.NotImplementedException();
    }
}
