using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Common;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Generators
{
    public class DecorationRandomizer : MonoBehaviour
    {
        [SerializeField] float chanceOfDeco;
        [SerializeField] GameObject[] decos;

        void Start()
        {
            if (Random.Range(0, 100) < chanceOfDeco)
                decos.PickOne().SetActive(true);
        }
    }
}
