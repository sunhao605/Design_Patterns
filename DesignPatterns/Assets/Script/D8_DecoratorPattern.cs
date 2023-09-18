using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DecoratorPattern
{
    /// Component 英雄接口
    public abstract class Hero
    {
        //学习技能
        public abstract void learnSkills();
    }

    // ConcreteComponent 具体英雄盲僧
    public sealed class BlindMonk : Hero
    {
        private string name;
        public BlindMonk(string name)
        {
            this.name = name;
        }
        public override void learnSkills()
        {
            Debug.Log(name + "学习了一下技能");
        }
    }

    //Decorator 技能栏
    public abstract class Skills : Hero
    {
        //持有一个英雄对象接口
        private Hero hero;
        public Skills(Hero hero)
        {
            this.hero = hero;
        }
        public override void learnSkills()
        {
            if (hero != null) hero.learnSkills();
        }
    }

    //ConreteDecorator 技能Q
    public class Skill_Q : Skills
    {
        private string skillName;
        public Skill_Q(Hero hero,string skillName) : base(hero)
        {
            this.skillName = skillName;
        }
        public override void learnSkills()
        {
            base.learnSkills();
            Debug.Log("学习了Q技能" + skillName);
        }
    }

    //ConreteDecorator 技能W
    public class Skill_W : Skills
    {
        private string skillName;
        public Skill_W(Hero hero, string skillName) : base(hero)
        {
            this.skillName = skillName;
        }
        public override void learnSkills()
        {
            base.learnSkills();
            Debug.Log("学习了W技能" + skillName);
        }
    }

    //ConreteDecorator 技能E
    public class Skill_E : Skills
    {
        private string skillName;
        public Skill_E(Hero hero, string skillName) : base(hero)
        {
            this.skillName = skillName;
        }
        public override void learnSkills()
        {
            base.learnSkills();
            Debug.Log("学习了E技能" + skillName);
        }
    }

    //ConreteDecorator 技能E
    public class Skill_R : Skills
    {
        private string skillName;
        public Skill_R(Hero hero, string skillName) : base(hero)
        {
            this.skillName = skillName;
        }
        public override void learnSkills()
        {
            base.learnSkills();
            Debug.Log("学习了R技能" + skillName);
        }
    }
    public class D8_DecoratorPattern : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            //选择英雄
            Hero hero = new BlindMonk("李青");
            Skills r = new Skill_R(hero,"猛龙摆尾");
            Skills e = new Skill_E(r, "天雷破/摧筋断骨");
            Skills w = new Skill_W(e, "金钟罩/铁布衫");
            Skills q = new Skill_Q(w, "天音波/回音击");

            r.learnSkills();
            e.learnSkills();
            w.learnSkills();
            q.learnSkills();

            //学习技能
            Hero hero1 = new BlindMonk("李青1");
            Skills q1 = new Skill_Q(hero1, "天音波/回音击");
            q1.learnSkills();
        }
    }
}

