public interface IMainManager
{
    Controls Controls { get; }
    string PlayerName { get; set; }
    ScoreBoard ScoreBoard { get; }
    void Play();
    void Quit();
    void MainMenu();
}