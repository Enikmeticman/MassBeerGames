using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.GameAssets.Scripts.GamePlay.Cards;

namespace Assets.GameAssets.Scripts.GamePlay
{
    public class RandomCardContainer : CardContainer
    {
        private object _Owner = null;

        /// <summary>
        /// A List containing all the cards in the deck.
        /// </summary>
        private List<Card> _Cards = new List<Card>();

        public override int Count
        {
            get { return _Cards.Count; }
        }

        public Card this[int pKey]
        {
            get
            {
                return _Cards[pKey];
            }
            set
            {
                _Cards[pKey] = value;
            }
        }

        public RandomCardContainer(object pOwner)
        {
            _Cards = new List<Card>();
            _Owner = pOwner;
        }

        public bool AddCard(Card pCard)
        {
            _Cards.Add(pCard);

            return true;
        }

        public bool Insert(Card pCard, int pIncex)
        {
            if (pIncex > _Cards.Count - 1)
                _Cards.Add(pCard);

            else
                _Cards.Insert(pIncex, pCard);

            return true;
        }

        public Card GetCard(string pCardName)
        {
            Card card = _Cards.FirstOrDefault(cardIndexed => cardIndexed.CardName == pCardName);

            if (card != null)
                _Cards.Remove(card);

            return card;
        }

        public CardDummy View(string pCardName)
        {
            return null;
        }

        public override void Shuffle()
        {
            if (_Cards.Count < 2) return;

            _Cards[0].Visable = false;

            Random rand = new Random();
            for (int i = _Cards.Count - 1; i > 0; i--)
            {
                int n = rand.Next(i + 1);
                Card temp = _Cards[i];
                _Cards[i] = _Cards[n];
                _Cards[n] = temp;

            }

            _Cards[0].Visable = true;
        }

        public override CardDummy[] GetDummyCards()
        {
            var dummys = new List<CardDummy>();

            _Cards.ForEach(x => dummys.Add(new CardDummy(x)));

            return dummys.ToArray();
        }
    }
}
