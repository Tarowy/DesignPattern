using System.Collections.Generic;
using UnityEngine;

namespace Factory.AssetFactory
{
    /// <summary>
    /// 在代理模式（Proxy Pattern）中，一个类代表另一个类的功能。
    /// 这种类型的设计模式属于结构型模式。
    /// 在代理模式中，我们创建具有现有对象的对象，以便向外界提供功能接口。
    /// https://www.runoob.com/design-pattern/proxy-pattern.html
    /// </summary>
    public class AssetProxyFactory: IAssetFactory
    {
        private readonly ResourceAssetFactory _assetFactory = new();
        
        //将对象保存在字典中，不需要重复使用工厂来创建对象
        private readonly Dictionary<string, GameObject> _solider = new();
        private readonly Dictionary<string, GameObject> _enemies = new();
        private readonly Dictionary<string, GameObject> _weapons = new();
        private readonly Dictionary<string, GameObject> _effects = new();
        private readonly Dictionary<string, Sprite> _sprites = new();
        private readonly Dictionary<string, AudioClip> _clips = new();

        public GameObject LoadSolider(string name)
        {
            if (_solider.ContainsKey(name))
            {
                return _solider[name];
            }

            _solider.Add(name, _assetFactory.LoadSolider(name));
            return _solider[name];
        }

        public GameObject LoadEnemy(string name)
        {
            if (_enemies.ContainsKey(name))
            {
                return _enemies[name];
            }

            _enemies.Add(name, _assetFactory.LoadEnemy(name));
            return _enemies[name];
        }

        public GameObject LoadWeapon(string name)
        {
            if (_weapons.ContainsKey(name))
            {
                return _weapons[name];
            }
            
            _weapons.Add(name,_assetFactory.LoadWeapon(name));
            return _weapons[name];
        }

        public Sprite LoadSprite(string name)
        {
            if (_sprites.ContainsKey(name))
            {
                return _sprites[name];
            }
            
            _sprites.Add(name,_assetFactory.LoadSprite(name));
            return _sprites[name];
        }

        public GameObject LoadEffect(string name)
        {
            if (_effects.ContainsKey(name))
            {
                return _effects[name];
            }
            
            _effects.Add(name,_assetFactory.LoadEffect(name));
            return _effects[name];
        }

        public AudioClip LoadAudioClip(string name)
        {
            if (_clips.ContainsKey(name))
            {
                return _clips[name];
            }

            _clips.Add(name, _assetFactory.LoadAudioClip(name));
            return _clips[name];
        }
    }
}