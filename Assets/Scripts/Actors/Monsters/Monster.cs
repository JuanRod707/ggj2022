using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Monsters;
using Assets.Scripts.Actors.Stats;
using Assets.Scripts.Areas;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] BasicMovement movement;
    [SerializeField] MonsterAttack attack;
    [SerializeField] ConeArea attackArea;
    [SerializeField] ActorStats baseStats;
    [SerializeField] ActorView view;
    [SerializeField] Health health;

    public void Initialize(HeroCharacter hero)
    {
        movement.Initialize(attackArea, view, baseStats.moveSpeed);
        attack.Initialize(attackArea, hero);
        health.Initialize(baseStats.health);
    }
    
    public void ReceiveDamage(int damage)
    {
        health.ReceiveDamage(damage);

    }

    public void Attack() => attack.Do();

}
