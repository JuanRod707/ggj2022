using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Actors;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class StatPanel : MonoBehaviour
    {
        [SerializeField] Text dexterity;
        [SerializeField] Text strength;
        [SerializeField] Text vitality;
        [SerializeField] Text movement;

        public void SetValues(ActorStats stats)
        {
            dexterity.text = $"Dexterity: {stats.dexterity}";
            strength.text = $"Strength: {stats.strength}";
            vitality.text = $"Vitality: {stats.vitality}";
            movement.text = $"Movement: {stats.movement}";
        }
    }
}
