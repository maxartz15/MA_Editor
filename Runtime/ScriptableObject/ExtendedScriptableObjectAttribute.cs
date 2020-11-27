using System;
using UnityEngine;

namespace MA_Toolbox.MA_Editor
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class ExtendedScriptableObjectAttribute : PropertyAttribute {}
}