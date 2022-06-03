using System.Collections.Generic;
using ObjectMovement;
using UnityEngine;

public class GameModeController : MonoBehaviour
{
    [SerializeField] private List<GameModeBase> gameModes = new List<GameModeBase>();

    public void SetGameMode(eGameMode gameMode)
    {
        foreach (var mode in gameModes) mode.ActivateGameMode(false);

        gameModes.Find(b => b.eGameMode == gameMode).ActivateGameMode(true);
    }

    public GameModeBase GetGameMode(eGameMode gameMode)
    {
        return gameModes.Find(b => b.eGameMode == gameMode);
    }
}