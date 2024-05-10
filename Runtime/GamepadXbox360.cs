using UnityEngine;
using System;
using UnityEngine.Events;
namespace Eloi.Input.Gamepad
{
    [System.Serializable]
public class GamepadXbox360
{
    public ButtonArrow m_pad;
    public ButtonArrow m_button;
    public BoolEvent m_shoulderLeft;
    public BoolEvent m_shoulderRight;
    public BoolEvent m_menuLeft;
    public BoolEvent m_menuRight;
    public BoolEvent m_thumbLeft;
    public BoolEvent m_thumbRight;
    public Percent01 m_triggerLeft;
    public Percent01 m_triggerRight;
    public Percent11 m_joystickLeftHorizontal;
    public Percent11 m_joystickLeftVertical;
    public Percent11 m_joystickRightHorizontal;
    public Percent11 m_joystickRightVertical;


        [System.Serializable]
        public class Percent01
        {
            public void SetValue(float percent) {
                if (percent != m_percentValue01) { 
                m_percentValue01 = Mathf.Clamp01(percent);

                    m_onValueChanged.Invoke(m_percentValue01);
                }
            }
        [Range(0f, 1f)]
        public float m_percentValue01;
        public UnityEvent<float> m_onValueChanged;
    }
    [System.Serializable]
    public class Percent11
    {
            public void SetValue(float percent) {
                if (percent != m_percentValue11) { 
                    m_percentValue11 = Mathf.Clamp(percent, -1f, 1f);
                    m_onValueChanged.Invoke(m_percentValue11);
                }
            }
        [Range(-1f, 1f)]
        public float m_percentValue11;
        public UnityEvent<float> m_onValueChanged;
    }


    [System.Serializable]
    public class ButtonArrow
    {
        public BoolEvent m_up;
        public BoolEvent m_right;
        public BoolEvent m_down;
        public BoolEvent m_left;
    }

    [System.Serializable]
    public class BoolEvent
    {
        public bool m_value;

        public void SetValue(bool value)
        {
            if (m_value != value)
            {
                m_value = value;
                if (value)
                    m_onPress.Invoke();
                else m_onRelease.Invoke();
                m_onIsPress.Invoke(value);
            }
        }
            public UnityEvent m_onPress;
            public UnityEvent m_onRelease;
            public UnityEvent<bool> m_onIsPress;
        }
}
}