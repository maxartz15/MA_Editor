//References:
//https://forum.unity.com/threads/helpattribute-allows-you-to-use-helpbox-in-the-unity-inspector-window.462768/#post-3014998

using UnityEngine;

namespace MA_Toolbox.MA_Editor
{
    public class HelpBoxAttribute : PropertyAttribute
    {
        public string m_text;
        public HelpBoxType m_helpBoxType;

        public HelpBoxAttribute(string text, HelpBoxType helpBoxType = HelpBoxType.None)
        {
            this.m_text = text;
            this.m_helpBoxType = helpBoxType;
        }
    }
}