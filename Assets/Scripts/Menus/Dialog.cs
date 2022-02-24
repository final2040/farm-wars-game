using TMPro;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private GameObject okButtons;
    [SerializeField] private GameObject yesNoButtons;
    public DialogResult DialogResult { get; private set; }

    public void Show(string message, DialogButtons buttons)
    {
        DisableAllButtons();
        ShowButtons(buttons);
        messageText.text = message;
        gameObject.SetActive(true);
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
        DialogResult = DialogResult.Ok;
        Hide();
    }

    public void OnYesClicked()
    {
        DialogResult = DialogResult.Yes;
        Hide();
    }

    public void OnNoClicked()
    {
        DialogResult = DialogResult.No;
        Hide();
    }
}