using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private const string LifePropertyName = "Life";
    [SerializeField] private Player player;
    [SerializeField] private GameUI ui;
    private IMainManager mainManager;
    private bool isPaused;
    
    void Start()
    {
        mainManager = MainManager.Instance;
        player.PropertyChanged += Player_PropertyChanged;
        ui.PauseMenu.OnMainMenu += PauseMenu_OnMainMenu;
        ui.PauseMenu.OnQuit += PauseMenu_OnQuit;
        ui.PauseMenu.OnResume += PauseMenu_OnResume;
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

    private void Player_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == LifePropertyName)
        {
            ui.Life = string.Format(Constants.LiveTextFormat, player.Life);
        }
    }

}
