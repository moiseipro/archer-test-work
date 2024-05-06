//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Source/Input/GameInput.inputactions
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

public partial class @GameInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInput"",
    ""maps"": [
        {
            ""name"": ""Archer"",
            ""id"": ""5a2e62ea-d266-45ef-82fa-e982ae88272c"",
            ""actions"": [
                {
                    ""name"": ""Aim"",
                    ""type"": ""Button"",
                    ""id"": ""0ae41be6-1cb0-4bd7-a956-da6056a9f4b9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""822ffc4a-b049-448f-aac5-ccbffe9fbbed"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Archer
        m_Archer = asset.FindActionMap("Archer", throwIfNotFound: true);
        m_Archer_Aim = m_Archer.FindAction("Aim", throwIfNotFound: true);
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

    // Archer
    private readonly InputActionMap m_Archer;
    private IArcherActions m_ArcherActionsCallbackInterface;
    private readonly InputAction m_Archer_Aim;
    public struct ArcherActions
    {
        private @GameInput m_Wrapper;
        public ArcherActions(@GameInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Aim => m_Wrapper.m_Archer_Aim;
        public InputActionMap Get() { return m_Wrapper.m_Archer; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ArcherActions set) { return set.Get(); }
        public void SetCallbacks(IArcherActions instance)
        {
            if (m_Wrapper.m_ArcherActionsCallbackInterface != null)
            {
                @Aim.started -= m_Wrapper.m_ArcherActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_ArcherActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_ArcherActionsCallbackInterface.OnAim;
            }
            m_Wrapper.m_ArcherActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
            }
        }
    }
    public ArcherActions @Archer => new ArcherActions(this);
    public interface IArcherActions
    {
        void OnAim(InputAction.CallbackContext context);
    }
}