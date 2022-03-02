
using System.Linq;
using System.Text;
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
        SubscribeUIEvents();
        UpdateScore();
    }

    private void SubscribeUIEvents()
    {
        ui.PauseMenu.OnMainMenu += UI_OnMainMenu;
        ui.PauseMenu.OnQuit += UI_OnQuit;
        ui.PauseMenu.OnResume += PauseMenu_OnResume;
        ui.PauseMenu.OnRestart += UI_OnRestart;

        ui.GameOverMenu.OnMainMenu += UI_OnMainMenu;
        ui.GameOverMenu.OnQuit += UI_OnQuit;
        ui.GameOverMenu.OnRestart += UI_OnRestart;
    }

    private void UI_OnRestart()
    {
        mainManager.Play();
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

    private void UI_OnQuit()
    {

        mainManager.Quit();
    }

    private void UI_OnMainMenu()
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
        mainManager.ScoreBoard.Add(new PlayerScore(mainManager.PlayerName, currentWave, score));
        ui.GameOverMenu.BestScores = CreateScoreBoard();
        ui.GameOverMenu.Show();
    }

    private string CreateScoreBoard()
    {
        var builder = new StringBuilder();
        builder.AppendLine(string.Format(Constants.ScoreboardText, "Name", "Wave", "Score"));
        foreach (var playerScore in mainManager.ScoreBoard)
        {
            builder.AppendLine(string.Format(Constants.ScoreboardText, playerScore.Name, playerScore.MaxWave,
                playerScore.Score));
        }

        return builder.ToString();
    }
}
