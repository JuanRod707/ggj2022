using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Trophies
{
    public class TrophyTooltip : MonoBehaviour
    {
        [SerializeField] Text title;
        [SerializeField] Text mod1;
        [SerializeField] Text mod2;
        [SerializeField] Text mod3;

        public void WriteData(Alignment alignment, StatMod[] mods)
        {
            title.text = $"Trophy of {alignment}";
            mod1.text = $"{mods[0].Stat} + {mods[0].Mod}";
            mod2.text = $"{mods[1].Stat} + {mods[1].Mod}";
            mod3.text = $"{mods[2].Stat} {mods[2].Mod}";
        }
    }
}
