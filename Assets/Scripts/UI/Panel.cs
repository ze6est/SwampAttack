using UnityEngine;

public class Panel : MonoBehaviour
{
    public bool PanelNotOpened { get; private set; } = true;

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
        Time.timeScale = 0;
        PanelNotOpened = false;
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
        Time.timeScale = 1;
        PanelNotOpened = true;
    }

    public void Exit()
    {
        Application.Quit();
    }
}