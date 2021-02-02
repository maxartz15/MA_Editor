// References:
// https://bitbucket.org/gaello/readonly-attribute/src/master/

using System;
using UnityEngine;

namespace MA_Toolbox.MA_Editor
{
    public class ReadOnlyAttribute : PropertyAttribute
    {
        public string m_onlyIfProperty = null;
    }
}