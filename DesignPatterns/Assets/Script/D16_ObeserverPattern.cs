using System;
using System.Collections;
using System.Collections.Generic;
using ObserverPattern;
using UnityEngine;

namespace ObserverPattern
{
    //抽象主题角色：银行短信系统抽象接口 是被观察者
    public abstract class BankMessageSystem
    {
        protected IList<Depositor> observers;
        //构造函数初始化观察者列表实例
        protected BankMessageSystem()
        {
            observers = new List<Depositor>();
        }
        //增加预约储户
        public abstract void Add(Depositor depositor);

        //删除预约储户
        public abstract void Delete(Depositor depositor);

        //通知储户
        public void Notify()
        {
            foreach(Depositor depositor in observers)
            {
                if (depositor.AccountIsChanged)
                {
                    depositor.Update(depositor.Balance, depositor.OperationDateTime);
                    //账户发生了变化，并且通知了，储户的账户被认为没有变化
                    depositor.AccountIsChanged = false;
                }
            }
        }
    }
    //具体主体角色 北京银行短信系统 是被观察者
    public sealed class BeiJingBankMessageSystem : BankMessageSystem
    {
        //增加预约储户
        public override void Add(Depositor depositor)
        {
            //应该先判断该用户是否存在，存在不操作，不存在就增加到储户列表中
            observers.Add(depositor);
        }

        public override void Delete(Depositor depositor)
        {
            observers.Remove(depositor);
        }
    }

    //抽象观察者角色：储户的抽象接口
    public abstract class Depositor
    {
        //状态数据
        private string _name;
        private int _balance;
        private int _total;
        private bool _isChanged;

        //初始化状态数据
        protected Depositor(string name, int total)
        {
            this._name = name;
            this._balance = total;//存款总额等于余额
            this._isChanged = false;//账户未发生变化
        }

        //储户的名称，假设可以唯一区别的
        public string Name
        {
            get { return _name; }
            private set { this._name = value; }
        }

        public int Balance
        {
            get { return this._balance; }
        }

        //取钱
        public void GetMoney(int num)
        {
            if (num <= this._balance && num > 0)
            {
                this._balance = this._balance - num;
                this._isChanged = true;
                OperationDateTime = DateTime.Now;
            }
        }
        //账户操作时间
        public DateTime OperationDateTime { get; set; }

        //账户是否发生变化
        public bool AccountIsChanged
        {
            get { return this._isChanged; }
            set { this._isChanged = value; }
        }

        //更新储户状态
        public abstract void Update(int currentBalance, DateTime dateTime);
    }

    //具体观察者角色
    public sealed class BeiJingDepositor : Depositor
    {
        public BeiJingDepositor(string name,int total) : base(name, total) { }
        public override void Update(int currentBalance, DateTime dateTime)
        {
            Debug.Log(Name + ":账户发生了变化，变化时间是" + dateTime.ToString() + ",当前余额是" + currentBalance.ToString());
        }
    }
}


public class D16_ObeserverPattern : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //我们有了三位储户，都是武林高手，也比较有钱
        Depositor huangfeiHong = new BeiJingDepositor("黄飞鸿",3000);
        Depositor fangshiyu = new BeiJingDepositor("方世玉", 1300);
        Depositor hongxiguan = new BeiJingDepositor("洪熙官",9000);

        BankMessageSystem beijingBank = new BeiJingBankMessageSystem();

        //这三位开始订阅银行短信业务
        beijingBank.Add(huangfeiHong);
        beijingBank.Add(fangshiyu);
        beijingBank.Add(hongxiguan);

        //黄飞鸿取100圆
        huangfeiHong.GetMoney(100);
        beijingBank.Notify();

        //黄飞鸿和方世玉都取了钱
        huangfeiHong.GetMoney(200);
        fangshiyu.GetMoney(200);
        beijingBank.Notify();


        //他们三个都取了钱
        huangfeiHong.GetMoney(320);
        fangshiyu.GetMoney(4330);//取的钱大于储存的钱，所以不会接收通知
        hongxiguan.GetMoney(332);
        beijingBank.Notify();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
