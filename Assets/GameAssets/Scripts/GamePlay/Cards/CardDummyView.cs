using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.GameAssets.Scripts.GamePlay.Cards
{
    public class CardDummyView : MonoBehaviour
    {
        /// <summary>
        /// The dummy card
        /// </summary>
        private CardDummy _Dummy = null;

        #region Public Members
        /// <summary>
        /// The renderer of the front side of the card.
        /// </summary>
        public Renderer _Front = null;
        #endregion

        public void SetDummy(CardDummy pDummy)
        {
            _Dummy = pDummy;
            _Front.material.mainTexture = pDummy.FrontImage;
        }
    }
}
