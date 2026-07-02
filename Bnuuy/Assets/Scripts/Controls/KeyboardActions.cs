// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Controls/KeyboardActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @KeyboardActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @KeyboardActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""KeyboardActions"",
    ""maps"": [
        {
            ""name"": ""KeyboardGameplay"",
            ""id"": ""3de81b56-bcac-4d9c-8395-5012f99c5384"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""458f26fd-e983-4260-9c12-cef916f0c77a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Button"",
                    ""id"": ""181edba8-497c-4fde-8473-f330ae26008a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""ad2be571-a56f-433b-ae43-f85544d638b4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Roll"",
                    ""type"": ""Button"",
                    ""id"": ""e6c3cdc3-36b2-4c77-a077-9669a6cb0fcb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""96d1a1be-9656-4cc8-8678-8abe41e28c33"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""BasicAbility"",
                    ""type"": ""Button"",
                    ""id"": ""17c91ed6-7023-42bf-b597-399862b30cbb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UltimateAbility"",
                    ""type"": ""Button"",
                    ""id"": ""f06fb240-0688-4bd6-b555-ef0b23da3a16"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PauseMenu"",
                    ""type"": ""Button"",
                    ""id"": ""5804679a-6c33-4fb2-b12a-045324b6221d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""ed71906e-e5ff-4001-bda4-640f08859626"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""acaed6ae-5428-487f-946b-340a68558f5f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""cadb6390-a6eb-4b27-83d9-49fad65691b0"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a68cd038-cdd7-4283-8c98-66dbc7b38da0"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a6ca1e26-7cbb-4bec-ac67-d5e72da2e1fd"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b42cd3b6-30c2-4ad4-a8b0-70ed657a3644"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7cfc6707-503c-4cda-939b-565317c69ec2"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5679c1b8-b413-48e9-a091-ad6f49805588"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ef2686dd-c0d9-4640-b9f8-c477ddb7ebb4"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ac54517c-57d8-4f28-9a6e-5a0f6cc25a9c"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BasicAbility"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aff1e576-3426-4b7c-bb6d-493c75518c44"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UltimateAbility"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""96cc5f76-4c53-4a03-a301-09dcef649b9b"",
                    ""path"": ""<Keyboard>/escape"",
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
        // KeyboardGameplay
        m_KeyboardGameplay = asset.FindActionMap("KeyboardGameplay", throwIfNotFound: true);
        m_KeyboardGameplay_Move = m_KeyboardGameplay.FindAction("Move", throwIfNotFound: true);
        m_KeyboardGameplay_Aim = m_KeyboardGameplay.FindAction("Aim", throwIfNotFound: true);
        m_KeyboardGameplay_Jump = m_KeyboardGameplay.FindAction("Jump", throwIfNotFound: true);
        m_KeyboardGameplay_Roll = m_KeyboardGameplay.FindAction("Roll", throwIfNotFound: true);
        m_KeyboardGameplay_Fire = m_KeyboardGameplay.FindAction("Fire", throwIfNotFound: true);
        m_KeyboardGameplay_BasicAbility = m_KeyboardGameplay.FindAction("BasicAbility", throwIfNotFound: true);
        m_KeyboardGameplay_UltimateAbility = m_KeyboardGameplay.FindAction("UltimateAbility", throwIfNotFound: true);
        m_KeyboardGameplay_PauseMenu = m_KeyboardGameplay.FindAction("PauseMenu", throwIfNotFound: true);
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

    // KeyboardGameplay
    private readonly InputActionMap m_KeyboardGameplay;
    private IKeyboardGameplayActions m_KeyboardGameplayActionsCallbackInterface;
    private readonly InputAction m_KeyboardGameplay_Move;
    private readonly InputAction m_KeyboardGameplay_Aim;
    private readonly InputAction m_KeyboardGameplay_Jump;
    private readonly InputAction m_KeyboardGameplay_Roll;
    private readonly InputAction m_KeyboardGameplay_Fire;
    private readonly InputAction m_KeyboardGameplay_BasicAbility;
    private readonly InputAction m_KeyboardGameplay_UltimateAbility;
    private readonly InputAction m_KeyboardGameplay_PauseMenu;
    public struct KeyboardGameplayActions
    {
        private @KeyboardActions m_Wrapper;
        public KeyboardGameplayActions(@KeyboardActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_KeyboardGameplay_Move;
        public InputAction @Aim => m_Wrapper.m_KeyboardGameplay_Aim;
        public InputAction @Jump => m_Wrapper.m_KeyboardGameplay_Jump;
        public InputAction @Roll => m_Wrapper.m_KeyboardGameplay_Roll;
        public InputAction @Fire => m_Wrapper.m_KeyboardGameplay_Fire;
        public InputAction @BasicAbility => m_Wrapper.m_KeyboardGameplay_BasicAbility;
        public InputAction @UltimateAbility => m_Wrapper.m_KeyboardGameplay_UltimateAbility;
        public InputAction @PauseMenu => m_Wrapper.m_KeyboardGameplay_PauseMenu;
        public InputActionMap Get() { return m_Wrapper.m_KeyboardGameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyboardGameplayActions set) { return set.Get(); }
        public void SetCallbacks(IKeyboardGameplayActions instance)
        {
            if (m_Wrapper.m_KeyboardGameplayActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_KeyboardGameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_KeyboardGameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_KeyboardGameplayActionsCallbackInterface.OnMove;
                @Aim.started -= m_Wrapper.m_KeyboardGameplayActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_KeyboardGameplayActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_KeyboardGameplayActionsCallbackInterface.OnAim;
                @Jump.started -= m_Wrapper.m_KeyboardGameplayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_KeyboardGameplayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_KeyboardGameplayActionsCallbackInterface.OnJump;
                @Roll.started -= m_Wrapper.m_KeyboardGameplayActionsCallbackInterface.OnRoll;
                @Roll.performed -= m_Wrapper.m_KeyboardGameplayActionsCallbackInterface.OnRoll;
                @Roll.canceled -= m_Wrapper.m_KeyboardGameplayActionsCallbackInterface.OnRoll;
                @Fire.started -= m_Wrapper.m_KeyboardGameplayActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_KeyboardGameplayActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_KeyboardGameplayActionsCallbackInterface.OnFire;
                @BasicAbility.started -= m_Wrapper.m_KeyboardGameplayActionsCallbackInterface.OnBasicAbility;
                @BasicAbility.performed -= m_Wrapper.m_KeyboardGameplayActionsCallbackInterface.OnBasicAbility;
                @BasicAbility.canceled -= m_Wrapper.m_KeyboardGameplayActionsCallbackInterface.OnBasicAbility;
                @UltimateAbility.started -= m_Wrapper.m_KeyboardGameplayActionsCallbackInterface.OnUltimateAbility;
                @UltimateAbility.performed -= m_Wrapper.m_KeyboardGameplayActionsCallbackInterface.OnUltimateAbility;
                @UltimateAbility.canceled -= m_Wrapper.m_KeyboardGameplayActionsCallbackInterface.OnUltimateAbility;
                @PauseMenu.started -= m_Wrapper.m_KeyboardGameplayActionsCallbackInterface.OnPauseMenu;
                @PauseMenu.performed -= m_Wrapper.m_KeyboardGameplayActionsCallbackInterface.OnPauseMenu;
                @PauseMenu.canceled -= m_Wrapper.m_KeyboardGameplayActionsCallbackInterface.OnPauseMenu;
            }
            m_Wrapper.m_KeyboardGameplayActionsCallbackInterface = instance;
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
    public KeyboardGameplayActions @KeyboardGameplay => new KeyboardGameplayActions(this);
    public interface IKeyboardGameplayActions
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
