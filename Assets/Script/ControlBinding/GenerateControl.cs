// GENERATED AUTOMATICALLY FROM 'Assets/Script/ControlBinding/Control.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GenerateControl : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GenerateControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Control"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""eff4a8b4-5102-4ebd-b5df-c00b0938d6c7"",
            ""actions"": [
                {
                    ""name"": ""UpMove"",
                    ""type"": ""Button"",
                    ""id"": ""fb752a4d-e2e4-4802-bc65-c216bb1b51eb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftMove"",
                    ""type"": ""Button"",
                    ""id"": ""7e675c9d-6bfc-4f61-883d-cceee7e3fea3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightMove"",
                    ""type"": ""Button"",
                    ""id"": ""36ac391a-d3f9-4641-a210-89fafb1c4a91"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateWeapon"",
                    ""type"": ""Value"",
                    ""id"": ""fc1345b0-5b15-4cda-985c-b5a2e4c5cd7c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PauseMenu"",
                    ""type"": ""Button"",
                    ""id"": ""db76b4d9-ca1e-42fa-8db6-9401332402a5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""62bce78a-3062-4cf0-9030-03e65010ff6d"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpMove"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""4d755b89-52c7-445b-b7c6-59ef6d8d249c"",
                    ""path"": ""<DualShockGamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""dc07a197-b34c-456e-b8b7-0c6ec9c7d017"",
                    ""path"": ""<DualShockGamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""7355cd75-e8b3-445e-8fc0-5e1f197fe2e8"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpMove"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""387feca7-dfe1-4c69-8edf-b9fa73740ccb"",
                    ""path"": ""<DualShockGamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""0d4a2465-38c0-455f-8128-c91141dc335d"",
                    ""path"": ""<DualShockGamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""cefedadc-0be3-4d09-bdf1-f66067bdae70"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8d722dee-c4d2-4d27-94b5-6b29bba576e7"",
                    ""path"": ""<DualShockGamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a09c10dc-a6dd-4988-a25d-9a7429901e72"",
                    ""path"": ""<DualShockGamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bfdcfffb-3501-4ec6-a18c-55507f58c0d0"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""InvertVector2(invertY=false)"",
                    ""groups"": """",
                    ""action"": ""RotateWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7bb456c9-fe81-4c5b-9abe-409d60d8f3c5"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UIScrollSaveGame"",
            ""id"": ""0f0a9db3-2ffc-443f-8dd6-d471a22743ef"",
            ""actions"": [
                {
                    ""name"": ""downScroll"",
                    ""type"": ""Button"",
                    ""id"": ""5e740f61-4659-402d-b59c-717533bdb69a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""upScroll"",
                    ""type"": ""Button"",
                    ""id"": ""dcc096aa-f7cf-4983-82a1-987369e083d7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""9381f1b6-8d5d-4c69-ad63-5359cd02412f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""74ded506-faf7-4fa5-a331-eb204ce16eb5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""26c87f16-2099-4ff5-9294-ffbf19ea4f30"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""downScroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c3dd7435-7cb4-4682-9d6e-eb060cf232fa"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""downScroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a839bd02-69e5-417e-ab72-445ae4fcb51b"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""upScroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0de5c56a-d905-4a64-8608-3b5a87b8e3f4"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""upScroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d34f47c1-0ad2-4fc0-bcb2-fb6032327b24"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5646ce4b-be58-4819-a931-0d2763e46edf"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UIScrollStatic"",
            ""id"": ""670cfdd6-8d34-431b-b143-ace19d4881ef"",
            ""actions"": [
                {
                    ""name"": ""downScroll"",
                    ""type"": ""Button"",
                    ""id"": ""6c20e5bf-a4eb-40e6-bc73-2c3a5f9f0a90"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""upScroll"",
                    ""type"": ""Button"",
                    ""id"": ""5dc3c9c8-3ac4-4ba9-aba8-a6107514625e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""153ff231-b622-4073-98d2-49af1c02977c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""6054d5d4-febd-4f1e-9fbe-6878c29dfc79"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""startButton"",
                    ""type"": ""Button"",
                    ""id"": ""11d46c50-e4af-4fd7-9dba-fb2ed76c02c1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""62893df9-63d5-404d-88aa-4569669eadde"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""downScroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cd414ab5-a4a9-47c8-9438-477260629a5a"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""downScroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""326d2ea7-47ab-4bb2-a8d0-fd9dc5458063"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""upScroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""394ba4c4-f507-4e4e-be13-2f8b4ad079de"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""upScroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dc506033-c831-4ef6-af34-acea4489def7"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9f14f4a1-e17b-4c87-8c4c-94d68cfe2673"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""49a53a2a-3f2e-4bec-9ab4-872a3aa88386"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""startButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UIScrollAllSide"",
            ""id"": ""bac00188-3cc6-4cf9-910b-64d238b9f9ec"",
            ""actions"": [
                {
                    ""name"": ""downScroll"",
                    ""type"": ""Button"",
                    ""id"": ""fca415a3-23f1-4b43-a6ff-218783e3f0fd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""upScroll"",
                    ""type"": ""Button"",
                    ""id"": ""e34d6d4b-1df7-4ea5-b6c4-8f30c040ff51"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""rightScroll"",
                    ""type"": ""Button"",
                    ""id"": ""98c24b14-97b9-4936-90fb-a2fc3e26fa29"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""leftScroll"",
                    ""type"": ""Button"",
                    ""id"": ""82d51c25-e2c3-45d7-b555-474c3b1a5124"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""57930c87-8866-4ff0-a338-d7d8afd18537"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""ac11f7b7-489c-45ee-aa17-e8657322fdb6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""73c47038-89b1-4375-bf72-804a30bf9ebe"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""downScroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""617521c8-befc-4352-882f-29eb01176901"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""downScroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1af273c7-0509-4cab-8814-48277cc459e1"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""upScroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b5d92b3e-5ddc-4eed-b496-0bda8344d7c3"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""upScroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f3927d2c-26e6-4eff-bbe6-8adfda08eb99"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1f7f3614-874d-4644-b11f-718f14205dd2"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""391433ed-42b2-4672-af0d-7baf82a38b31"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""rightScroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2b97ec0f-1361-47b2-9f35-51b4047ff78c"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""rightScroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a01b3262-e8bf-4077-80d2-3e05d3747c01"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""leftScroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9094e8db-8939-422e-ba4d-96f057e81817"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""leftScroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard&Mouse"",
            ""bindingGroup"": ""Keyboard&Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Touch"",
            ""bindingGroup"": ""Touch"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Joystick"",
            ""bindingGroup"": ""Joystick"",
            ""devices"": [
                {
                    ""devicePath"": ""<Joystick>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""XR"",
            ""bindingGroup"": ""XR"",
            ""devices"": [
                {
                    ""devicePath"": ""<XRController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_UpMove = m_Player.FindAction("UpMove", throwIfNotFound: true);
        m_Player_LeftMove = m_Player.FindAction("LeftMove", throwIfNotFound: true);
        m_Player_RightMove = m_Player.FindAction("RightMove", throwIfNotFound: true);
        m_Player_RotateWeapon = m_Player.FindAction("RotateWeapon", throwIfNotFound: true);
        m_Player_PauseMenu = m_Player.FindAction("PauseMenu", throwIfNotFound: true);
        // UIScrollSaveGame
        m_UIScrollSaveGame = asset.FindActionMap("UIScrollSaveGame", throwIfNotFound: true);
        m_UIScrollSaveGame_downScroll = m_UIScrollSaveGame.FindAction("downScroll", throwIfNotFound: true);
        m_UIScrollSaveGame_upScroll = m_UIScrollSaveGame.FindAction("upScroll", throwIfNotFound: true);
        m_UIScrollSaveGame_Select = m_UIScrollSaveGame.FindAction("Select", throwIfNotFound: true);
        m_UIScrollSaveGame_Back = m_UIScrollSaveGame.FindAction("Back", throwIfNotFound: true);
        // UIScrollStatic
        m_UIScrollStatic = asset.FindActionMap("UIScrollStatic", throwIfNotFound: true);
        m_UIScrollStatic_downScroll = m_UIScrollStatic.FindAction("downScroll", throwIfNotFound: true);
        m_UIScrollStatic_upScroll = m_UIScrollStatic.FindAction("upScroll", throwIfNotFound: true);
        m_UIScrollStatic_Select = m_UIScrollStatic.FindAction("Select", throwIfNotFound: true);
        m_UIScrollStatic_Back = m_UIScrollStatic.FindAction("Back", throwIfNotFound: true);
        m_UIScrollStatic_startButton = m_UIScrollStatic.FindAction("startButton", throwIfNotFound: true);
        // UIScrollAllSide
        m_UIScrollAllSide = asset.FindActionMap("UIScrollAllSide", throwIfNotFound: true);
        m_UIScrollAllSide_downScroll = m_UIScrollAllSide.FindAction("downScroll", throwIfNotFound: true);
        m_UIScrollAllSide_upScroll = m_UIScrollAllSide.FindAction("upScroll", throwIfNotFound: true);
        m_UIScrollAllSide_rightScroll = m_UIScrollAllSide.FindAction("rightScroll", throwIfNotFound: true);
        m_UIScrollAllSide_leftScroll = m_UIScrollAllSide.FindAction("leftScroll", throwIfNotFound: true);
        m_UIScrollAllSide_Select = m_UIScrollAllSide.FindAction("Select", throwIfNotFound: true);
        m_UIScrollAllSide_Back = m_UIScrollAllSide.FindAction("Back", throwIfNotFound: true);
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
    private readonly InputAction m_Player_UpMove;
    private readonly InputAction m_Player_LeftMove;
    private readonly InputAction m_Player_RightMove;
    private readonly InputAction m_Player_RotateWeapon;
    private readonly InputAction m_Player_PauseMenu;
    public struct PlayerActions
    {
        private @GenerateControl m_Wrapper;
        public PlayerActions(@GenerateControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @UpMove => m_Wrapper.m_Player_UpMove;
        public InputAction @LeftMove => m_Wrapper.m_Player_LeftMove;
        public InputAction @RightMove => m_Wrapper.m_Player_RightMove;
        public InputAction @RotateWeapon => m_Wrapper.m_Player_RotateWeapon;
        public InputAction @PauseMenu => m_Wrapper.m_Player_PauseMenu;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @UpMove.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUpMove;
                @UpMove.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUpMove;
                @UpMove.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUpMove;
                @LeftMove.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftMove;
                @LeftMove.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftMove;
                @LeftMove.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftMove;
                @RightMove.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightMove;
                @RightMove.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightMove;
                @RightMove.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightMove;
                @RotateWeapon.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotateWeapon;
                @RotateWeapon.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotateWeapon;
                @RotateWeapon.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotateWeapon;
                @PauseMenu.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPauseMenu;
                @PauseMenu.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPauseMenu;
                @PauseMenu.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPauseMenu;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @UpMove.started += instance.OnUpMove;
                @UpMove.performed += instance.OnUpMove;
                @UpMove.canceled += instance.OnUpMove;
                @LeftMove.started += instance.OnLeftMove;
                @LeftMove.performed += instance.OnLeftMove;
                @LeftMove.canceled += instance.OnLeftMove;
                @RightMove.started += instance.OnRightMove;
                @RightMove.performed += instance.OnRightMove;
                @RightMove.canceled += instance.OnRightMove;
                @RotateWeapon.started += instance.OnRotateWeapon;
                @RotateWeapon.performed += instance.OnRotateWeapon;
                @RotateWeapon.canceled += instance.OnRotateWeapon;
                @PauseMenu.started += instance.OnPauseMenu;
                @PauseMenu.performed += instance.OnPauseMenu;
                @PauseMenu.canceled += instance.OnPauseMenu;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // UIScrollSaveGame
    private readonly InputActionMap m_UIScrollSaveGame;
    private IUIScrollSaveGameActions m_UIScrollSaveGameActionsCallbackInterface;
    private readonly InputAction m_UIScrollSaveGame_downScroll;
    private readonly InputAction m_UIScrollSaveGame_upScroll;
    private readonly InputAction m_UIScrollSaveGame_Select;
    private readonly InputAction m_UIScrollSaveGame_Back;
    public struct UIScrollSaveGameActions
    {
        private @GenerateControl m_Wrapper;
        public UIScrollSaveGameActions(@GenerateControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @downScroll => m_Wrapper.m_UIScrollSaveGame_downScroll;
        public InputAction @upScroll => m_Wrapper.m_UIScrollSaveGame_upScroll;
        public InputAction @Select => m_Wrapper.m_UIScrollSaveGame_Select;
        public InputAction @Back => m_Wrapper.m_UIScrollSaveGame_Back;
        public InputActionMap Get() { return m_Wrapper.m_UIScrollSaveGame; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIScrollSaveGameActions set) { return set.Get(); }
        public void SetCallbacks(IUIScrollSaveGameActions instance)
        {
            if (m_Wrapper.m_UIScrollSaveGameActionsCallbackInterface != null)
            {
                @downScroll.started -= m_Wrapper.m_UIScrollSaveGameActionsCallbackInterface.OnDownScroll;
                @downScroll.performed -= m_Wrapper.m_UIScrollSaveGameActionsCallbackInterface.OnDownScroll;
                @downScroll.canceled -= m_Wrapper.m_UIScrollSaveGameActionsCallbackInterface.OnDownScroll;
                @upScroll.started -= m_Wrapper.m_UIScrollSaveGameActionsCallbackInterface.OnUpScroll;
                @upScroll.performed -= m_Wrapper.m_UIScrollSaveGameActionsCallbackInterface.OnUpScroll;
                @upScroll.canceled -= m_Wrapper.m_UIScrollSaveGameActionsCallbackInterface.OnUpScroll;
                @Select.started -= m_Wrapper.m_UIScrollSaveGameActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_UIScrollSaveGameActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_UIScrollSaveGameActionsCallbackInterface.OnSelect;
                @Back.started -= m_Wrapper.m_UIScrollSaveGameActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_UIScrollSaveGameActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_UIScrollSaveGameActionsCallbackInterface.OnBack;
            }
            m_Wrapper.m_UIScrollSaveGameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @downScroll.started += instance.OnDownScroll;
                @downScroll.performed += instance.OnDownScroll;
                @downScroll.canceled += instance.OnDownScroll;
                @upScroll.started += instance.OnUpScroll;
                @upScroll.performed += instance.OnUpScroll;
                @upScroll.canceled += instance.OnUpScroll;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
            }
        }
    }
    public UIScrollSaveGameActions @UIScrollSaveGame => new UIScrollSaveGameActions(this);

    // UIScrollStatic
    private readonly InputActionMap m_UIScrollStatic;
    private IUIScrollStaticActions m_UIScrollStaticActionsCallbackInterface;
    private readonly InputAction m_UIScrollStatic_downScroll;
    private readonly InputAction m_UIScrollStatic_upScroll;
    private readonly InputAction m_UIScrollStatic_Select;
    private readonly InputAction m_UIScrollStatic_Back;
    private readonly InputAction m_UIScrollStatic_startButton;
    public struct UIScrollStaticActions
    {
        private @GenerateControl m_Wrapper;
        public UIScrollStaticActions(@GenerateControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @downScroll => m_Wrapper.m_UIScrollStatic_downScroll;
        public InputAction @upScroll => m_Wrapper.m_UIScrollStatic_upScroll;
        public InputAction @Select => m_Wrapper.m_UIScrollStatic_Select;
        public InputAction @Back => m_Wrapper.m_UIScrollStatic_Back;
        public InputAction @startButton => m_Wrapper.m_UIScrollStatic_startButton;
        public InputActionMap Get() { return m_Wrapper.m_UIScrollStatic; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIScrollStaticActions set) { return set.Get(); }
        public void SetCallbacks(IUIScrollStaticActions instance)
        {
            if (m_Wrapper.m_UIScrollStaticActionsCallbackInterface != null)
            {
                @downScroll.started -= m_Wrapper.m_UIScrollStaticActionsCallbackInterface.OnDownScroll;
                @downScroll.performed -= m_Wrapper.m_UIScrollStaticActionsCallbackInterface.OnDownScroll;
                @downScroll.canceled -= m_Wrapper.m_UIScrollStaticActionsCallbackInterface.OnDownScroll;
                @upScroll.started -= m_Wrapper.m_UIScrollStaticActionsCallbackInterface.OnUpScroll;
                @upScroll.performed -= m_Wrapper.m_UIScrollStaticActionsCallbackInterface.OnUpScroll;
                @upScroll.canceled -= m_Wrapper.m_UIScrollStaticActionsCallbackInterface.OnUpScroll;
                @Select.started -= m_Wrapper.m_UIScrollStaticActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_UIScrollStaticActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_UIScrollStaticActionsCallbackInterface.OnSelect;
                @Back.started -= m_Wrapper.m_UIScrollStaticActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_UIScrollStaticActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_UIScrollStaticActionsCallbackInterface.OnBack;
                @startButton.started -= m_Wrapper.m_UIScrollStaticActionsCallbackInterface.OnStartButton;
                @startButton.performed -= m_Wrapper.m_UIScrollStaticActionsCallbackInterface.OnStartButton;
                @startButton.canceled -= m_Wrapper.m_UIScrollStaticActionsCallbackInterface.OnStartButton;
            }
            m_Wrapper.m_UIScrollStaticActionsCallbackInterface = instance;
            if (instance != null)
            {
                @downScroll.started += instance.OnDownScroll;
                @downScroll.performed += instance.OnDownScroll;
                @downScroll.canceled += instance.OnDownScroll;
                @upScroll.started += instance.OnUpScroll;
                @upScroll.performed += instance.OnUpScroll;
                @upScroll.canceled += instance.OnUpScroll;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
                @startButton.started += instance.OnStartButton;
                @startButton.performed += instance.OnStartButton;
                @startButton.canceled += instance.OnStartButton;
            }
        }
    }
    public UIScrollStaticActions @UIScrollStatic => new UIScrollStaticActions(this);

    // UIScrollAllSide
    private readonly InputActionMap m_UIScrollAllSide;
    private IUIScrollAllSideActions m_UIScrollAllSideActionsCallbackInterface;
    private readonly InputAction m_UIScrollAllSide_downScroll;
    private readonly InputAction m_UIScrollAllSide_upScroll;
    private readonly InputAction m_UIScrollAllSide_rightScroll;
    private readonly InputAction m_UIScrollAllSide_leftScroll;
    private readonly InputAction m_UIScrollAllSide_Select;
    private readonly InputAction m_UIScrollAllSide_Back;
    public struct UIScrollAllSideActions
    {
        private @GenerateControl m_Wrapper;
        public UIScrollAllSideActions(@GenerateControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @downScroll => m_Wrapper.m_UIScrollAllSide_downScroll;
        public InputAction @upScroll => m_Wrapper.m_UIScrollAllSide_upScroll;
        public InputAction @rightScroll => m_Wrapper.m_UIScrollAllSide_rightScroll;
        public InputAction @leftScroll => m_Wrapper.m_UIScrollAllSide_leftScroll;
        public InputAction @Select => m_Wrapper.m_UIScrollAllSide_Select;
        public InputAction @Back => m_Wrapper.m_UIScrollAllSide_Back;
        public InputActionMap Get() { return m_Wrapper.m_UIScrollAllSide; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIScrollAllSideActions set) { return set.Get(); }
        public void SetCallbacks(IUIScrollAllSideActions instance)
        {
            if (m_Wrapper.m_UIScrollAllSideActionsCallbackInterface != null)
            {
                @downScroll.started -= m_Wrapper.m_UIScrollAllSideActionsCallbackInterface.OnDownScroll;
                @downScroll.performed -= m_Wrapper.m_UIScrollAllSideActionsCallbackInterface.OnDownScroll;
                @downScroll.canceled -= m_Wrapper.m_UIScrollAllSideActionsCallbackInterface.OnDownScroll;
                @upScroll.started -= m_Wrapper.m_UIScrollAllSideActionsCallbackInterface.OnUpScroll;
                @upScroll.performed -= m_Wrapper.m_UIScrollAllSideActionsCallbackInterface.OnUpScroll;
                @upScroll.canceled -= m_Wrapper.m_UIScrollAllSideActionsCallbackInterface.OnUpScroll;
                @rightScroll.started -= m_Wrapper.m_UIScrollAllSideActionsCallbackInterface.OnRightScroll;
                @rightScroll.performed -= m_Wrapper.m_UIScrollAllSideActionsCallbackInterface.OnRightScroll;
                @rightScroll.canceled -= m_Wrapper.m_UIScrollAllSideActionsCallbackInterface.OnRightScroll;
                @leftScroll.started -= m_Wrapper.m_UIScrollAllSideActionsCallbackInterface.OnLeftScroll;
                @leftScroll.performed -= m_Wrapper.m_UIScrollAllSideActionsCallbackInterface.OnLeftScroll;
                @leftScroll.canceled -= m_Wrapper.m_UIScrollAllSideActionsCallbackInterface.OnLeftScroll;
                @Select.started -= m_Wrapper.m_UIScrollAllSideActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_UIScrollAllSideActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_UIScrollAllSideActionsCallbackInterface.OnSelect;
                @Back.started -= m_Wrapper.m_UIScrollAllSideActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_UIScrollAllSideActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_UIScrollAllSideActionsCallbackInterface.OnBack;
            }
            m_Wrapper.m_UIScrollAllSideActionsCallbackInterface = instance;
            if (instance != null)
            {
                @downScroll.started += instance.OnDownScroll;
                @downScroll.performed += instance.OnDownScroll;
                @downScroll.canceled += instance.OnDownScroll;
                @upScroll.started += instance.OnUpScroll;
                @upScroll.performed += instance.OnUpScroll;
                @upScroll.canceled += instance.OnUpScroll;
                @rightScroll.started += instance.OnRightScroll;
                @rightScroll.performed += instance.OnRightScroll;
                @rightScroll.canceled += instance.OnRightScroll;
                @leftScroll.started += instance.OnLeftScroll;
                @leftScroll.performed += instance.OnLeftScroll;
                @leftScroll.canceled += instance.OnLeftScroll;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
            }
        }
    }
    public UIScrollAllSideActions @UIScrollAllSide => new UIScrollAllSideActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard&Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_TouchSchemeIndex = -1;
    public InputControlScheme TouchScheme
    {
        get
        {
            if (m_TouchSchemeIndex == -1) m_TouchSchemeIndex = asset.FindControlSchemeIndex("Touch");
            return asset.controlSchemes[m_TouchSchemeIndex];
        }
    }
    private int m_JoystickSchemeIndex = -1;
    public InputControlScheme JoystickScheme
    {
        get
        {
            if (m_JoystickSchemeIndex == -1) m_JoystickSchemeIndex = asset.FindControlSchemeIndex("Joystick");
            return asset.controlSchemes[m_JoystickSchemeIndex];
        }
    }
    private int m_XRSchemeIndex = -1;
    public InputControlScheme XRScheme
    {
        get
        {
            if (m_XRSchemeIndex == -1) m_XRSchemeIndex = asset.FindControlSchemeIndex("XR");
            return asset.controlSchemes[m_XRSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnUpMove(InputAction.CallbackContext context);
        void OnLeftMove(InputAction.CallbackContext context);
        void OnRightMove(InputAction.CallbackContext context);
        void OnRotateWeapon(InputAction.CallbackContext context);
        void OnPauseMenu(InputAction.CallbackContext context);
    }
    public interface IUIScrollSaveGameActions
    {
        void OnDownScroll(InputAction.CallbackContext context);
        void OnUpScroll(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
    }
    public interface IUIScrollStaticActions
    {
        void OnDownScroll(InputAction.CallbackContext context);
        void OnUpScroll(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
        void OnStartButton(InputAction.CallbackContext context);
    }
    public interface IUIScrollAllSideActions
    {
        void OnDownScroll(InputAction.CallbackContext context);
        void OnUpScroll(InputAction.CallbackContext context);
        void OnRightScroll(InputAction.CallbackContext context);
        void OnLeftScroll(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
    }
}
