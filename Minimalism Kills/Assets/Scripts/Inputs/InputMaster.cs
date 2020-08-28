// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Inputs/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""edd13b0b-1a7a-463d-b0de-00713e7e31ad"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""393bd35e-7966-40a5-bafb-9789b53460be"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""6c764b21-8e46-4eff-b1b5-537c0a286dfc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""c24f7980-3896-41c9-8da8-31f53ad64f4b"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""29bf0e52-64ba-47e9-bd4d-64a436866fa8"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""b3dd6bef-955b-4896-8e30-780160a0c3b6"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""429e891f-6ebc-493e-92e7-395f5be7be81"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""08fdda04-c6e9-4078-b83f-41025646fdf2"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Lens"",
            ""id"": ""a61accd3-6224-4df5-af5f-f5b0a4bc598d"",
            ""actions"": [
                {
                    ""name"": ""LensMovement"",
                    ""type"": ""Button"",
                    ""id"": ""25679112-e624-4e8c-9fe3-a8d212df5223"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""LensMovement"",
                    ""id"": ""c2925df5-1024-4421-a80d-a3d240bfa060"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LensMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""dc415457-b5c3-42d3-a462-8446c55dee66"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LensMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e5affac1-f9f0-42ae-89d4-6b9ab2da54ab"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LensMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a644518c-0647-42c3-a41d-a1c9b338d5b6"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LensMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""56b872e1-2c9c-4469-9ac0-1d82ab08d97e"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LensMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""GameController"",
            ""id"": ""8def86b2-5383-4be8-ad31-7ea9e0d4cd25"",
            ""actions"": [
                {
                    ""name"": ""Reset Level"",
                    ""type"": ""Button"",
                    ""id"": ""eaa78bd7-97f4-460f-8f02-ee31642802b9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""60410612-c460-4213-879e-3a1b9b23c0a3"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reset Level"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e22e7df5-c082-49cc-a376-80d4381aae78"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reset Level"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Text"",
            ""id"": ""4c4779cd-d699-4f6b-ab51-0a7f07b83140"",
            ""actions"": [
                {
                    ""name"": ""Advance"",
                    ""type"": ""Button"",
                    ""id"": ""a20d68dc-b7ef-4acf-99db-60d670a7b729"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4bc58b6d-879e-4220-887d-17e3278c8405"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Advance"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        // Lens
        m_Lens = asset.FindActionMap("Lens", throwIfNotFound: true);
        m_Lens_LensMovement = m_Lens.FindAction("LensMovement", throwIfNotFound: true);
        // GameController
        m_GameController = asset.FindActionMap("GameController", throwIfNotFound: true);
        m_GameController_ResetLevel = m_GameController.FindAction("Reset Level", throwIfNotFound: true);
        // Text
        m_Text = asset.FindActionMap("Text", throwIfNotFound: true);
        m_Text_Advance = m_Text.FindAction("Advance", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Jump;
    public struct PlayerActions
    {
        private @InputMaster m_Wrapper;
        public PlayerActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Lens
    private readonly InputActionMap m_Lens;
    private ILensActions m_LensActionsCallbackInterface;
    private readonly InputAction m_Lens_LensMovement;
    public struct LensActions
    {
        private @InputMaster m_Wrapper;
        public LensActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @LensMovement => m_Wrapper.m_Lens_LensMovement;
        public InputActionMap Get() { return m_Wrapper.m_Lens; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(LensActions set) { return set.Get(); }
        public void SetCallbacks(ILensActions instance)
        {
            if (m_Wrapper.m_LensActionsCallbackInterface != null)
            {
                @LensMovement.started -= m_Wrapper.m_LensActionsCallbackInterface.OnLensMovement;
                @LensMovement.performed -= m_Wrapper.m_LensActionsCallbackInterface.OnLensMovement;
                @LensMovement.canceled -= m_Wrapper.m_LensActionsCallbackInterface.OnLensMovement;
            }
            m_Wrapper.m_LensActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LensMovement.started += instance.OnLensMovement;
                @LensMovement.performed += instance.OnLensMovement;
                @LensMovement.canceled += instance.OnLensMovement;
            }
        }
    }
    public LensActions @Lens => new LensActions(this);

    // GameController
    private readonly InputActionMap m_GameController;
    private IGameControllerActions m_GameControllerActionsCallbackInterface;
    private readonly InputAction m_GameController_ResetLevel;
    public struct GameControllerActions
    {
        private @InputMaster m_Wrapper;
        public GameControllerActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @ResetLevel => m_Wrapper.m_GameController_ResetLevel;
        public InputActionMap Get() { return m_Wrapper.m_GameController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameControllerActions set) { return set.Get(); }
        public void SetCallbacks(IGameControllerActions instance)
        {
            if (m_Wrapper.m_GameControllerActionsCallbackInterface != null)
            {
                @ResetLevel.started -= m_Wrapper.m_GameControllerActionsCallbackInterface.OnResetLevel;
                @ResetLevel.performed -= m_Wrapper.m_GameControllerActionsCallbackInterface.OnResetLevel;
                @ResetLevel.canceled -= m_Wrapper.m_GameControllerActionsCallbackInterface.OnResetLevel;
            }
            m_Wrapper.m_GameControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ResetLevel.started += instance.OnResetLevel;
                @ResetLevel.performed += instance.OnResetLevel;
                @ResetLevel.canceled += instance.OnResetLevel;
            }
        }
    }
    public GameControllerActions @GameController => new GameControllerActions(this);

    // Text
    private readonly InputActionMap m_Text;
    private ITextActions m_TextActionsCallbackInterface;
    private readonly InputAction m_Text_Advance;
    public struct TextActions
    {
        private @InputMaster m_Wrapper;
        public TextActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Advance => m_Wrapper.m_Text_Advance;
        public InputActionMap Get() { return m_Wrapper.m_Text; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TextActions set) { return set.Get(); }
        public void SetCallbacks(ITextActions instance)
        {
            if (m_Wrapper.m_TextActionsCallbackInterface != null)
            {
                @Advance.started -= m_Wrapper.m_TextActionsCallbackInterface.OnAdvance;
                @Advance.performed -= m_Wrapper.m_TextActionsCallbackInterface.OnAdvance;
                @Advance.canceled -= m_Wrapper.m_TextActionsCallbackInterface.OnAdvance;
            }
            m_Wrapper.m_TextActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Advance.started += instance.OnAdvance;
                @Advance.performed += instance.OnAdvance;
                @Advance.canceled += instance.OnAdvance;
            }
        }
    }
    public TextActions @Text => new TextActions(this);
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
    public interface ILensActions
    {
        void OnLensMovement(InputAction.CallbackContext context);
    }
    public interface IGameControllerActions
    {
        void OnResetLevel(InputAction.CallbackContext context);
    }
    public interface ITextActions
    {
        void OnAdvance(InputAction.CallbackContext context);
    }
}
