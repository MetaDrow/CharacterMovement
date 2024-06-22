using System.Collections.Generic;
using UnityEngine;

public class BaseMainMenuPanel : AbstractPanel
{
    [SerializeField] protected static Dictionary<string, IInteractablePanel> _menuPanels = new Dictionary<string, IInteractablePanel>();

    public virtual void Addpanel(string panelName, IInteractablePanel panel) => _menuPanels.Add(panelName, panel);
}