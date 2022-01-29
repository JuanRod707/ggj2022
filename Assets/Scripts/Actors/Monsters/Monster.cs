using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] BasicMovement movement;
    [SerializeField] BasicAttack attack;
    [SerializeField] ConeArea attackArea;
    [SerializeField] HeroStats baseStats;
    
    public void Initialize(HeroProvider heroProvider)
    {
        movement.Initialize(attackArea, baseStats.moveSpeed);
        attack.Initialize(attackArea, heroProvider);
    }
    
    public void Attack() => attack.Do();

}
