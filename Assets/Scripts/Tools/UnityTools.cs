using UnityEngine;

namespace Tools
{
    public class UnityTools
    {
        public static GameObject FindChild(GameObject parent, string name)
        {
            // Debug.Log("Parent:" + parent);
            var transforms = parent.GetComponentsInChildren<Transform>();

            foreach (var transform in transforms)
            {
                if (transform.name.Equals(name))
                {
                    return transform.gameObject;
                }
            }

            return null;
        }

        public static void Attach(GameObject parent, GameObject child)
        {
            child.transform.parent = parent.transform;
            child.transform.localPosition = Vector3.zero;
            child.transform.localRotation = Quaternion.identity;
            child.transform.localScale = Vector3.one;
        }
    }
}