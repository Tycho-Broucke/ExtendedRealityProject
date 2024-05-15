using UnityEngine;
using UnityEngine.Events;


public class UserInterfaceRayActivation : MonoBehaviour
{
    [SerializeField] private Transform linkedHandPosition;
    [SerializeField] private LayerMask layerToHit;
    [SerializeField] private float maxDistanceFromCanvas;


    [Header("UI Hover Events")]
    public UnityEvent OnUIHoverStart;
    public UnityEvent OnUIHoverEnd;

    enum CurrentInteractorState
    {
        DefaultMode,
        UIMode
    }

    private CurrentInteractorState currentInteractorMode;

    private void Awake() => currentInteractorMode = CurrentInteractorState.DefaultMode;

    private void FixedUpdate()
    {

       // Ray ray = new Ray(linkedHandPosition.position, linkedHandPosition.forward);
        RaycastHit hit;
        if (Physics.Raycast(linkedHandPosition.position, linkedHandPosition.forward, out hit, maxDistanceFromCanvas, layerToHit))
        {
           if (currentInteractorMode == CurrentInteractorState.DefaultMode)
           {
                    OnUIHoverStart.Invoke();
                    currentInteractorMode = CurrentInteractorState.UIMode;
           }
        }
        else
        {
            if (currentInteractorMode == CurrentInteractorState.UIMode)
            {
                OnUIHoverEnd.Invoke();
                currentInteractorMode = CurrentInteractorState.DefaultMode;
            }
        }
    }
}
