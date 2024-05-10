using UnityEngine;

namespace Eloi.Input.Gamepad
{

    public class InspectorGamepadInputToUnityEventMono : GamepadXbox360HolderMono
    {


        public void SetKeyButtonDown(bool value) => m_gamepadEvent.m_button.m_down.SetValue(value);
        public void SetKeyButtonUp(bool value) => m_gamepadEvent.m_button.m_up.SetValue(value);
        public void SetKeyButtonLeft(bool value) => m_gamepadEvent.m_button.m_left.SetValue(value);
        public void SetKeyButtonRight(bool value) => m_gamepadEvent.m_button.m_right.SetValue(value);
        public void SetKeyPadDown(bool value) => m_gamepadEvent.m_pad.m_down.SetValue(value);
        public void SetKeyPadUp(bool value) => m_gamepadEvent.m_pad.m_up.SetValue(value);
        public void SetKeyPadLeft(bool value) => m_gamepadEvent.m_pad.m_left.SetValue(value);
        public void SetKeyPadRight(bool value) => m_gamepadEvent.m_pad.m_right.SetValue(value);
        public void SetMenuLeft(bool value) => m_gamepadEvent.m_menuLeft.SetValue(value);
        public void SetMenuRight(bool value) => m_gamepadEvent.m_menuRight.SetValue(value);
        public void SetThumbLeft(bool value) => m_gamepadEvent.m_thumbLeft.SetValue(value);
        public void SetThumbRight(bool value) => m_gamepadEvent.m_thumbRight.SetValue(value);
        public void SetShoulderLeft(bool value) => m_gamepadEvent.m_shoulderLeft.SetValue(value);
        public void SetShoulderRight(bool value) => m_gamepadEvent.m_shoulderRight.SetValue(value);

        public void SetTriggerLeft(float value) => m_gamepadEvent.m_triggerLeft.SetValue(value);
        public void SetTriggerRight(float value) => m_gamepadEvent.m_triggerLeft.SetValue(value);
        public void SetJoystickLeftHorizontal(float value) => m_gamepadEvent.m_joystickLeftHorizontal.SetValue(value);
        public void SetJoystickLeftVertical(float value) => m_gamepadEvent.m_joystickLeftVertical.SetValue(value);
        public void SetJoystickRightHorizontal(float value) => m_gamepadEvent.m_joystickRightHorizontal.SetValue(value);
        public void SetJoystickRightVertical(float value) => m_gamepadEvent.m_joystickRightVertical.SetValue(value);


        [ContextMenu("Push Random for all")]
        public void PushRandomForAll() {

            SetKeyButtonDown(GetRandomBool());
            SetKeyButtonUp(GetRandomBool());
            SetKeyButtonLeft(GetRandomBool());
            SetKeyButtonRight(GetRandomBool());
            SetKeyPadDown(GetRandomBool());
            SetKeyPadUp(GetRandomBool());
            SetKeyPadLeft(GetRandomBool());
            SetKeyPadRight(GetRandomBool());
            SetMenuLeft(GetRandomBool());
            SetMenuRight(GetRandomBool());
            SetThumbLeft(GetRandomBool());
            SetThumbRight(GetRandomBool());
            SetShoulderLeft(GetRandomBool());
            SetShoulderRight(GetRandomBool());

            SetTriggerLeft(GetRandomFloat01());
            SetTriggerRight(GetRandomFloat01());
            SetJoystickLeftHorizontal(  GetRandomFloat11());
            SetJoystickLeftVertical(    GetRandomFloat11());
            SetJoystickRightHorizontal( GetRandomFloat11());
            SetJoystickRightVertical(   GetRandomFloat11()); 
        }

        public bool GetRandomBool() { return Random.value > 0.5f; }
        public float GetRandomFloat01() { return Random.value ; }
        public float GetRandomFloat11() { return (Random.value*2f)-1f; }
    }
}