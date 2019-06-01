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
        public void TestGuardianAttack()
        {
            GameObject enemy = (GameObject)Resources.Load("Tests/Enemy_1");
            GameObject enemyInstance = Object.Instantiate(enemy, new Vector2(0, 0), Quaternion.identity);
            enemy_ia enemyMovement = enemyInstance.GetComponent<enemy_ia>();
            
            Assert.AreEqual(movement.getLifes(), 3);
        }

        [Test]
        public void TestGetDamage()
        {
            float currentDamageLevel = movement.getCurrentHealth();
            movement.Hurt(20);
            Assert.AreEqual(currentDamageLevel+20,movement.getCurrentHealth());
        }

    }
}
