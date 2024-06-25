using System.Threading.Tasks;

public interface IInteractablePanel
{
    public Task AsyncHidePanel();
    public Task AsyncShowPanel();
}
