using System.Linq;
using Assets.Scripts.Common;
using UnityEngine;

namespace Assets.Scripts.Trophies
{
    public class TrophyGenerator : MonoBehaviour
    {
        [SerializeField] Vector3 offset;

        [SerializeField] ModifierParameterSet[] parameterSets;
        [SerializeField] Trophy trophyPrefabProsp;
        [SerializeField] Trophy trophyPrefabRuin;
        [SerializeField] Transform altarP;
        [SerializeField] Transform altarR;
        [SerializeField] GameObject TrophyPopUp;
        [SerializeField] TrophyTooltip tooltipP;
        [SerializeField] TrophyTooltip tooltipR;

        public Trophy RuinTrophy { get; private set; }
        public Trophy ProsperityTrophy { get; private set; }
        
        void Generate()
        {
            var alignment = Alignment.Ruin;
            var set = parameterSets.PickOne();
            var statMods = set.parameters.Select(mp => new StatMod(mp));

            RuinTrophy = Instantiate(trophyPrefabRuin, altarR);
            RuinTrophy.transform.position += offset;
            RuinTrophy.Initialize(alignment, set.Affinity, statMods, tooltipR);

            alignment = Alignment.Prosperity;
            set = parameterSets.PickOne();
            statMods = set.parameters.Select(mp => new StatMod(mp));

            ProsperityTrophy = Instantiate(trophyPrefabProsp, altarP);
            ProsperityTrophy.transform.position += offset;
            ProsperityTrophy.Initialize(alignment, set.Affinity, statMods, tooltipP);

            TrophyPopUp.SetActive(true);
        }

        public void Show()
        {
            Generate();
            gameObject.SetActive(true);
        }
    }
}
