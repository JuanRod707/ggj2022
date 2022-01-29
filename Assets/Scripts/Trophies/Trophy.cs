using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Trophies
{
    public class Trophy : MonoBehaviour
    {
        [SerializeField] TrophyTooltip tooltip;
        public Alignment Alignment { get; private set; }
        public int Affinity { get; private set; }
        public IEnumerable<StatMod> StatMods { get; private set; }

        public void Initialize (Alignment alignment, int affinity, IEnumerable<StatMod> statMods)
        {
            Alignment = alignment;
            Affinity = affinity;
            StatMods = statMods;

            tooltip.WriteData(alignment, statMods.ToArray());
        }
    }
}