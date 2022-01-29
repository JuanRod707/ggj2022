using System.Collections.Generic;
using System.Linq;
using System.Collections;
using UnityEngine;
using Assets.Scripts.Actors;
using Assets.Scripts.Areas;

public class Provider : MonoBehaviour
{
    private IEnumerable<Monster> monsters;
    private HeroCharacter hero;

    public void Initialize(IEnumerable<Monster> monsters) =>
        this.monsters = monsters;

    public IEnumerable<Monster> GetMonstersInArea(ConeArea area) =>
            monsters.Where(a => area.IsInArea(a.transform.position));
}
