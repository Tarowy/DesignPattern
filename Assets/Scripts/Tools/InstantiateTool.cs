using UnityEngine;

namespace Tools
{
    public class InstantiateTool: MonoBehaviour
    {
        /*
         * 由于这种特殊的开发方式，其他类不继承MonoBehaviour不能实例化对象，
         * 所以需要一个继承了MonoBehaviour的工具类来实例化
         */
        public static GameObject InstantiateObj(GameObject obj)
        {
            return Instantiate(obj);
        }
    }
}