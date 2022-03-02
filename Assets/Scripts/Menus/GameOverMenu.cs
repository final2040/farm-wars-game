using TMPro;
using UnityEngine;

public class GameOverMenu : MenuBase
{
    [SerializeField] private TextMeshProUGUI scoreList;
    
    public string BestScores {
        get => scoreList.text; 
        set => scoreList.text = value;
    }
}
