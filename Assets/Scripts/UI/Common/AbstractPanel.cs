using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractPanel : MonoBehaviour, IInteractablePanel
{

    public SettingsPanel _settingsPanel;
    public MainMenuPanel _mainMenuPanel;


    private void Awake()
    {

    }
    public void HidePanel(AbstractPanel abstractPanel)
    {

    }

    public void ShowUpPanel(AbstractPanel abstractPanel)
    {

    }
}