using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : AbstractInput
{
    private PlayerInputActions inputActions;
    [SerializeField] private Button collect_DropButton;

    void Start()
    {
        inputActions = new();
        collect_DropButton.onClick.AddListener(OnCollectButtonClick);
        inputActions.Enable();
        inputActions.Player.Move.performed += (value) => direction = value.ReadValue<Vector2>();
    }

    private void OnCollectButtonClick()
    {
        OnCollectItem();
        collect_DropButton.onClick.RemoveListener(OnCollectButtonClick);
        collect_DropButton.onClick.AddListener(OnDropButtonClick);
    }

    private void OnDropButtonClick()
    {
        OnDropItem();
        collect_DropButton.onClick.RemoveListener(OnDropButtonClick);
        collect_DropButton.onClick.AddListener(OnCollectButtonClick);
    }
}
