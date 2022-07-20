using GameSystems.CharacterSystem.Attribute;
using GameSystems.CharacterSystem.AttrStrategy;

namespace GameSystems.CharacterSystem.Solider
{
    /// <summary>
    /// 适配器模式（Adapter Pattern）是作为两个不兼容的接口之间的桥梁。
    /// 这种类型的设计模式属于结构型模式，它结合了两个独立接口的功能。
    /// 这种模式涉及到一个单一的类，该类负责加入独立的或不兼容的接口功能。
    /// 举个真实的例子，读卡器是作为内存卡和笔记本之间的适配器。
    /// 您将内存卡插入读卡器，再将读卡器插入笔记本，这样就可以通过笔记本来读取内存卡。
    /// https://www.runoob.com/design-pattern/adapter-pattern.html
    /// </summary>
    public class Captive : Solider
    {
        private Enemy.Enemy _enemy;

        public Captive(Enemy.Enemy enemy)
        {
            //获取Enemy的属性转换为俘兵自己的
            _enemy = enemy;
            
            this.characterAttr =
                new SoliderAttr(_enemy.CharacterAttr.AttrStrategy, 
                    1, _enemy.CharacterAttr.CharacterBaseAttr);

            this.CharacterObject = _enemy.CharacterObject;
            this.weapon = _enemy.Weapon;
        }

        public override void PlayEffect()
        {
            _enemy.PlayEffect();
        }

        public override void PlaySound()
        {
        }
    }
}