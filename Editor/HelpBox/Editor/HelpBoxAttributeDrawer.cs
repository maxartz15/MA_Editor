using UnityEngine;
using UnityEditor;

namespace MA_Toolbox.MA_Editor
{
    [CustomPropertyDrawer(typeof(HelpBoxAttribute))]
    public class HelpBoxAttributeDrawer : DecoratorDrawer
    {
        public override float GetHeight()
        {
            var helpBoxAttribute = attribute as HelpBoxAttribute;
            if (helpBoxAttribute == null)
                return base.GetHeight();

            var helpBoxStyle = (GUI.skin != null) ? GUI.skin.GetStyle("helpbox") : null;

            if (helpBoxStyle == null) 
                return base.GetHeight();
            
            return Mathf.Max(40f, helpBoxStyle.CalcHeight(new GUIContent(helpBoxAttribute.text), EditorGUIUtility.currentViewWidth) + 4);
        }

        public override void OnGUI(Rect position)
        {
            var helpBoxAttribute = attribute as HelpBoxAttribute;
            if (helpBoxAttribute == null)
                return;
            
            EditorGUI.HelpBox(position, helpBoxAttribute.text, GetMessageType(helpBoxAttribute.messageType));
        }

        private MessageType GetMessageType(HelpBoxMessageType helpBoxMessageType)
        {
            MessageType messageType = MessageType.None;

            switch (helpBoxMessageType)
            {
                case HelpBoxMessageType.Info: 
                    messageType = MessageType.Info;
                    break;
                case HelpBoxMessageType.Warning:
                    messageType = MessageType.Warning;
                    break;
                case HelpBoxMessageType.Error:
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