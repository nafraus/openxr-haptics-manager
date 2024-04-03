using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VRHapticsManager : MonoBehaviour
{
    public static VRHapticsManager Instance;

    [SerializeField] private XRDirectInteractor leftInteractor;
    [SerializeField] private XRDirectInteractor rightInteractor;
    private void Awake()
    {
        if (Instance) Destroy(gameObject);
        else Instance = this;
    }

    public void SendHapticImpulse(float amplitude, float duration, XRHapticControllerSpecifier type)
    {
        switch (type)
        {
            case XRHapticControllerSpecifier.left:
                leftInteractor.SendHapticImpulse(amplitude, duration);
                break;
            case XRHapticControllerSpecifier.right:
                rightInteractor.SendHapticImpulse(amplitude, duration);
                break;
            case XRHapticControllerSpecifier.both:
                leftInteractor.SendHapticImpulse(amplitude, duration);
                rightInteractor.SendHapticImpulse(amplitude, duration);
                break;
        }
    }

    public void SendHapticImpulse(float amplitude, float duration, XRDirectInteractor controller)
    {
        controller.SendHapticImpulse(amplitude, duration);
    }

    public void SendHapticImpulse(float amplitude, float duration, XRBaseController controller)
    {
        controller.SendHapticImpulse(amplitude, duration);
    }

    public void SendHapticImpulse(float amplitude, float duration, XRBaseInteractable interactable)
    {
        foreach(IXRSelectInteractor interactor in interactable.interactorsSelecting)
        {
            interactor.transform.GetComponent<XRDirectInteractor>()?.SendHapticImpulse(amplitude, duration);
        }
    }
}

public enum XRHapticControllerSpecifier
{
    left,
    right,
    both
}


