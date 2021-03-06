namespace GameSystems.CharacterSystem.AttrStrategy
{
    /// <summary>
    /// 在策略模式（Strategy Pattern）中，一个类的行为或其算法可以在运行时更改。这种类型的设计模式属于行为型模式。
    /// 在策略模式中，我们创建表示各种策略的对象和一个行为随着策略对象改变而改变的 context 对象。
    /// 策略对象改变 context 对象的执行算法。
    /// https://www.runoob.com/design-pattern/strategy-pattern.html
    /// </summary>
    public interface IAttrStrategy
    {
        int GetExtraHp(int level); //额外生命
        int GetDamageReduceValue(int level); //伤害减免值
        int GetCriticalDamage(float criticalRate); //暴击伤害
    }
}