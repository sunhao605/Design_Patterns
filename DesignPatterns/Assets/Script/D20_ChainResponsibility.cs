using System;
using System.Collections;
using System.Collections.Generic;
using ChainOfResponsibility;
using UnityEngine;

namespace ChainOfResponsibility
{
    //采购请求
    public sealed class PurchaseRequest
    {
        //金额
        public double Amount { get; set; }
        //产品名字
        public string ProductName { get; set; }

        public PurchaseRequest(double amount, string productName)
        {
            Amount = amount;
            ProductName = productName;
        }
    }

    //[抽象处理者角色] 抽象审批人 Handler
    public abstract class Approver
    {
        //下一位审批人，由此形成一条链条
        public Approver NextApprover { get; set; }
        //审批人的名字
        public string Name { get; set; }

        public Approver(string name)
        {
            this.Name = name;
        }
        //处理请求
        public abstract void ProcessRequest(PurchaseRequest request);
    }
    //[具体处理者角色] 部门经理
    public sealed class Manager : Approver
    {
        public Manager(string name) : base(name) { }
        public override void ProcessRequest(PurchaseRequest request)
        {
            if(request.Amount <= 1000)
            {
                Debug.LogFormat("部门经理{0}批准了对原材料{1}的采购计划",this.Name,request.ProductName);
            }
            else if(NextApprover!=null)
            {
                NextApprover.ProcessRequest(request);
            }
        }
    }

    //[具体处理者角色] 财务经理
    public sealed class FinancialManager : Approver
    {
        public FinancialManager(string name) : base(name) { }

        public override void ProcessRequest(PurchaseRequest request)
        {
            if (request.Amount > 1000.0 && request.Amount <= 50000.0)
            {
                Debug.LogFormat("财务经理{0}批准了对原材料{1}的采购计划", this.Name, request.ProductName); 
            }
            else if (NextApprover != null)
            {
                NextApprover.ProcessRequest(request);
            }
        }
    }

    //[具体处理者角色] 总裁
    public sealed class CEO: Approver
    {
        public CEO(string name) : base(name) { }

        public override void ProcessRequest(PurchaseRequest request)
        {
            if (request.Amount > 50000.0 && request.Amount <= 300000.0)
            {
                Debug.LogFormat("CEO{0}批准了对原材料{1}的采购计划", this.Name, request.ProductName);
            }
            else
            {
                Debug.Log("这个采购计划的金额比较大，需要一次董事会会议讨论才能决定！"+request.ProductName);
            }
        }
    }
}
public class D20_ChainResponsibility : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PurchaseRequest requestXian = new PurchaseRequest(800.0, "显示器一台");
        PurchaseRequest requestDian = new PurchaseRequest(8000.0, "电脑一台");
        PurchaseRequest requestXiang = new PurchaseRequest(80000.0, "相机一台");
        PurchaseRequest requestYuan = new PurchaseRequest(800000.0, "原料一批");

        Approver manager = new Manager("牛永强");
        Approver financial = new FinancialManager("刘璐刚");
        Approver ceo = new CEO("顾新宇");

        //设置职责链
        manager.NextApprover = financial;
        financial.NextApprover = ceo;

        //处理请求
        manager.ProcessRequest(requestXian);
        manager.ProcessRequest(requestDian);
        manager.ProcessRequest(requestXiang);
        manager.ProcessRequest(requestYuan);
    }
}
