using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private PauseMenu pauseMenu;
    [SerializeField] private GameOverMenu gameOverMenu;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI lifeText;
    [SerializeField] private TextMeshProUGUI waveText;

    

    public PauseMenu PauseMenu => pauseMenu;
    public GameOverMenu GameOverMenu => gameOverMenu;

    public string Life
    {
        get => lifeText.text;
        set => lifeText.text = value;
    }

    public string Score
    {
        get => scoreText.text;
        set => scoreText.text = value;
    }

    public string Wave
    {
        get => waveText.text;
        set => waveText.text = value;
    }

    
}
