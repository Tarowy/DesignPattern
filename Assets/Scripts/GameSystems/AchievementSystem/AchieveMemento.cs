using UnityEngine;

namespace GameSystems.AchievementSystem
{
    /// <summary>
    /// 备忘录模式（Memento Pattern）保存一个对象的某个状态，以便在适当的时候恢复对象。
    /// 备忘录模式属于行为型模式。
    /// https://www.runoob.com/design-pattern/memento-pattern.html
    /// </summary>
    public class AchieveMemento
    {
        public int EnemyDeadCount { set; get; }
        public int SoliderDeadCount { set; get; }
        public int MaxStageLevel { set; get; }

        public void SaveData()
        {
            PlayerPrefs.SetInt("EnemyDeadCount", EnemyDeadCount);
            PlayerPrefs.SetInt("SoliderDeadCount", SoliderDeadCount);
            PlayerPrefs.SetInt("MaxStageLevel", MaxStageLevel);
        }

        public void LoadData()
        {
            EnemyDeadCount = PlayerPrefs.GetInt("EnemyDeadCount", 0);
            SoliderDeadCount = PlayerPrefs.GetInt("SoliderDeadCount", 0);
            MaxStageLevel = PlayerPrefs.GetInt("MaxStageLevel", 0);
        }
    }
}