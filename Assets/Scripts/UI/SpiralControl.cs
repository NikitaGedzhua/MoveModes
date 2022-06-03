using UnityEngine;
using UnityEngine.UI;

public class SpiralControl : MonoBehaviour
{
    [SerializeField] private GameModeController gameModeController;
    [SerializeField] private Button startModeButton;
    [SerializeField] private Button switchDirectionButton;

    private void Start()
    {
        startModeButton.onClick.AddListener(() => gameModeController.SetGameMode(eGameMode.SpiralMovement));

        var spiralGameMode = gameModeController.GetGameMode(eGameMode.SpiralMovement) as SpiralMovement;
        switchDirectionButton.onClick.AddListener(spiralGameMode.SwitchDirection);
    }
}