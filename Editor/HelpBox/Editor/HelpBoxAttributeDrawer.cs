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
            
            return Mathf.Max(40f, helpBoxStyle.CalcHeight(new GUIContent(helpBoxAttribute.m_text), EditorGUIUtility.currentViewWidth) + 4);
        }

        public override void OnGUI(Rect a_position)
        {
            var helpBoxAttribute = attribute as HelpBoxAttribute;
            if (helpBoxAttribute == null)
                return;
            
            EditorGUI.HelpBox(a_position, helpBoxAttribute.m_text, EditorCore.GetMessageType(helpBoxAttribute.m_helpBoxType));
        }
    }
}