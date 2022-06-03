using UnityEngine;

namespace ObjectMovement
{
    public abstract class GameModeBase : MonoBehaviour
    {
        public eGameMode eGameMode;
        protected bool modeIsActive;

        public virtual void ActivateGameMode(bool active)
        {
            modeIsActive = active;
        }
    }
}