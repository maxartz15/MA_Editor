#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace MA_Toolbox.MA_Editor
{
    public static class GizmosUtils
    {
        // References: 
        // https://forum.unity.com/threads/text-gizmo.27902/
        public static void DrawString(string text, Vector3 worldPos, Color? textColor = null, Color? backColor = null, GUIStyle editorStyle = null)
        {
            Handles.BeginGUI();

            Color restoreTextColor = GUI.color;
            Color restoreBackColor = GUI.backgroundColor;
        
            GUI.color = textColor ?? Color.white;
            GUI.backgroundColor = backColor ?? Color.black;
            editorStyle = editorStyle ?? EditorStyles.helpBox;
        
            SceneView view = SceneView.currentDrawingSceneView;

            if (view != null && view.camera != null)
            {
                Vector3 screenPos = view.camera.WorldToScreenPoint(worldPos);

                if (screenPos.y < 0 || screenPos.y > Screen.height || screenPos.x < 0 || screenPos.x > Screen.width || screenPos.z < 0)
                {
                    GUI.color = restoreTextColor;
                    Handles.EndGUI();
                    return;
                }

                Vector2 size = GUI.skin.box.CalcSize(new GUIContent(text));            
                Rect rect = new Rect(screenPos.x - (size.x / 2), - screenPos.y + view.position.height - (size.y * 1.5f), size.x, size.y);

                GUI.Box(rect, text, editorStyle);            
                GUI.color = restoreTextColor;
                GUI.backgroundColor = restoreBackColor;
            }

            Handles.EndGUI();
        }
    }
}
#endif