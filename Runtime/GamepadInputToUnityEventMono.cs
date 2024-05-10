using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Eloi.Input.Gamepad;
using UnityEngine.InputSystem;
using System;
using UnityEngine.Events;
namespace Eloi.Input.Gamepad
{
    public class GamepadInputToUnityEventMono : GamepadXbox360HolderMono
    {

    public GamepadInput m_gamepad;

   
    void OnEnable()
    {
        m_gamepad = new GamepadInput();
        m_gamepad.Enable();
        m_gamepad.GamepadXbox360Type.Enable();
        InputAction a = m_gamepad.GamepadXbox360Type.ButtonDown;
        SetListener(m_gamepad.GamepadXbox360Type.ButtonDown, m_gamepadEvent.m_button.m_down);
        SetListener(m_gamepad.GamepadXbox360Type.ButtonUp, m_gamepadEvent. m_button.m_up);
        SetListener(m_gamepad.GamepadXbox360Type.ButtonLeft, m_gamepadEvent. m_button.m_left);
        SetListener(m_gamepad.GamepadXbox360Type.ButtonRight, m_gamepadEvent. m_button.m_right);
        SetListener(m_gamepad.GamepadXbox360Type.PadDown, m_gamepadEvent. m_pad.m_down);
        SetListener(m_gamepad.GamepadXbox360Type.PadUp, m_gamepadEvent.m_pad.m_up);
        SetListener(m_gamepad.GamepadXbox360Type.PadLeft, m_gamepadEvent. m_pad.m_left);
        SetListener(m_gamepad.GamepadXbox360Type.PadRight, m_gamepadEvent. m_pad.m_right);
        SetListener(m_gamepad.GamepadXbox360Type.ShoulderLeft, m_gamepadEvent. m_shoulderLeft);
        SetListener(m_gamepad.GamepadXbox360Type.ShoulderRIght, m_gamepadEvent. m_shoulderRight);
        SetListener(m_gamepad.GamepadXbox360Type.MenuLeft, m_gamepadEvent. m_menuLeft);
        SetListener(m_gamepad.GamepadXbox360Type.MenuRight, m_gamepadEvent. m_menuRight);
        SetListener(m_gamepad.GamepadXbox360Type.ThumbJoystickLeft, m_gamepadEvent.m_thumbLeft);
        SetListener(m_gamepad.GamepadXbox360Type.ThumbJoystickRight, m_gamepadEvent. m_thumbRight);
        SetListener(m_gamepad.GamepadXbox360Type.TriggerLeft, m_gamepadEvent. m_triggerLeft);
        SetListener(m_gamepad.GamepadXbox360Type.TriggerRight, m_gamepadEvent. m_triggerRight);
        SetListener(m_gamepad.GamepadXbox360Type.JoystickLeftHorizontal, m_gamepadEvent. m_joystickLeftHorizontal);
        SetListener(m_gamepad.GamepadXbox360Type.JoystickLeftVertical, m_gamepadEvent. m_joystickLeftVertical);
        SetListener(m_gamepad.GamepadXbox360Type.JoystickRightHorizontal, m_gamepadEvent. m_joystickRightHorizontal);
        SetListener(m_gamepad.GamepadXbox360Type.JoystickRightVertical, m_gamepadEvent. m_joystickRightVertical);
    }

    private void SetListener(InputAction action, GamepadXbox360.BoolEvent button)
    {
        action.performed += (i) => { button.SetValue(i.ReadValueAsButton()); };
        action.canceled += (i) => { button.SetValue(false); };
    }
    private void SetListener(InputAction action, GamepadXbox360.Percent01 percent)
    {
        action.performed += (i) => { percent.SetValue(i.ReadValue<float>()); };
        action.canceled += (i) => { percent.SetValue(0); };
    }
    private void SetListener(InputAction action, GamepadXbox360.Percent11 percent)
    {
        action.performed += (i) => { percent.SetValue(i.ReadValue<float>()); };
        action.canceled += (i) => { percent.SetValue(0); };
    }

    private void A(InputAction.CallbackContext obj)
    {
        throw new NotImplementedException();
    }

    void OnDisable()
    {
        m_gamepad.GamepadXbox360Type.Disable();
        m_gamepad.Disable();
        m_gamepad.Disable();
    }
}
}