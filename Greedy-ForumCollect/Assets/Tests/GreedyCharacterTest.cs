using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class GreedyCharacterTest
    {
        private GameObject player;
        private Character_mov movement;
        private GameObject instance;

        [SetUp]
        public void TestInit()
        {
            player = (GameObject)Resources.Load("Tests/Player");
            instance = Object.Instantiate(player, new Vector2(0, 0), Quaternion.identity);
            movement = instance.GetComponent<Character_mov>();
        }

        [Test]
        public void TestLifeUp()
        {          
            movement.LifeUp();
            Assert.AreEqual(movement.getLifes(), 3);
        }

        [Test]
        public void TestPowerUpUsed()
        {
            GameObject boots = (GameObject)Resources.Load("Tests/Boots");
            GameObject bootsInstance = Object.Instantiate(boots, new Vector2(0, 0), Quaternion.identity);
            bool powerUpUsed = movement.GetPowerUpUsed();
            Assert.AreEqual(powerUpUsed, false);
        }

        [Test]
        public void TestGetDamage()
        {
            float currentDamageLevel = movement.getCurrentHealth();
            movement.Hurt(20);
            Assert.AreEqual(currentDamageLevel+20,movement.getCurrentHealth());
        }

        [Test]
        public void TestDestroyGuardian()
        {
            GameObject enemy = (GameObject)Resources.Load("Tests/Enemy_1");
            GameObject enemyInstance = Object.Instantiate(enemy, new Vector2(0, 0), Quaternion.identity);
            enemy_ia enemyIA = enemyInstance.GetComponent<enemy_ia>();
            Vector2 posEnemy = enemyIA.transform.position;

            movement.KillEnemy(enemyIA);
            Assert.AreEqual(enemyIA.getInitialPosition(), posEnemy);
        }
    }
}
