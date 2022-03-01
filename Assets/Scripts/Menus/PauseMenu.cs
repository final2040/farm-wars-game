using System;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Dialog dialog;

    public event Action OnMainMenu;
    public event Action OnResume;
    public event Action OnQuit;

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void OnMainMenuClicked()
    {
        dialog.Show("You will lost all your progress are you sure?", DialogButtons.YesNo);
        if (dialog.DialogResult == DialogResult.Yes)
        {
            OnMainMenu?.Invoke();
        }
    }

    public void OnResumeClicked()
    {
        OnResume?.Invoke();
    }

    public void OnQuitClicked()
    {
        dialog.Show("You will lost all your progress are you sure?", DialogButtons.YesNo);
        if (dialog.DialogResult == DialogResult.Yes)
        {
            OnQuit?.Invoke();
        }
    }
}
