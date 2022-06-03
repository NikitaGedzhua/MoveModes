using UnityEngine;
using UnityEngine.UI;

public class CircleControl : MonoBehaviour
{
    [SerializeField] private GameModeController gameModeController;
    [SerializeField] private Button button;

    private void Start()
    {
        button.onClick.AddListener(() => gameModeController.SetGameMode(eGameMode.CircleMovement));
    }
}