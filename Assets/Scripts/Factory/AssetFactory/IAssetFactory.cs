using UnityEngine;

namespace Factory.AssetFactory
{
    public interface IAssetFactory
    {
        GameObject LoadSolider(string name);
        GameObject LoadEnemy(string name);
        GameObject LoadWeapon(string name);
        Sprite LoadSprite(string name);
        GameObject LoadEffect(string name);
        AudioClip LoadAudioClip(string name);
    }
}