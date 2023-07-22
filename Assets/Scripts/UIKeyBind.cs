using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class UIKeyBind : MonoBehaviour
{
    [SerializeField] private playerSpaceController playerController = null;
    [SerializeField] private TMP_Text nameTxt = null;
    [SerializeField] private InputActionReference dashAction = null;
    [SerializeField] private InputActionReference moveAction = null;

    private InputActionRebindingExtensions.RebindingOperation rebindingOperation;
    
    
    public void StartRebiding()
    {
        nameTxt.text = "waiting...";
        
        playerController.controls.Rebind.Enable();
        playerController.controls.SpaceControl.Disable();

        rebindingOperation = dashAction.action.PerformInteractiveRebinding()
            .WithControlsExcluding("Mouse")
            .OnComplete(operation => RebindComplete())
            .Start();
    }

    private void RebindComplete()
    {
        rebindingOperation.Dispose();

        nameTxt.text = InputControlPath.ToHumanReadableString(
            dashAction.action.bindings[0].effectivePath,
            InputControlPath.HumanReadableStringOptions.OmitDevice);

        playerController.controls.Rebind.Disable();
        playerController.controls.SpaceControl.Enable();
    }
}
