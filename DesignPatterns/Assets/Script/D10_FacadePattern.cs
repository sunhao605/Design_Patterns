using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FacadePattern
{
    /// <summary>
    /// 不使用外观模式的情况
    /// 此时客户端与三个子系统都发生了耦合，使得客户端程序依赖于子系统
    /// 为了解决这样的问题，我们可以使用外观模式来为所有子系统设计一个统一的接口
    /// 客户端只需要调用外观类中的方法就可以了，简化了客户端的操作
    /// 从而让客户和子系统之间避免了紧耦合
    /// </summary>

    public class D10_FacadePattern : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            SystemFacade facade = new SystemFacade();
            facade.Buy();
        }
        public class SystemFacade
        {
            private AuthoriationSystemA auth;
            private SecuritySystemB security;
            private NetBankSystemC netbank;

            public SystemFacade()
            {
                auth = new AuthoriationSystemA();
                security = new SecuritySystemB();
                netbank = new NetBankSystemC();
            }
            public void Buy()
            {
                auth.MethodA();
                security.MethodB();
                netbank.MethodC();
                Debug.Log("已经成功进行购买");
            }
        }
        //身份认证子系统A
        public class AuthoriationSystemA
        {
            public void MethodA()
            {
                Debug.Log("执行身份认证");
            }
        }

        //系统安全子系统B
        public class SecuritySystemB
        {
            public void MethodB ()
            {
                Debug.Log("执行系统安全检查");
            }
        }
        //网银安全子系统C
        public class NetBankSystemC
        {
            public void MethodC()
            {
                Debug.Log("执行网银安全检测");
            }
        }
    }
}

