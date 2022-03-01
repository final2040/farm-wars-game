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

    public override void OnRestartClicked()
    {
        dialog.Show("You will lost all your progress are you sure?", DialogButtons.YesNo, (result) =>
        {
            if (result == DialogResult.Yes)
            {
                base.OnRestartClicked();
            }
        });
        
    }

    public override void OnMainMenuClicked()
    {
        dialog.Show("You will lost all your progress are you sure?", DialogButtons.YesNo, (result) =>
        {
            if (result == DialogResult.Yes)
            {
                base.OnMainMenuClicked();
            }
        });
    }

    public override void OnQuitClicked()
    {
        dialog.Show("You will lost all your progress are you sure?", DialogButtons.YesNo, (result) =>
        {
            if (result == DialogResult.Yes)
            {
                base.OnQuitClicked();
            }
        });
    }
}
