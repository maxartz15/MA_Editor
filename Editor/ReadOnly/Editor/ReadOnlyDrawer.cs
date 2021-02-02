using System;
using UnityEngine;
using UnityEditor;

namespace MA_Toolbox.MA_Editor
{
    [CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
    public class ReadOnlyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect rect, SerializedProperty property, GUIContent label)
        {
            var readOnlyAttribute = attribute as ReadOnlyAttribute;
            bool isDisabled = true;

            if (!String.IsNullOrEmpty(readOnlyAttribute.m_onlyIfProperty))
            {
                if (!property.serializedObject.FindProperty(readOnlyAttribute.m_onlyIfProperty).boolValue)
                {
                    isDisabled = false;
                }
            }

            EditorGUI.BeginProperty(rect, label, property);

            using (new EditorGUI.DisabledScope(disabled: isDisabled))
            {
                EditorGUI.PropertyField(rect, property, label, true);
            }

            EditorGUI.EndProperty();
        }
    }
}