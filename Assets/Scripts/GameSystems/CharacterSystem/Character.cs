using GameSystems.CharacterSystem.Attribute;
using UnityEngine;
using UnityEngine.AI;

namespace GameSystems.CharacterSystem
{
    public abstract class Character
    {
        protected CharacterAttr characterAttr;
        protected GameObject gameObject;
        protected AudioSource audioSource;
        protected NavMeshAgent navMeshAgent;
    }
}