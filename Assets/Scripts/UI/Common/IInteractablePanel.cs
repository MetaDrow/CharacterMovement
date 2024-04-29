using System;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractablePanel
{
    public void ShowPanel(IInteractablePanel panel);
    public void HidePanel(IInteractablePanel panel);


}
