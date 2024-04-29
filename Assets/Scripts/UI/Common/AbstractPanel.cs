using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractPanel : MonoBehaviour, IInteractablePanel
{
    [SerializeField] protected static Dictionary<string, IInteractablePanel> _menuPanels = new Dictionary<string, IInteractablePanel>();
    public virtual void ShowPanel(IInteractablePanel panel)
    {

    }

    public virtual void HidePanel(IInteractablePanel panel)
    {

    }

    public virtual void Addpanel(string panelName, IInteractablePanel panel)
    {

        _menuPanels.Add(panelName, panel);
        Debug.Log($"{panelName}, {panel} was added in dictionary");

    }
}