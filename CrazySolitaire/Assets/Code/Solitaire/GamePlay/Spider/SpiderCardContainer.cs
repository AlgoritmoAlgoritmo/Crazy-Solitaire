﻿/*
* Author:	Iris Bermudez
* Date:		11/12/2023
*/



using Solitaire.Cards;
using System.Collections.Generic;



namespace Solitaire.Gameplay.Spider {
    public class SpiderCardContainer : AbstractCardContainer {
        #region Variables

        #endregion


        #region MonoBehaviour methods
        #endregion


        #region Public methods
        public override List<CardFacade> Initialize( List<CardFacade> _cards ) {
            if( _cards == null     ||     _cards.Count == 0 ) {
                throw new System.Exception( "Cards list is empty." );

            } else if( _cards.Count < initialCardsAmount ) {
                throw new System.Exception( "There aren't enough cards to initialize CardContainer." );
            }


            return AddInitializationCards( _cards );
        }


        public override void AddCard( CardFacade _card ) {
            cards.Add( _card );
            _card.transform.position = GetCardPosition( _card );
        }


        public override void RemoveCard(CardFacade _card) {
            cards.Remove( _card );
            CheckAndFlipUpperCard();
        }


        public override bool AddCards( List<CardFacade> _cards ) {
            throw new System.NotImplementedException();
        }


        public override void RemoveCards( List<CardFacade> _cards ) {
            throw new System.NotImplementedException();
        }


        public override bool CandAddCards() {
            return canAddCards;
        }
        #endregion


        #region Protected methods
        protected override void SetUpStarterCards() {
            for( int i = 0; i <= cards.Count - 1; i++ ) {
                if( i != cards.Count - 1) { 
                    cards[i].FlipCard( false );
                    cards[i].SetCanBeDragged( false );
                    cards[i].SetCollisionsActive( false );

                    cards[i].ChildCard = cards[i + 1];
                    cards[i + 1].ParentCard = cards[i];

                } else { 
                    cards[i].FlipCard( true );
                    cards[i].SetCanBeDragged( true );
                    cards[i].SetCollisionsActive( true );
                }
            }
        }
        #endregion


        #region Private methods
        private void CheckAndFlipUpperCard() {
            if( GetTopCard() ) {
                GetTopCard().FlipCard( true );
                GetTopCard().SetCollisionsActive( true );
            }
        }
        #endregion
    }
}