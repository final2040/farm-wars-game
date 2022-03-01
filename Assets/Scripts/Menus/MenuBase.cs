using System;
using UnityEngine;

public abstract class MenuBase : MonoBehaviour
{
    public event Action OnMainMenu;
    public event Action OnQuit;
    public event Action OnRestart;

    public virtual void Show()
    {
        gameObject.SetActive(true);
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }

    public virtual void OnMainMenuClicked()
    {
        OnMainMenu?.Invoke();
    }

    public virtual void OnQuitClicked()
    {
        OnQuit?.Invoke();
    }

    public virtual void OnRestartClicked()
    {
        OnRestart?.Invoke();
    }

    
}