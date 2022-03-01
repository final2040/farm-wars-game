public interface IMainManager
{
    Controls Controls { get; }
    string PlayerName { get; set; }
    void Play();
    void Quit();
    void MainMenu();
}