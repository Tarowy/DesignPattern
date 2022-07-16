using UnityEngine;

namespace Factory.AssetFactory
{
    //从本地直接Resource.Load加载资源
    public class ResourceAssetFactory : IAssetFactory
    {
        private const string SoliderPath = "Characters/Soldier/";
        private const string EnemyPath = "Characters/Enemy/";
        private const string EffectPath = "Effects/";
        private const string WeaponPath = "Weapons/";
        private const string AudioPath = "Audios/";
        private const string SpritePath = "Sprites/";

        public GameObject LoadSolider(string name)
        {
            return InstantiateGameObject(SoliderPath + name);
        }

        public GameObject LoadEnemy(string name)
        {
            return InstantiateGameObject(EnemyPath + name);
        }

        public GameObject LoadWeapon(string name)
        {
            return InstantiateGameObject(WeaponPath + name);
        }

        public Sprite LoadSprite(string name)
        {
            //非GameObject资源的加载方式
            return Resources.Load(SpritePath + name, typeof(Sprite)) as Sprite;
        }

        public GameObject LoadEffect(string name)
        {
            return InstantiateGameObject(EffectPath + name);
        }

        public AudioClip LoadAudioClip(string name)
        {
            return Resources.Load(AudioPath + name) as AudioClip;
        }

        private GameObject InstantiateGameObject(string path)
        {
            var gameObject = Resources.Load<GameObject>(path);

            if (gameObject is not null) return gameObject;
            Debug.LogError($"路径为{path}的资源无法加载");
            return null;
        }

        private Object InstantiateObject(string path)
        {
            var obj = Resources.Load<Object>(path);

            if (obj is not null) return obj;
            Debug.LogError($"路径为{path}的资源无法加载");
            return null;
        }
    }
}