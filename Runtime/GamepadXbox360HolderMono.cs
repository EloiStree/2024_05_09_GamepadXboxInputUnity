using UnityEngine;

namespace Eloi.Input.Gamepad
{
    public class GamepadXbox360HolderMono : MonoBehaviour, I_GamepadXbox360HolderMono
    {
        public GamepadXbox360 m_gamepadEvent;
        public GamepadXbox360 GetGamepadXbox360()
        {
            return m_gamepadEvent;
        }
    }
}