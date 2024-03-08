﻿/*
* Author:	Iris Bermudez
* Date:		08/03/2024
*/



using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using Solitaire.Gameplay.Spider;
using Solitaire.Gameplay;
using Solitaire.Gameplay.Cards;



namespace Tests.Solitaire.Gameplay.Spider {
    public class SpiderGameModeTest {
        #region Variables
        private GameObject spiderGameModeMockGameObject;
        private SpiderGameModeMock spiderGameModeMock;

        private const string SPIDERGAMEMODEMOCK_PREFAB_PATH = "Assets/Scripts/Tests/Solitaire/"
                                                + "Gameplay/Spider/SpiderGameModeMock Prefab.prefab";
        private const string CARD_PREFAB_PATH = "Assets/Prefabs/Gameplay/Card Prefab.prefab";
        private const string SPIDERCARDCONTAINERM_PREFAB_PATH = "Assets/Prefabs/Gameplay/Spider"
                                                + "/SpiderCardContainer 6Cards.prefab";
        #endregion


        #region Tests set up
        [SetUp]
        public void Setup() {
            spiderGameModeMockGameObject = GameObject.Instantiate( AssetDatabase
                                                            .LoadAssetAtPath<GameObject>(
                                                                SPIDERGAMEMODEMOCK_PREFAB_PATH));
            if (!spiderGameModeMockGameObject) {
                throw new NullReferenceException($"GameObject at {SPIDERGAMEMODEMOCK_PREFAB_PATH} "
                                                    + "could not be loaded.");
            }

            spiderGameModeMock = spiderGameModeMockGameObject.GetComponent<SpiderGameModeMock>();
            if (!spiderGameModeMock) {
                throw new NullReferenceException($"GameObject at {SPIDERGAMEMODEMOCK_PREFAB_PATH} "
                                                    + "does not contain a SpiderGameMode component.");
            }
        }
        #endregion


        #region Tests
        [Test]
        public void SpiderGameModeMock_InheritsFromSpiderGameMode() {
            Assert.IsInstanceOf(typeof(SpiderGameMode), spiderGameModeMock,
                                "SpiderGameModeMock must inherit from SpiderGameMode instance.");
        }


        [Test]
        public void SpiderGameMode_InheritsFromAbstractGameMode() {
            // Instantiate SpiderGameMode object
            SpiderGameMode spiderGameMode = GameObject.Instantiate(new GameObject())
                                                            .AddComponent<SpiderGameMode>();

            // Assert SpiderGameMode inherits from AbstractGameMode
            Assert.IsInstanceOf(typeof(AbstractGameMode), spiderGameMode,
                                "spiderGameMode must be a AbstractGameMode instance.");
        }


        [Test]
        public void WhenInitializing_ThenDistributeCardsToContainersPropperly() {
            // Create list of cards for SpiderGameMode initialization
            GameObject cardFacadePrefabGameObject = GameObject.Instantiate(
                                AssetDatabase.LoadAssetAtPath<GameObject>(CARD_PREFAB_PATH) );
            CardFacade cardFacadePrefab = cardFacadePrefabGameObject.GetComponent<CardFacade>();
            List<CardFacade> listOfCardsToAdd = new List<CardFacade>() {
                                        GameObject.Instantiate( cardFacadePrefabGameObject )
                                                                    .GetComponent<CardFacade>(),
                                        GameObject.Instantiate( cardFacadePrefabGameObject )
                                                                    .GetComponent<CardFacade>(),
                                        GameObject.Instantiate( cardFacadePrefabGameObject )
                                                                    .GetComponent<CardFacade>(),
                                        GameObject.Instantiate( cardFacadePrefabGameObject )
                                                                    .GetComponent<CardFacade>(),
                                        GameObject.Instantiate( cardFacadePrefabGameObject )
                                                                    .GetComponent<CardFacade>(),
                                        GameObject.Instantiate( cardFacadePrefabGameObject )
                                                                    .GetComponent<CardFacade>()
                                    };
            int amountOfCardsToBeAdded = listOfCardsToAdd.Count;

            // Check amount of cards before initialization


            // Initialize SpiderGameMode


            // Check amount of distributed cards after initialization


        }
        #endregion
    }
}