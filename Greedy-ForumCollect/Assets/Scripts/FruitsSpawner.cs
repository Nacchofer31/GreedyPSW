using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsSpawner : MonoBehaviour
{
    public Transform foodGrid;
    public static Sprite[] Sprite_Pic;

    public List<IFruit> fruits = new List<IFruit>();
    FruitFactory eFactory = new FruitFactory();

    void Start()
    {
        //Elementos hijo del grid Food
        foreach (Transform t in foodGrid)
        {
            IFruit generatedFruit = eFactory.GetFruit((FruitTypes)generateRandomType());
            fruits.Add(generatedFruit);
            generatedFruit.setSprite(t.gameObject);
        }
    }

    public interface IFruit
    {
        void  setSprite(GameObject prefab);
        int getCalories();
    }

    public enum FruitTypes
    {
        small=0,
        medium,
        big
    }

    public class FruitFactory
    {
        public IFruit GetFruit(FruitTypes fruitType)
        {
            switch (fruitType)
            {
                case FruitTypes.small:
                    return new SmallFruit();
                case FruitTypes.medium:
                    return new MediumFruit();
                default:
                    return new BigFruit();
            }
        }
    }

    public class SmallFruit : IFruit
    {
        public int calories;
        public Sprite sprite;

        public SmallFruit()
        {
            calories = 10;
        }

        public void setSprite(GameObject prefab)
        {
            sprite = Sprite_Pic[Random.Range(0, 4)];
            prefab.GetComponent<SpriteRenderer>().sprite = sprite;
        }

        public int getCalories()
        {
            return calories;
        }
    }

    public class MediumFruit : IFruit
    {
        public int calories;
        public Sprite sprite;

        public MediumFruit()
        {
            calories = 20;
        }

        public void setSprite(GameObject prefab)
        {
            sprite = Sprite_Pic[Random.Range(5, 9)];
            prefab.GetComponent<SpriteRenderer>().sprite = sprite;
        }

        public int getCalories()
        {
            return calories;
        }
    }

    public class BigFruit : IFruit
    {
        public int calories;
        public Sprite sprite;

        public BigFruit()
        {
            calories = 40;
        }

        public void setSprite(GameObject prefab)
        {
            sprite = Sprite_Pic[Random.Range(10, 14)];
            prefab.GetComponent<SpriteRenderer>().sprite = sprite;
        }

        public int getCalories()
        {
            return calories;
        }
    }

    private int generateRandomType()
    {
        return Random.Range(0,2);
    }
}
