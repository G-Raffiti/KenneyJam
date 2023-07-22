using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class UIKeyBind : MonoBehaviour
{
    [SerializeField] private playerSpaceController playerController = null;
    [SerializeField] public TMP_Text nameTxt = null;
    [SerializeField] private InputActionReference dashAction = null;

    private InputActionRebindingExtensions.RebindingOperation rebindingOperation;
    
    
    public void StartRebiding()
    {
        nameTxt.text = "waiting...";
        
        playerController.controls.Rebind.Enable();
        playerController.controls.SpaceControl.Disable();

        dashAction.action.PerformInteractiveRebinding()
            .WithControlsExcluding("Mouse")
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation => RebindComplete())
            .Start();
    }

    private void RebindComplete()
    {
        rebindingOperation.Dispose();
        
        nameTxt.text = "button";

        playerController.controls.Rebind.Disable();
        playerController.controls.SpaceControl.Enable();
    }
}
