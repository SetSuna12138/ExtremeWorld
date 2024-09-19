using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Shop
{
    public class Number : MonoBehaviour
    {
        private Text text;

        public void Start()
        {
            text = this.GetComponent<Text>();
        }

        public void SetNumber(int num)
        {
            text.text = num.ToString();
        }
    }
}
