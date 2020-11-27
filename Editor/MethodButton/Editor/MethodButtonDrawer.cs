using System;
using System.Linq;
using UnityEngine;
using UnityEditor;
using System.Reflection;

namespace MA_Toolbox.MA_Editor
{
    [CustomEditor(typeof(UnityEngine.Object), true)]
    public class MethodButtonDrawer : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var mono = target as UnityEngine.Object;

            var methods = mono.GetType()
                .GetMembers(BindingFlags.Instance | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(o => Attribute.IsDefined(o, typeof(MethodButtonAttribute)));


            foreach (var memberInfo in methods)
            {
                var attr = Attribute.GetCustomAttribute(memberInfo, typeof(MethodButtonAttribute)) as MethodButtonAttribute;

                // HelpBox.
                if (!String.IsNullOrEmpty(attr.m_helpBoxText))
                {
                    EditorGUILayout.HelpBox(attr.m_helpBoxText, EditorCore.GetMessageType(attr.m_helpBoxType));
                }

                // Button.
                string buttonName = attr.m_buttonName;
                if (String.IsNullOrEmpty(buttonName))
                {
                    buttonName = memberInfo.Name;
                }

                Color col = GUI.color;
                GUI.color = EditorCore.GetButtonColor(attr.m_buttonColor);

                if (GUILayout.Button(buttonName))
                {
                    var method = memberInfo as MethodInfo;

                    // Button conformation.
                    if (!String.IsNullOrEmpty(attr.m_conformationText))
                    {
                        if(EditorUtility.DisplayDialog(buttonName, attr.m_conformationText, "Ok", "Cancel"))
                        {
                            method.Invoke(mono, null);
                        }
                    }
                    else
                    {
                        method.Invoke(mono, null);
                    }
                }

                GUI.color = col;
            }
        }
    }
}