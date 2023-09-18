using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AdapterPattern
{
    /// <summary>
    /// 我家只有2个孔的插座，也就是适配器模式中的目标(Target)角色，这里可以写成抽象类或者接口
    /// </summary>
    public class TwoHoleTarget
    {
        // 客户端需要的方法
        public virtual void Request()
        {
            Debug.Log("两孔的充电器可以使用");
        }
    }
    /// <summary>
    /// 手机充电器是有3个柱子的插头，源角色——需要适配的类（Adaptee）
    /// </summary>
    public class ThreeHoleAdaptee
    {
        public void SpecificRequest()
        {
            Debug.Log("三个孔的插头也可以使用了");
        }
    }
    /// <summary>
    /// 适配器类，TwoHole这个对象写成接口或者抽象类更好，面向接口编程嘛
    /// </summary>
    public class ThreeToTwoAdapter : TwoHoleTarget
    {
        private ThreeHoleAdaptee threeHoleAdaptee = new ThreeHoleAdaptee();
        //实现两个孔插头接口方法
        public override void Request()
        {
            threeHoleAdaptee.SpecificRequest();
        }
    }

    public class D6_AdapterPattern : MonoBehaviour
    {
        /// <summary>
        /// 家里只有两个孔的插座，也懒得买插线板了，还要花钱，但是我的手机是一个有3个小柱子的插头，明显直接搞不定，那就适配吧
        /// </summary>
        // Start is called before the first frame update
        void Start()
        {
            TwoHoleTarget homeTwoHole = new ThreeToTwoAdapter();
            homeTwoHole.Request();
        }
    }
}

