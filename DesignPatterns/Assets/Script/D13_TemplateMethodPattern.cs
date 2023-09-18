using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TemplateMethodPattern
{
    public class D13_TemplateMethodPattern : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            AbstractClass fan = new ConcreateClass();
            fan.EatDumplings();

            fan = new ConcreateClass2();
            fan.EatDumplings();
        }
    }

    //该类型就是抽象类角色 ----abstractClass 定义做饺子的算法骨架，这里有三个步骤
    public abstract class AbstractClass
    {
        //该方法就是模板方法 方法里面包含了做饺子的算法步骤，模板方法可以返回结果。
        public void EatDumplings()
        {
            //和面
            MakingDough();
            //包馅
            MakingDumplings();
            //煮饺子
            BoiledDumplings();
            Debug.Log("饺子真好吃");
        }

        public abstract void MakingDough();

        public abstract void MakingDumplings();

        public abstract void BoiledDumplings();
    }

    //该类型是具体类角色--concreteClass 绿色面皮 猪肉大葱馅的饺子
    public sealed class ConcreateClass : AbstractClass
    {
        public override void BoiledDumplings()
        {
            Debug.Log("在和面的时候加入芹菜汁，和好的面就是绿色的");
        }

        public override void MakingDough()
        {
            Debug.Log("农家猪肉和农家大葱，制作成馅");
        }

        public override void MakingDumplings()
        {
            Debug.Log("用我家的大铁锅和大木材煮饺子");
        }
    }

    //该类型是具体类角色--concreteClass 绿色面皮 猪肉大葱馅的饺子
    public sealed class ConcreateClass2 : AbstractClass
    {
        public override void BoiledDumplings()
        {
            Debug.Log("在和面的时候加入胡萝卜汁，和好的面就是橙色的");
        }

        public override void MakingDough()
        {
            Debug.Log("农家鸡蛋和农家韭菜，制作成馅");
        }

        public override void MakingDumplings()
        {
            Debug.Log("可以用一般煤气和不粘锅煮就可以");
        }
    }
}

