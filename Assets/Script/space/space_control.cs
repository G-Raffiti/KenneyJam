//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/Script/space/space_control.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Space_control: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Space_control()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""space_control"",
    ""maps"": [
        {
            ""name"": ""SpaceControl"",
            ""id"": ""cf77599c-1692-42c6-bd6e-e9beb9c4cfcd"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""2423cf84-5de1-44ba-96df-2f1b7c011bd6"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""a726c5c7-190b-4469-b789-787530c255b4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Shield"",
                    ""type"": ""Button"",
                    ""id"": ""ca9a96f0-743f-4659-97ff-8881a0e17a80"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""65fd6693-0ee7-42bc-b676-cfe2a8298ae0"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""975dc7e5-9eab-4345-85ee-e53f3503cc1f"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ba62dcba-0b23-412c-b56e-f2b3aa056650"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""8aac8d9e-36bb-4257-888a-dfb6e3e99a8f"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0008654d-6487-4baf-a2fd-55ecdb0abf3d"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""7933b72d-a53a-4766-9406-50249c78a700"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""73786a44-8fb8-44f3-bc77-dc452d16fc6f"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shield"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // SpaceControl
        m_SpaceControl = asset.FindActionMap("SpaceControl", throwIfNotFound: true);
        m_SpaceControl_Movement = m_SpaceControl.FindAction("Movement", throwIfNotFound: true);
        m_SpaceControl_Dash = m_SpaceControl.FindAction("Dash", throwIfNotFound: true);
        m_SpaceControl_Shield = m_SpaceControl.FindAction("Shield", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // SpaceControl
    private readonly InputActionMap m_SpaceControl;
    private List<ISpaceControlActions> m_SpaceControlActionsCallbackInterfaces = new List<ISpaceControlActions>();
    private readonly InputAction m_SpaceControl_Movement;
    private readonly InputAction m_SpaceControl_Dash;
    private readonly InputAction m_SpaceControl_Shield;
    public struct SpaceControlActions
    {
        private @Space_control m_Wrapper;
        public SpaceControlActions(@Space_control wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_SpaceControl_Movement;
        public InputAction @Dash => m_Wrapper.m_SpaceControl_Dash;
        public InputAction @Shield => m_Wrapper.m_SpaceControl_Shield;
        public InputActionMap Get() { return m_Wrapper.m_SpaceControl; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SpaceControlActions set) { return set.Get(); }
        public void AddCallbacks(ISpaceControlActions instance)
        {
            if (instance == null || m_Wrapper.m_SpaceControlActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_SpaceControlActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Dash.started += instance.OnDash;
            @Dash.performed += instance.OnDash;
            @Dash.canceled += instance.OnDash;
            @Shield.started += instance.OnShield;
            @Shield.performed += instance.OnShield;
            @Shield.canceled += instance.OnShield;
        }

        private void UnregisterCallbacks(ISpaceControlActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Dash.started -= instance.OnDash;
            @Dash.performed -= instance.OnDash;
            @Dash.canceled -= instance.OnDash;
            @Shield.started -= instance.OnShield;
            @Shield.performed -= instance.OnShield;
            @Shield.canceled -= instance.OnShield;
        }

        public void RemoveCallbacks(ISpaceControlActions instance)
        {
            if (m_Wrapper.m_SpaceControlActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ISpaceControlActions instance)
        {
            foreach (var item in m_Wrapper.m_SpaceControlActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_SpaceControlActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public SpaceControlActions @SpaceControl => new SpaceControlActions(this);
    public interface ISpaceControlActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnShield(InputAction.CallbackContext context);
    }
}
