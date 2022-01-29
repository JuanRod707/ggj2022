using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Common;
using UnityEngine;

namespace Assets.Scripts.Generators
{
    public class DecorationRandomizer : MonoBehaviour
    {
        [SerializeField] float chanceOfDeco;
        [SerializeField] MeshRenderer mesh;

        [SerializeField] GameObject[] decos;
        [SerializeField] MaterialWeightedList weightedMaterials;

        void Start()
        {
            mesh.material = weightedMaterials.TakeOne();

            if (UnityEngine.Random.Range(0, 100) < chanceOfDeco)
                decos.PickOne().SetActive(true);
        }
    }

    [Serializable]
    public class MaterialWeightPair
    {
        public Material Material;
        public int Weight;
    }

    [Serializable]
    public class MaterialWeightedList
    {
        [SerializeField] MaterialWeightPair[] materialWeights;

        public Material TakeOne()
        {
            var flatList = new List<Material>();
            foreach (var mw in materialWeights)
            {
                foreach(var _ in Enumerable.Range(0, mw.Weight))
                    flatList.Add(mw.Material);
            }

            return flatList.PickOne();
        }
    }
}
