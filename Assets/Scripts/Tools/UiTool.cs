using UnityEngine;

namespace Tools
{
    public static class UiTool
    {
        public static GameObject GetCanvas(string name = "Canvas")
        {
            return GameObject.Find(name);
        }

        public static T Find<T>(GameObject parent, string childName)
        {
            return UnityTools.FindChild(parent,childName).GetComponent<T>();
        }
    }
}