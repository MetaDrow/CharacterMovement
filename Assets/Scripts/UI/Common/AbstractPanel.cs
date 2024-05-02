using System.Threading.Tasks;
using UnityEngine;

public abstract class AbstractPanel : MonoBehaviour, IInteractablePanel
{
    public virtual Task AsyncHidePanel()
    {
       return Task.CompletedTask;
    }

    public virtual Task AsyncShowPanel()
    {
        return Task.CompletedTask;
    }
}

