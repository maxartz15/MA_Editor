using UnityEngine;
using UnityEditor;

namespace MA_Toolbox.MA_Editor
{
    public static class EditorCore
    {
        public static Color GetButtonColor(ButtonColor a_buttonColor)
        {
            Color color = GUI.color;

            switch (a_buttonColor)
            {
                case ButtonColor.Default:
                    color = GUI.color;
                    break;
                case ButtonColor.Red:
                    color = Color.red;
                    break;
                case ButtonColor.Green:
                    color = Color.green;
                    break;
                case ButtonColor.Blue:
                    color = Color.blue;
                    break;
                default:
                    color = GUI.color;
                    break;
            }

            return color;
        }

        public static MessageType GetMessageType(HelpBoxType a_helpBoxType)
        {
            MessageType messageType = MessageType.None;

            switch (a_helpBoxType)
            {
                case HelpBoxType.Info:
                    messageType = MessageType.Info;
                    break;
                case HelpBoxType.Warning:
                    messageType = MessageType.Warning;
                    break;
                case HelpBoxType.Error:
                    messageType = MessageType.Error;
                    break;
                default:
                    messageType = MessageType.None;
                    break;
            }

            return messageType;
        }
    }
}