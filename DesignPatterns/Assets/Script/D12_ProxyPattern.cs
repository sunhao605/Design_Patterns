using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProxyPattern
{
    public class D12_ProxyPattern : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            AgentAbstract fan = new AgentPerson();
            fan.Speculation("1234");

            fan.Speculation("5678");
        }
    }
    //该类型就是抽象Subject角色，定义代理角色和真实主体角色共有的接口方法
    public abstract class AgentAbstract
    {
        //该方法执行的具体炒作---该方法相当于抽象Subject的Request方法
        public virtual void Speculation(string thing)
        {
            Debug.Log("AgentAbstract"+thing);
        }
    }

    //该类型是代理类型 相当于具体的Proxy角色
    public sealed class AgentPerson : AgentAbstract
    {
        private FanStar boss;
        public AgentPerson()
        {
            boss = new FanStar();
        }

        public override void Speculation(string thing)
        {
            Debug.Log(1);
            boss.Speculation(thing);
            Debug.Log(2);
        }
    }

    //该类型是Fan姓明星-----相当于具体的RealSubject角色
    public sealed class FanStar : AgentAbstract
    {
        public FanStar() { }

        public override void Speculation(string thing)
        {
            Debug.Log("FanStar" + thing);
        }
    }
}

