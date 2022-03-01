using System;
using UnityEngine;

public class PauseMenu : MenuBase
{
    [SerializeField] private Dialog dialog;

    public event Action OnResume;

    public void OnResumeClicked()
    {
        OnResume?.Invoke();
    }
}
