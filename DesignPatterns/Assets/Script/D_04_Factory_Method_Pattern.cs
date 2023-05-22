using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Factory_Method_Pattern
{
    /// <summary>
    /// 汽车抽象类
    /// </summary>
    public abstract class Car
    {
        public abstract void Go();
    }
    /// <summary>
    /// 红旗汽车
    /// </summary>
    public class HongQiCar : Car
    {
        public override void Go()
        {
            Debug.Log("红旗汽车开始行驶了！");
        }
    }

    /// <summary>
    /// 奥迪汽车
    /// </summary>
    public class AoDiCar : Car
    {
        public override void Go()
        {
            Debug.Log("奥迪汽车开始行驶了");
        }
    }

    /// <summary>
    /// 抽象工厂类
    /// </summary>
    public abstract class Factory
    {
        // 工厂方法
        public abstract Car CreateCar();
    }
    /// <summary>
    /// 奥迪汽车工厂类
    /// </summary>
    public class AoDiCarFactory : Factory
    {
        public override Car CreateCar()
        {
            return new AoDiCar();
        }
    }
    /// <summary>
    /// 红旗汽车工厂类
    /// </summary>
    public class HongQiCarFactory : Factory
    {
        /// <summary>
        /// 负责生产红旗汽车
        /// </summary>
        /// <returns></returns>
        public override Car CreateCar()
        {
            return new HongQiCar();
        }
    }
    public class D_04_Factory_Method_Pattern : MonoBehaviour
    {

        // Start is called before the first frame update
        void Start()
        {
            Factory hongQiCarFactory = new HongQiCarFactory();
            Factory aoDiCarFactory = new AoDiCarFactory();
            Car hongQi = hongQiCarFactory.CreateCar();
            hongQi.Go();

            Car aoDi = aoDiCarFactory.CreateCar();
            aoDi.Go();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

