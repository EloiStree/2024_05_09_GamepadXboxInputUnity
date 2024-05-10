using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi.Input.Gamepad {
    //1888899990
    //1600450000
    public class GamepadXboxToIntegerMono : MonoBehaviour
    {

        public int m_gamepadOffset = 1600450000;
        public GamepadXbox360HolderMono m_toListen;

        public UnityEvent<int> m_onIntegerEvent;
        public int m_lastPushed;

        public ButtonToInteger m_buttonLeft;
        public ButtonToInteger m_buttonRight;
        public ButtonToInteger m_buttonUp;
        public ButtonToInteger m_buttonDown;

        public ButtonToInteger m_padLeft;
        public ButtonToInteger m_padRight;
        public ButtonToInteger m_padUp;
        public ButtonToInteger m_padDown;

        public ButtonToInteger m_thumbLeft;
        public ButtonToInteger m_thumbRight;
        public ButtonToInteger m_shoulderLeft;
        public ButtonToInteger m_shoulderRight;
        public ButtonToInteger m_menuLeft;
        public ButtonToInteger m_menuRight;

        public AxisRelativeOffset m_axisRelativeOffset;
        [System.Serializable]
        public class AxisRelativeOffset
        {
            public int m_joystickLeftHorizontal = 3100;
            public int m_joystickLeftVertical = 3200;
            public int m_joystickRightHorizontal= 3300;
            public int m_joystickRightVertical = 3400;
            public int m_triggerLeft=2020;
            public int m_triggerRight=2040;
        }

        public AxisFloatToInteger m_joystickLeftHorizontal  ;
        public AxisFloatToInteger m_joystickLeftVertical    ;
        public AxisFloatToInteger m_joystickRightHorizontal ;
        public AxisFloatToInteger m_joystickRightVertical       ;
        public AxisFloatToInteger m_triggerLeft             ;
        public AxisFloatToInteger m_triggerRight            ;

        public void Reset()
        {
            m_buttonDown = new ButtonToInteger(m_gamepadOffset, 1001, 2001);
            m_buttonRight = new ButtonToInteger(m_gamepadOffset, 1002, 2002);
            m_buttonLeft = new ButtonToInteger(m_gamepadOffset, 1003, 2003);
            m_buttonUp = new ButtonToInteger(m_gamepadOffset, 1004, 2004);
            m_padDown       = new ButtonToInteger(m_gamepadOffset, 1005, 2005);
            m_padRight       = new ButtonToInteger(m_gamepadOffset, 1006, 2005);
            m_padLeft       = new ButtonToInteger(m_gamepadOffset, 1007, 2005);
            m_padUp         = new ButtonToInteger(m_gamepadOffset, 1008, 2005);
            m_thumbLeft     = new ButtonToInteger(m_gamepadOffset, 1009, 2009);
            m_thumbRight    = new ButtonToInteger(m_gamepadOffset, 1010, 2010);
            m_shoulderLeft   = new ButtonToInteger(m_gamepadOffset, 1011, 2011);
            m_shoulderRight   = new ButtonToInteger(m_gamepadOffset, 1012, 2012);
            m_menuLeft      = new ButtonToInteger(m_gamepadOffset, 1013, 2013);
            m_menuRight     = new ButtonToInteger(m_gamepadOffset, 1014, 2014);


            SetAxis(m_joystickLeftHorizontal, m_axisRelativeOffset.m_joystickLeftHorizontal, true);
            SetAxis(m_joystickLeftVertical, m_axisRelativeOffset.m_joystickLeftVertical, true);
            SetAxis(m_joystickRightHorizontal, m_axisRelativeOffset.m_joystickRightHorizontal, true);
            SetAxis(m_joystickRightVertical, m_axisRelativeOffset.m_joystickRightVertical, true);
            SetAxis(m_triggerLeft, m_axisRelativeOffset.m_triggerLeft, false);
            SetAxis(m_triggerRight, m_axisRelativeOffset.m_triggerRight, false);


        }



        public void PushOutInteger(int integer) {
            m_lastPushed = integer;
            m_onIntegerEvent.Invoke(integer);
        }
        public void Start()
        {
            GamepadXbox360 gamepad=   m_toListen.GetGamepadXbox360();
            AddListener(gamepad.m_button.m_down, m_buttonDown);
            AddListener(gamepad.m_button.m_up, m_buttonUp);
            AddListener(gamepad.m_button.m_left, m_buttonLeft);
            AddListener(gamepad.m_button.m_right, m_buttonRight);
            AddListener(gamepad.m_pad.m_down, m_padDown       );
            AddListener(gamepad.m_pad.m_up, m_padRight      );
            AddListener(gamepad.m_pad.m_left, m_padLeft       );
            AddListener(gamepad.m_pad.m_right, m_padUp         );
            AddListener(gamepad.m_thumbLeft, m_thumbLeft     );
            AddListener(gamepad.m_thumbRight, m_thumbRight    );
            AddListener(gamepad.m_shoulderLeft, m_shoulderLeft  );
            AddListener(gamepad.m_shoulderRight, m_shoulderRight );
            AddListener(gamepad.m_menuLeft, m_menuLeft      );
            AddListener(gamepad.m_menuRight, m_menuRight);


            SetAxis(m_joystickLeftHorizontal, m_axisRelativeOffset.m_joystickLeftHorizontal, true);
            SetAxis(m_joystickLeftVertical, m_axisRelativeOffset.m_joystickLeftVertical, true);
            SetAxis(m_joystickRightHorizontal, m_axisRelativeOffset.m_joystickRightHorizontal, true);
            SetAxis(m_joystickRightVertical, m_axisRelativeOffset.m_joystickRightVertical, true);
            SetAxis(m_triggerLeft, m_axisRelativeOffset.m_triggerLeft, false);
            SetAxis(m_triggerRight, m_axisRelativeOffset.m_triggerRight, false);

            AddListener(gamepad.m_joystickLeftHorizontal, m_joystickLeftHorizontal);
            AddListener(gamepad.m_joystickLeftVertical, m_joystickLeftVertical);
            AddListener(gamepad.m_joystickRightHorizontal, m_joystickRightHorizontal);
            AddListener(gamepad.m_joystickRightVertical, m_joystickRightVertical);
            AddListener(gamepad.m_triggerLeft, m_triggerLeft);
            AddListener(gamepad.m_triggerRight, m_triggerRight);

        }

        private void SetAxis(AxisFloatToInteger axisToInteger, int relativeValue, bool isAxis)
        {
                if (isAxis)
                    axisToInteger.SetJoystickAxis(relativeValue);
                else axisToInteger.SetAsTrigger(relativeValue);

                axisToInteger.SetOffset(m_gamepadOffset);

        }

        public void AddListener(GamepadXbox360.BoolEvent eventUnity, ButtonToInteger integer)
        {
            integer.m_offset = m_gamepadOffset;
            eventUnity.m_onIsPress.AddListener((value) => PushOutInteger(integer.GetInteger(value)));
        }
        public void AddListener(GamepadXbox360.Percent01 eventUnity, AxisFloatToInteger integer)
        {
            integer.SetOffset(m_gamepadOffset);
            eventUnity.m_onValueChanged.AddListener((value) => {
                integer.GetInteger(out bool changed, out int valueToPush, value);
                if (changed)
                    PushOutInteger(valueToPush);
            });
        }
        public void AddListener(GamepadXbox360.Percent11 eventUnity, AxisFloatToInteger integer)
        {
            integer.SetOffset(m_gamepadOffset);
            eventUnity.m_onValueChanged.AddListener((value) => {
                integer.GetInteger(out bool changed, out int valueToPush, value);
                if (changed)
                    PushOutInteger(valueToPush);
            });
        }



        [System.Serializable]
        public class ButtonToInteger
        {

            public ButtonToInteger(int offset, int buttonLocalValuePress = 1000, int buttonLocalValueRelease = 2000)
            {
                m_offset = offset;
                m_integerPress = buttonLocalValuePress;
                m_integerRelease = buttonLocalValueRelease;
            }
            public ButtonToInteger()
            {
                m_offset = 0;
                m_integerPress = 1000;
                m_integerRelease = 2000;
            }
            [HideInInspector]
            public int m_offset = 0;
            public int m_integerPress = 1000;
            public int m_integerRelease = 2000;
            public int GetInteger(bool isPress) { return isPress ? m_offset + m_integerPress : m_offset + m_integerRelease; }
        }


        [System.Serializable]
        public class AxisFloatToInteger
        {
            public int m_notFoundValue;
            public RangeToInteger[] m_rangeToInteger;
            [System.Serializable]
            public class RangeToInteger {

                public int m_offset;
                public int m_relativeValue;
                public float m_min=-1;
                public float m_max=1;

                public RangeToInteger(int integerValue, float min, float max)
                {
                    m_relativeValue = integerValue;
                    m_min = min;
                    m_max = max;
                }
                public void SetOffset(int offset) {
                    m_offset = offset;
                }
            }


            public void SetAsTrigger(int relativeValue)
            {

                m_rangeToInteger = new RangeToInteger[] {

                    new RangeToInteger(relativeValue+0, 0f,0.01f),
                    new RangeToInteger(relativeValue+1, 0.01f,0.15f),
                    new RangeToInteger(relativeValue+2, 0.15f,0.25f),
                    new RangeToInteger(relativeValue+3, 0.25f,0.35f),
                    new RangeToInteger(relativeValue+4, 0.35f,0.45f),
                    new RangeToInteger(relativeValue+5, 0.45f,0.55f),
                    new RangeToInteger(relativeValue+6, 0.55f,0.65f),
                    new RangeToInteger(relativeValue+7, 0.65f,0.75f),
                    new RangeToInteger(relativeValue+8, 0.75f,0.85f),
                    new RangeToInteger(relativeValue+9, 0.95f,0.99f),
                    new RangeToInteger(relativeValue+10, 0.99f,1f),
                };
            }
            public void SetJoystickAxis(int relativeValue)
            {
                m_rangeToInteger = new RangeToInteger[] {

                    new RangeToInteger(relativeValue+0, -1f,-0.9f),
                    new RangeToInteger(relativeValue+1, -0.90f,-0.75f),
                    new RangeToInteger(relativeValue+2, -0.75f,-0.5f),
                    new RangeToInteger(relativeValue+3, -0.5f,-0.25f),
                    new RangeToInteger(relativeValue+4, -0.25f,-0.1f),
                    new RangeToInteger(relativeValue+5, -0.1f,0.1f),
                    new RangeToInteger(relativeValue+6, 0.1f,0.25f),
                    new RangeToInteger(relativeValue+7, 0.25f,0.5f),
                    new RangeToInteger(relativeValue+8, 0.5f,0.75f),
                    new RangeToInteger(relativeValue+9, 0.75f,0.90f),
                    new RangeToInteger(relativeValue+10, 0.9f,1f)
                };
            }

            public void SetOffset(int offset) {

                foreach (var range in m_rangeToInteger)
                {
                    range.SetOffset(offset);
                }
            }

            public float m_previousValueAxisValueChanged;
            public float m_previousValueAxisValued;
            public void GetInteger(out bool changeFound, out int integerToPush, float axisValue)
            {
                m_previousValueAxisValued = axisValue;
                foreach (var item in m_rangeToInteger)
                {
                    if ((axisValue >= item.m_min && axisValue <= item.m_max) && !(m_previousValueAxisValueChanged >= item.m_min && m_previousValueAxisValueChanged <= item.m_max)) {
                        changeFound = true;
                        m_previousValueAxisValueChanged = axisValue;
                        integerToPush=item.m_offset+item.m_relativeValue;
                        return;
                    }
                }
                changeFound = false;
                integerToPush = 00;

            }
        }





    }
}
