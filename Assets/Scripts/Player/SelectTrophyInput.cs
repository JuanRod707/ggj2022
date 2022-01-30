using System;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class SelectTrophyInput : MonoBehaviour
    {
        Action selectRuin;
        Action selectProsperity;

        public void Initialize(Action selectRuin, Action selectProsperity)
        {
            this.selectRuin = selectRuin;
            this.selectProsperity = selectProsperity;
        }

        void Update()
        {
            if (Input.GetButtonDown("SelectRuin"))
            {
                selectRuin();
                enabled = false;
            }

            if (Input.GetButtonDown("SelectProsp"))
            {
                selectProsperity();
                enabled = false;
            }
        }
    }
}