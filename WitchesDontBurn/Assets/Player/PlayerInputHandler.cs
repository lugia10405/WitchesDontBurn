using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private InputAction flyActions, castActions;
    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        flyActions = InputSystem.actions.FindAction("Move");
        castActions = InputSystem.actions.FindAction("Attack");


        // enable actions and subscribe safely
        if (flyActions != null)
        {
            flyActions.Enable();
        }


        if (castActions != null)
        {
            castActions.performed += Cast;
            castActions.Enable();
        }

    }

    private void Cast(InputAction.CallbackContext context)
    {
        if (characterController != null)
        {
            characterController.UseSkillA();
        }
    }
    
    void Update()
    {
        if (flyActions == null || characterController == null)
        {
            return;
        }

        Vector2 moveInput = flyActions.ReadValue<Vector2>();
        characterController.Move(moveInput);
    }

    private void OnDestroy()
    {
        if (castActions != null)
        {
            castActions.performed -= Cast;
            castActions.Disable();
        }
        if (flyActions != null)
        {
            flyActions.Disable();
        }
    }
}
