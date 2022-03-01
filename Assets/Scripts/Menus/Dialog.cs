using System;
using TMPro;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private GameObject okButtons;
    [SerializeField] private GameObject yesNoButtons;
    private Action<DialogResult> dialogCallBack;

    public void Show(string message, DialogButtons buttons, Action<DialogResult> callback = null)
    {
        DisableAllButtons();
        ShowButtons(buttons);
        messageText.text = message;
        gameObject.SetActive(true);
        dialogCallBack = callback;
    }

    private void DisableAllButtons()
    {
        okButtons.gameObject.SetActive(false);
        yesNoButtons.gameObject.SetActive(false);
    }

    private void ShowButtons(DialogButtons buttons)
    {
        switch (buttons)
        {
            case DialogButtons.Ok:
                okButtons.gameObject.SetActive(true);
                break;
            case DialogButtons.YesNo:
                yesNoButtons.gameObject.SetActive(true);
                break;
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void OnOkClicked()
    {
        dialogCallBack?.Invoke(DialogResult.Ok);
        Hide();
    }

    public void OnYesClicked()
    {
        dialogCallBack?.Invoke(DialogResult.Yes);
        Hide();
    }

    public void OnNoClicked()
    {
        dialogCallBack?.Invoke(DialogResult.No);
        Hide();
    }
}