﻿/*
* Author:	Iris Bermudez
* Date:		07/03/2024
*/


using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Solitaire.Gameplay.CardContainers;
using Solitaire.Gameplay.Cards;
using Solitaire.Gameplay.Spider;
using UnityEditor;
using UnityEngine;



namespace Tests.Solitaire.Gameplay.Spider {
    public class SpiderCardContainerForCardDistributorTest {
        #region Variables
        private GameObject spiderCardContainerForCardDistributorGameObject;
        private SpiderCardContainerForCardDistributor spiderCardContainerForCardDistributor;

        private const string CARD_PREFAB_PATH = "Assets/Prefabs/Gameplay/Card Prefab.prefab";
        private const string SPIDER_CARDCONTAINER_FORCARDDISTRIBUTION_PREFAB_PATH = "Assets/Prefabs/Gameplay/Spider"
                                                + "/CardDistributor.prefab";
        #endregion


        #region Tests set up
        [SetUp]
        public void Setup() {
            spiderCardContainerForCardDistributorGameObject = AssetDatabase.LoadAssetAtPath<GameObject>(
                                                SPIDER_CARDCONTAINER_FORCARDDISTRIBUTION_PREFAB_PATH);

            if (!spiderCardContainerForCardDistributorGameObject) {
                throw new NullReferenceException("GameObject at spiderCardContainerForCardDistributor_PREFAB_PATH "
                        + "could not be loaded.");
            }

            spiderCardContainerForCardDistributor = spiderCardContainerForCardDistributorGameObject
                                                    .AddComponent<SpiderCardContainerForCardDistributor>();

            if( !spiderCardContainerForCardDistributor ) {
                throw new NullReferenceException( $"GameObject at "
                                + $"{SPIDER_CARDCONTAINER_FORCARDDISTRIBUTION_PREFAB_PATH} "
                                + "does not contain a spiderCardContainerForCardDistributor component.");
            }
        }
        #endregion


        #region Tests
        [Test]
        public void SpiderCardContainerForCardDistributor_IsAbstractCardContainer() {
            Assert.IsInstanceOf( typeof(AbstractCardContainer),
                                spiderCardContainerForCardDistributor,
                                "SpiderCardContainerForCardDistributor must inherit from "
                                    + "AbstractCardContainer");
        }


        [Test]
        public void WhenAddingACard_ThenThrowsNotImplementedException() {
            //  Instantiate cards
            int amountOfCardsToSpawn = UnityEngine.Random.Range(0, 50);
            GameObject cardGameObject = GameObject.Instantiate(new GameObject());

            // Check to avoid false positive
            Assert.Zero(spiderCardContainerForCardDistributor.GetCards().Count,
                            "spiderCardContainerForCardDistributor shouldn't contain any cards");

            //  Assert addition of card
            for (int i = 0; i < amountOfCardsToSpawn; i++) {
                Assert.Throws<System.NotImplementedException>( 
                                                () => spiderCardContainerForCardDistributor
                                                    .AddCard(cardGameObject.AddComponent<CardFacade>()));
            }

            // Assert the amount of cards added is the same the BasicaCardContainer's contain
            Assert.Zero( spiderCardContainerForCardDistributor.GetCards().Count,
                        $"spiderCardContainerForCardDistributor cards has "
                            + $"{spiderCardContainerForCardDistributor.GetCards().Count} "
                            + $"when it should have 0 cards");
        }

        #endregion
    }
}
