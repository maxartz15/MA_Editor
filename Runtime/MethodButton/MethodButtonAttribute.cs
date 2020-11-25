// References:
// https://pastebin.com/rn3Z2zf9

using UnityEngine;

namespace MA_Toolbox.MA_Editor
{
    [System.AttributeUsage(System.AttributeTargets.Method)]
    public class MethodButtonAttribute : PropertyAttribute
    {
        public string m_buttonName = null;
        public ButtonColor m_buttonColor = 0;
        public string m_helpBoxText = null;
        public HelpBoxType m_helpBoxType = HelpBoxType.None;
        public string m_conformationText = null;
    }
}