using System;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Monsters;
using Assets.Scripts.Actors.Stats;
using Assets.Scripts.Areas;
using Assets.Scripts.Directors;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] BasicMovement movement;
    [SerializeField] MonsterAttack attack;
    [SerializeField] ConeArea attackArea;
    [SerializeField] ActorStats baseStats;
    [SerializeField] ActorView view;
    [SerializeField] Health health;
    Action<Monster> onDeath;

    public bool IsAlive { get; private set; }

    public void Initialize(HeroCharacter hero, Action<Monster> onDeath)
    {
        IsAlive = true;
        this.onDeath = onDeath;
        movement.Initialize(attackArea, view, baseStats.moveSpeed);
        attack.Initialize(attackArea, hero);
        health.Initialize(baseStats.health, OnDeath);
    }
    
    public void ReceiveDamage(int damage)
    {
        if(IsAlive)
            health.ReceiveDamage(damage);
    }

    public void Attack() => attack.Do();

    void OnDeath()
    {
        onDeath(this);
        IsAlive = false;
    }
}
