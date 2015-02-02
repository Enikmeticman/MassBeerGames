using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.GameAssets.Scripts.GamePlay.Cards
{
    public class CardDummy   
    {
        #region Private Members
        /// <summary>
        /// The value of the card 
        /// </summary>
        private int _Value = 0;
        #endregion

        #region Properties
        /// <summary>
        /// The color of the card. /property/
        /// </summary>
        public ColorType Color
        {
            get;
            private set;
        }

        /// <summary>
        /// The type of the card. /property/
        /// </summary>
        public CardType TypeOfCard
        {
            get;
            private set;
        }


        /// <summary>
        /// The name of the card. /property/
        /// </summary>
        public string CardName
        {
            get;
            private set;
        }

        /// <summary>
        /// The name of the card. /property/
        /// </summary>
        public Texture FrontImage
        {
            get;
            private set;
        }

        /// <summary>
        /// The value of the card. /property/
        /// </summary>
        public int Value
        {
            get
            {
                return _Value;
            }
            private set { _Value = value; }
        }
        #endregion

        #region public Functions
        /// <summary>
        /// Initializes the card.
        /// </summary>
        /// <param name="pCard">Tha real card.</param>
        /// <param name="pType">Type of the card.</param>
        /// <param name="pValue">The card value.</param>
        /// <param name="pCardName">The name of the card.</param>
        /// <returns>the initialize state</returns>
        public CardDummy (Card pCard)
        {
            Color = pCard.Color;
            TypeOfCard = pCard.TypeOfCard;
            Value = pCard.Value;
            CardName = pCard.CardName;
            FrontImage = pCard.FrontImage();
        }
        #endregion
    }
}
