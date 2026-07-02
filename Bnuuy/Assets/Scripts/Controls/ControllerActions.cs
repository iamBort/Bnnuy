// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Controls/ControllerActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @ControllerActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @ControllerActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ControllerActions"",
    ""maps"": [
        {
            ""name"": ""ControllerGameplay"",
            ""id"": ""b6fdace3-dca1-4ebe-a49d-fc19817c7db3"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""f00b1249-8680-4daf-9a79-561ac92024b5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Button"",
                    ""id"": ""647d00ac-5071-4ac3-b5d4-b6979779d434"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""e23cda3d-1af3-49c9-aed5-da47823d85c4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Roll"",
                    ""type"": ""Button"",
                    ""id"": ""a3d8ac33-69fa-4e76-ac81-2aa7640b1d5d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""845af14c-5de8-4b84-a955-d0d0c6f3557f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""BasicAbility"",
                    ""type"": ""Button"",
                    ""id"": ""c3aeb3e1-f083-459f-94b2-080e25d9b641"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UltimateAbility"",
                    ""type"": ""Button"",
                    ""id"": ""cf5f29d5-a9f2-44e2-8138-d46ede0859c1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PauseMenu"",
                    ""type"": ""Button"",
                    ""id"": ""4dfdae8e-9a66-4bed-917a-8933acee1a8d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2124cfe2-d72d-4e74-b77d-9a3c1ded361c"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e1e75649-7b20-4a40-82c1-dab0429e49b7"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""571f3155-61d4-45ec-a9f5-c81b15ae169b"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f30fb5ab-e37c-49c1-9b2e-d6330e73eaa8"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""11d7239f-6740-4426-9d91-120b62ca8c9f"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ceee1beb-e227-4356-b9ac-4711e702ca3d"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BasicAbility"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d5840c36-4279-466c-9355-3a1109ea9467"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UltimateAbility"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8cbf1fa0-e0a9-480b-816d-76c4d2bb02cd"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // ControllerGameplay
        m_ControllerGameplay = asset.FindActionMap("ControllerGameplay", throwIfNotFound: true);
        m_ControllerGameplay_Move = m_ControllerGameplay.FindAction("Move", throwIfNotFound: true);
        m_ControllerGameplay_Aim = m_ControllerGameplay.FindAction("Aim", throwIfNotFound: true);
        m_ControllerGameplay_Jump = m_ControllerGameplay.FindAction("Jump", throwIfNotFound: true);
        m_ControllerGameplay_Roll = m_ControllerGameplay.FindAction("Roll", throwIfNotFound: true);
        m_ControllerGameplay_Fire = m_ControllerGameplay.FindAction("Fire", throwIfNotFound: true);
        m_ControllerGameplay_BasicAbility = m_ControllerGameplay.FindAction("BasicAbility", throwIfNotFound: true);
        m_ControllerGameplay_UltimateAbility = m_ControllerGameplay.FindAction("UltimateAbility", throwIfNotFound: true);
        m_ControllerGameplay_PauseMenu = m_ControllerGameplay.FindAction("PauseMenu", throwIfNotFound: true);
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

    // ControllerGameplay
    private readonly InputActionMap m_ControllerGameplay;
    private IControllerGameplayActions m_ControllerGameplayActionsCallbackInterface;
    private readonly InputAction m_ControllerGameplay_Move;
    private readonly InputAction m_ControllerGameplay_Aim;
    private readonly InputAction m_ControllerGameplay_Jump;
    private readonly InputAction m_ControllerGameplay_Roll;
    private readonly InputAction m_ControllerGameplay_Fire;
    private readonly InputAction m_ControllerGameplay_BasicAbility;
    private readonly InputAction m_ControllerGameplay_UltimateAbility;
    private readonly InputAction m_ControllerGameplay_PauseMenu;
    public struct ControllerGameplayActions
    {
        private @ControllerActions m_Wrapper;
        public ControllerGameplayActions(@ControllerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_ControllerGameplay_Move;
        public InputAction @Aim => m_Wrapper.m_ControllerGameplay_Aim;
        public InputAction @Jump => m_Wrapper.m_ControllerGameplay_Jump;
        public InputAction @Roll => m_Wrapper.m_ControllerGameplay_Roll;
        public InputAction @Fire => m_Wrapper.m_ControllerGameplay_Fire;
        public InputAction @BasicAbility => m_Wrapper.m_ControllerGameplay_BasicAbility;
        public InputAction @UltimateAbility => m_Wrapper.m_ControllerGameplay_UltimateAbility;
        public InputAction @PauseMenu => m_Wrapper.m_ControllerGameplay_PauseMenu;
        public InputActionMap Get() { return m_Wrapper.m_ControllerGameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ControllerGameplayActions set) { return set.Get(); }
        public void SetCallbacks(IControllerGameplayActions instance)
        {
            if (m_Wrapper.m_ControllerGameplayActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_ControllerGameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_ControllerGameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_ControllerGameplayActionsCallbackInterface.OnMove;
                @Aim.started -= m_Wrapper.m_ControllerGameplayActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_ControllerGameplayActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_ControllerGameplayActionsCallbackInterface.OnAim;
                @Jump.started -= m_Wrapper.m_ControllerGameplayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_ControllerGameplayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_ControllerGameplayActionsCallbackInterface.OnJump;
                @Roll.started -= m_Wrapper.m_ControllerGameplayActionsCallbackInterface.OnRoll;
                @Roll.performed -= m_Wrapper.m_ControllerGameplayActionsCallbackInterface.OnRoll;
                @Roll.canceled -= m_Wrapper.m_ControllerGameplayActionsCallbackInterface.OnRoll;
                @Fire.started -= m_Wrapper.m_ControllerGameplayActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_ControllerGameplayActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_ControllerGameplayActionsCallbackInterface.OnFire;
                @BasicAbility.started -= m_Wrapper.m_ControllerGameplayActionsCallbackInterface.OnBasicAbility;
                @BasicAbility.performed -= m_Wrapper.m_ControllerGameplayActionsCallbackInterface.OnBasicAbility;
                @BasicAbility.canceled -= m_Wrapper.m_ControllerGameplayActionsCallbackInterface.OnBasicAbility;
                @UltimateAbility.started -= m_Wrapper.m_ControllerGameplayActionsCallbackInterface.OnUltimateAbility;
                @UltimateAbility.performed -= m_Wrapper.m_ControllerGameplayActionsCallbackInterface.OnUltimateAbility;
                @UltimateAbility.canceled -= m_Wrapper.m_ControllerGameplayActionsCallbackInterface.OnUltimateAbility;
                @PauseMenu.started -= m_Wrapper.m_ControllerGameplayActionsCallbackInterface.OnPauseMenu;
                @PauseMenu.performed -= m_Wrapper.m_ControllerGameplayActionsCallbackInterface.OnPauseMenu;
                @PauseMenu.canceled -= m_Wrapper.m_ControllerGameplayActionsCallbackInterface.OnPauseMenu;
            }
            m_Wrapper.m_ControllerGameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Roll.started += instance.OnRoll;
                @Roll.performed += instance.OnRoll;
                @Roll.canceled += instance.OnRoll;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @BasicAbility.started += instance.OnBasicAbility;
                @BasicAbility.performed += instance.OnBasicAbility;
                @BasicAbility.canceled += instance.OnBasicAbility;
                @UltimateAbility.started += instance.OnUltimateAbility;
                @UltimateAbility.performed += instance.OnUltimateAbility;
                @UltimateAbility.canceled += instance.OnUltimateAbility;
                @PauseMenu.started += instance.OnPauseMenu;
                @PauseMenu.performed += instance.OnPauseMenu;
                @PauseMenu.canceled += instance.OnPauseMenu;
            }
        }
    }
    public ControllerGameplayActions @ControllerGameplay => new ControllerGameplayActions(this);
    public interface IControllerGameplayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnRoll(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnBasicAbility(InputAction.CallbackContext context);
        void OnUltimateAbility(InputAction.CallbackContext context);
        void OnPauseMenu(InputAction.CallbackContext context);
    }
}
