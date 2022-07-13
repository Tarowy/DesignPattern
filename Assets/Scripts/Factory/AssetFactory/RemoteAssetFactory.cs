using UnityEngine;

namespace Factory.AssetFactory
{
    //从远程的AssetBundle加载资源
    public class RemoteAssetFactory: IAssetFactory
    {
        public GameObject LoadSolider(string name)
        {
            return null;
        }

        public GameObject LoadEnemy(string name)
        {
            return null;
        }

        public GameObject LoadWeapon(string name)
        {
            return null;
        }

        public Sprite LoadSprite(string name)
        {
            return null;
        }

        public GameObject LoadEffect(string name)
        {
            return null;
        }

        public AudioClip LoadAudioClip(string name)
        {
            return null;
        }
    }
}