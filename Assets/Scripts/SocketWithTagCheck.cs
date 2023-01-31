using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class SocketWithTagCheck : XRSocketInteractor
{
    /*
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
    */

    // XRSnapInteractor is an XRSocketInteractor that filters socketable items by tag
    [Header("Filter PARAMS")]
    [SerializeField] protected bool doFilterByTag = true;
    [SerializeField] protected string[] filterTags;


    public override bool CanHover(IXRHoverInteractable interactable)
    {
        if (doFilterByTag && interactable is MonoBehaviour gameObject)
        {
            foreach (string filterTag in filterTags)
            {
                if (!gameObject.CompareTag(filterTag))
                {
                    return false;
                }
            }
        }
        return base.CanHover(interactable);
    }

    public override bool CanSelect(IXRSelectInteractable interactable)
    {
        if (doFilterByTag && interactable is MonoBehaviour gameObject)
        {
            foreach (string filterTag in filterTags)
            {
                if (!gameObject.CompareTag(filterTag))
                {
                    return false;
                }
            }
        }
        return base.CanSelect(interactable);
    }
}
