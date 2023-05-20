using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SimpleFactory
{
    //抽象工厂类
    public abstract class Product
    {
        //所有产品类的公共业务方法
        public void MethodSame()
        {
            Debug.Log("处理公共业务方法");
        }
        public abstract void MethodDiff();
    }
    //具体工厂类1
    public class ConcreateProductA : Product
    {
        public override void MethodDiff()
        {
            Debug.Log("具体产品A处理业务方法");
        }
    }
    //具体工厂类2
    public class ConcreateProductB : Product
    {
        public override void MethodDiff()
        {
            Debug.Log("具体产品B处理业务方法");
        }
    }

    public static class Factory
    {
        //静态方法
        public static Product GetProduct(string arg)
        {
            Product product = null;
            switch (arg)
            {
                case "A":
                    product = new ConcreateProductA();
                    break;
                case "B":
                    product = new ConcreateProductB();
                    break;
                default:
                    throw new ArgumentException(message: "Invalid arg value");
            }
            return product;
        }
    }
    public class SimpleFactory : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            //实例化产品A，并调用
            try
            {
                Product productA = Factory.GetProduct("A");
                //var productA = Factory.GetProduct("A");
                productA.MethodSame();
                productA.MethodDiff();
            }
            catch (Exception ex)
            {
                Debug.Log(ex.Message);
            }

            //实例化产品B，并调用
            try
            {
                Product productB = Factory.GetProduct("B");
                //var productB = Factory.GetProduct("B");
                productB.MethodSame();
                productB.MethodDiff();
            }
            catch (Exception ex)
            {
                Debug.Log(ex.Message);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}



