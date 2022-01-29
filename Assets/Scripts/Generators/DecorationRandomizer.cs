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
        [SerializeField] MeshRenderer mesh;

        [SerializeField] GameObject[] decos;
        [SerializeField] Material[] materials;

        void Start()
        {
            mesh.material = materials.PickOne();

            if (Random.Range(0, 100) < chanceOfDeco)
                decos.PickOne().SetActive(true);
        }
    }
}
