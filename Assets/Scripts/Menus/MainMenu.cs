using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] TMP_InputField playerNameInput;
    [SerializeField] private Dialog dialog;
    IMainManager _mainManager;

    private void Start()
    {
        _mainManager = MainManager.Instance;
    }

    public void OnPlayClicked()
    {

        if (playerNameInput.text.IsNullOrWitheSpace())
        {
            dialog.Show("Please introduce a name.", DialogButtons.Ok);
        }
        else
        {
            _mainManager.PlayerName = playerNameInput.text;
            _mainManager.Play();
        }
    }

    public void OnQuitClicked()
    {
        _mainManager.Quit();
    }
}