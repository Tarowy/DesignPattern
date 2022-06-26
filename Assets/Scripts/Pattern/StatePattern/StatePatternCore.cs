using System;
using Pattern.StatePattern;
using UnityEngine;

namespace StatePattern
{
    /// <summary>
    /// 在状态模式（State Pattern）中，类的行为是基于它的状态改变的。这种类型的设计模式属于行为型模式
    /// 在状态模式中，我们创建表示各种状态的对象和一个行为随着状态对象改变而改变的 context 对象
    /// https://www.runoob.com/design-pattern/state-pattern.html
    /// </summary>
    public class StatePatternCore: MonoBehaviour
    {
        private void Start()
        {
            var context = new Context();
            context.Handle(5);
            context.Handle(20);
            context.Handle(10);
            context.Handle(5);
        }
    }
}
