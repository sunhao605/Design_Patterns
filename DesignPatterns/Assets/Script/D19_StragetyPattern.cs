using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StragetyPattern
{
    //环境角色--相当于Context类型
    public sealed class SalaryContext
    {
        private ISalaryStrategy _strategy;
        public SalaryContext(ISalaryStrategy strategy)
        {
            this._strategy = strategy;
        }
        public ISalaryStrategy ISalaryStrategy
        {
            get { return _strategy;}
            set { _strategy = value; }
        }
        public void GetSalary(double income)
        {
            _strategy.CalculateSalary(income);
        }
    }

    //抽象策略角色--相当于Strategy 类型
    public interface ISalaryStrategy
    {
        //工资计算
        void CalculateSalary(double income);
    }
    //程序员的工资 --- 相当于具体策略角色ConcreteStrategyA
    public sealed class ProgrammmerSalary : ISalaryStrategy
    {
        public void CalculateSalary(double income)
        {
            Debug.LogFormat("我的工资是：基本工资：{0} 底薪：{1} 加班费和项目奖金", income, 8000);
        }
    }

    //普通员工的工资--相当于具体策略角色ConcreteStrategyB
    public sealed class NormalPeopleSalary:ISalaryStrategy
    {
        public void CalculateSalary(double income)
        {
            Debug.LogFormat("我的工资是：基本工资：{0} 底薪：{1} 加班费", income, 3000);
        }
    }

    //CEO的工资 相当于具体策略角色ConcreteStrategyC
    public sealed class CEOSalary : ISalaryStrategy
    {
        public void CalculateSalary(double income)
        {
            Debug.LogFormat("我的工资是：基本工资：{0} 底薪：{1} 加班费和公司股票", income, 20000);
        }
    }

    public class D19_StragetyPattern : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Debug.Log("[普通员工的工资]");
            SalaryContext context = new SalaryContext(new NormalPeopleSalary());
            context.GetSalary(3000);

            Debug.Log("[程序员的工资]");
            context.ISalaryStrategy = new ProgrammmerSalary();
            context.GetSalary(6000);

            Debug.Log("[CEO的工资]");
            context.ISalaryStrategy = new CEOSalary();
            context.GetSalary(8000);
        }
    }
}

