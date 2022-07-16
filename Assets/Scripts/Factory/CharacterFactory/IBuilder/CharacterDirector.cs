using GameSystems.CharacterSystem;

namespace Factory.CharacterFactory.IBuilder
{
    public class CharacterDirector
    {
        /// <summary>
        /// 建造者模式（Builder Pattern）使用多个简单的对象一步一步构建成一个复杂的对象。
        /// 这种类型的设计模式属于创建型模式，它提供了一种创建对象的最佳方式。
        /// 一个 Builder 类会一步一步构造最终的对象。该 Builder 类是独立于其他对象的。
        /// https://www.runoob.com/design-pattern/builder-pattern.html
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static Character Construct(CharacterBuilder builder)
        {
            builder.AddCharacterAttr();
            builder.AddGameObject();
            builder.AddWeapon();
            builder.AddToCharacterSystem();
            
            return builder.GetResult();
        }
    }
}