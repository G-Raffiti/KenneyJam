using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class uiKeyBind : MonoBehaviour
{
    [SerializeField] private playerSpaceController playerController = null;
    [SerializeField] private TMP_Text nameTxt = null;
    [SerializeField] private InputActionReference dashAction = null;
    [SerializeField] private GameObject startRebindingObject = null;
    [SerializeField] private GameObject waitingForInputObject = null;


    public void StartRebiding()
    {
        startRebindingObject.SetActive(false);
        waitingForInputObject.SetActive(true);

        playerController.PlayerInput.SwitchCurrentActionMap("Rebind");

        dashAction.action.PerformInteractiveRebinding()
            .WithControlsExcluding("Mouse")
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation => RebindComplete());
    }

    private void RebindComplete()
    {
        rebindingOperation.Dispose();
        
        startRebindingObject.SetActive(true);
        waitingForInputObject.SetActive(false);
        
        playerController.PlayerInput.SwitchCurrentActionMap("SpaceControl");
    }
    
    
}
