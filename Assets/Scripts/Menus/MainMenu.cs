using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] TMP_InputField playerNameInput;
    [SerializeField] private Dialog dialog;
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    public void OnPlayClicked()
    {

        if (playerNameInput.text.IsNullOrWitheSpace())
        {
            dialog.Show("Please introduce a name.");
        }
        else
        {
            gameManager.PlayerName = playerNameInput.text;
            gameManager.Play();
        }
    }

    public void OnQuitClicked()
    {
        gameManager.Quit();
    }
}