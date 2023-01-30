using UnityEngine.XR.Interaction.Toolkit;

public class SocketWithTagCheck : XRSocketInteractor
{
    //Make sue there there's nothing in the string
    public string targetTag = string.Empty;

    //When hover,if the object hovering has the target tag, interactor can hover it
    public override bool CanHover(XRBaseInteractable interactable)
    {
        return base.CanHover(interactable) && MatchUsingTag(interactable);
    }

    //When select,if the object hovering has the target tag, interactor can hover it
    public override bool CanSelect(XRBaseInteractable interactable)
    {
        return base.CanSelect(interactable) && MatchUsingTag(interactable);
    }

    // Creates a field where players can add in a Target Tag so that the object with that tag can interact with the socket
    private bool MatchUsingTag(XRBaseInteractable interactable)
    {
        return interactable.CompareTag(targetTag);
    }
}
