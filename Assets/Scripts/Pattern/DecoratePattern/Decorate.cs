using System;
using UnityEngine;

namespace Pattern.DecoratePattern
{
    /// <summary>
    /// 装饰器模式（Decorator Pattern）允许向一个现有的对象添加新的功能，同时又不改变其结构。
    /// 这种类型的设计模式属于结构型模式，它是作为现有的类的一个包装。
    /// 这种模式创建了一个装饰类，用来包装原有的类，并在保持类方法签名完整性的前提下，提供了额外的功能。
    /// https://www.runoob.com/design-pattern/decorator-pattern.html
    /// </summary>
    public class Decorate: MonoBehaviour
    {
        private void Start()
        {
            //类似于递归，每个coffee对象里都包含了上一个coffee的对象
            ICoffee coffee = new Espresso();
            coffee = new Mocha(coffee);
            coffee = new Mocha(coffee);
            coffee = new Whip(coffee);
            
            Debug.Log(coffee.Cost());
        }
    }

    public interface ICoffee
    {
        float Cost();
    }

    //浓咖啡
    public class Espresso : ICoffee
    {
        public float Cost()
        {
            return 2.5f;
        }
    }

    //无咖啡
    public class Decaf : ICoffee
    {
        public float Cost()
        {
            return 2f;
        }
    }
    
    //装饰器
    public class Dress: ICoffee
    {
        private readonly ICoffee _coffee;

        protected Dress(ICoffee coffee)
        {
            _coffee = coffee;
        }
        
        public virtual float Cost()
        {
            return _coffee.Cost();
        }
    }

    //摩卡
    public class Mocha : Dress
    {
        public Mocha(ICoffee coffee) : base(coffee)
        {
        }

        public override float Cost()
        {
            return base.Cost() + 0.1f;
        }
    }

    //牛奶
    public class Whip : Dress
    {
        public Whip(ICoffee coffee) : base(coffee)
        {
        }

        public override float Cost()
        {
            return base.Cost() + 0.5f;
        }
    }
}