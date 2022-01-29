using System.Linq;
using Assets.Scripts.Common;
using UnityEngine;

namespace Assets.Scripts.Trophies
{
    public class TrophyGenerator : MonoBehaviour
    {
        [SerializeField] ModifierParameterSet[] parameterSets;
        [SerializeField] Trophy trophyPrefab;
        [SerializeField] Transform altar1;
        [SerializeField] Transform altar2;

        void Start() => Generate();

        public void Generate()
        {
            var alignment = Alignment.Ruin;
            var set = parameterSets.PickOne();
            var statMods = set.parameters.Select(mp => new StatMod(mp));

            var trophy = Instantiate(trophyPrefab, altar1);
            trophy.Initialize(alignment, set.Affinity, statMods);

            alignment = Alignment.Prosperity;
            set = parameterSets.PickOne();
            statMods = set.parameters.Select(mp => new StatMod(mp));

            trophy = Instantiate(trophyPrefab, altar2);
            trophy.Initialize(alignment, set.Affinity, statMods);
        }
    }
}
