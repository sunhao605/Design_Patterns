using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AdapterPatternClass
{
    /// <summary>
    /// 我家只有2个孔的插座，也就是适配器模式中的目标(Target)角色，这里只能是接口 是类适配器的限制
    /// </summary>
    public interface ITwoHoleTarget
    {
        void Request();
    }
    /// <summary>
    /// 手机充电器是有3个柱子的插头，源角色——需要适配的类（Adaptee）
    /// </summary>
    public abstract class ThreeHoleAdapteeClass
    {
        public void SpecificRequest()
        {
            Debug.Log("我是三个孔的插头");
        }
    }
    /// <summary>
    /// 适配器类，接口放在类的后面，在此无法适配更多的对象，这就是类适配器的不足
    /// </summary>
    public class ThreeToTwoAdapterclass : ThreeHoleAdapteeClass,ITwoHoleTarget
    {
        public void Request()
        {
            this.SpecificRequest();
        }
    }

    public class D6_class_AdapterPattern : MonoBehaviour
    {
        void Start()
        {
            ITwoHoleTarget change = new ThreeToTwoAdapterclass();
            change.Request();
        }
    }
}

