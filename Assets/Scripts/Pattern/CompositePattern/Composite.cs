using System.Collections.Generic;
using UnityEngine;

namespace Pattern.CompositePattern
{
    /// <summary>
    /// 组合模式（Composite Pattern），又叫部分整体模式，是用于把一组相似的对象当作一个单一的对象。
    /// ，用来表示部分以及整体层次。
    /// 这种类型的设计模式属于结构型模组合模式依据树形结构来组合对象式，它创建了对象组的树形结构。
    /// 这种模式创建了一个包含自己对象组的类。该类提供了修改相同对象组的方式。
    /// 我们通过下面的实例来演示组合模式的用法。实例演示了一个组织中员工的层次结构。
    /// https://www.runoob.com/design-pattern/composite-pattern.html
    /// </summary>
    public class Composite : MonoBehaviour
    {
        private void Start()
        {
            /*
             * 组合模式和树的数据结构很像
             *                    "Root"
             *                /      |     \
             *            /          |        \
             * "GameObject" "GameObject (1)" "GameObject (2)"
             *                       |
             *                  "GameObject"
             */
            DpComponent root = new DpComposite("Root");

            var leaf1 = new DpLeaf("GameObject");
            var leaf2 = new DpLeaf("GameObject (2)");
            var dpComposite1 = new DpComposite("GameObject (1)");
            root.AddChild(leaf1);
            root.AddChild(dpComposite1);
            root.AddChild(leaf2);

            var dpComposite2 = new DpComposite("GameObject");
            dpComposite2.AddChild(dpComposite1);

            ReadComponent(root);
        }

        //深度优先遍历左右子节点
        private void ReadComponent(DpComponent component)
        {
            if (component == null || component.child.Count == 0)
            {
                return;
            }
            
            Debug.Log(component.name);

            foreach (var dpComponent in component.child)
            {
                ReadComponent(dpComponent);
            }
        }
    }

    public abstract class DpComponent
    {
        public string name;
        public List<DpComponent> child;

        protected DpComponent(string name)
        {
            child = new List<DpComponent>();
            this.name = name;
        }

        public abstract void AddChild(DpComponent childComponent);
        public abstract void RemoveChild(DpComponent childComponent);
        public abstract void Operation();
    }

    public class DpLeaf : DpComponent
    {
        public DpLeaf(string name) : base(name)
        {
        }

        public override void AddChild(DpComponent childComponent)
        {
            return;
        }

        public override void RemoveChild(DpComponent childComponent)
        {
            return;
        }

        public override void Operation()
        {
            return;
        }
    }

    public class DpComposite : DpComponent
    {
        public DpComposite(string name) : base(name)
        {
        }

        public override void AddChild(DpComponent childComponent)
        {
            child.Add(childComponent);
        }

        public override void RemoveChild(DpComponent childComponent)
        {
            child.Remove(childComponent);
        }

        public override void Operation()
        {
            return;
        }
    }
}