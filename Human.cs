using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;

namespace Lab6
{
    class Human: IEnumerable, IHasName
    {
        public string Name { get; set; }
        public Human(string name)
        {
            Name = name;
        }
        public Human()
        { }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<CoupleAttribute> GetEnumerator()
        {
            Attribute[] attributes = Attribute.GetCustomAttributes(GetType());
            foreach (Attribute attribute in attributes)
            {
                if (attribute is CoupleAttribute coupleAttribute)
                {
                    yield return coupleAttribute;
                }
            }
        }
        public double RandomProbabillity()
        {
            Random r = new Random();
            return r.NextDouble();
        }
        public IHasName Couple(Human human, Human human1)
        {
            bool human1Like = false;
            CoupleAttribute humanCase = new CoupleAttribute();
            foreach (CoupleAttribute att in human)
            {
                if(att.Pair == human1.GetType().Name)
                {
                    humanCase = att;
                    double rand = RandomProbabillity();
                    if (rand >= att.Probability)
                    {
                        human1Like = true;
                        Console.WriteLine(human.GetType().Name + " likes " + human1.GetType().Name);
                        break;
                    }
                    else
                    {
                        Console.WriteLine(human.GetType().Name + " dislikes " + human1.GetType().Name);
                    }
                }
            }
            bool humanLike = false;
            CoupleAttribute human1Case = new CoupleAttribute();
            foreach (CoupleAttribute att in human1)
            {
                if (att.Pair == human.GetType().Name)
                {
                    human1Case = att;
                    double rand = RandomProbabillity();
                    if (rand >= att.Probability)
                    {
                        humanLike = true;
                        Console.WriteLine(human1.GetType().Name + " likes " + human.GetType().Name);
                        break;
                    }
                    else
                    {
                        Console.WriteLine(human1.GetType().Name + " dislikes " + human.GetType().Name);
                    }
                }
            }
            object result = new object();
            object child = new object();
            if (humanLike && human1Like)
            {
                foreach (MethodInfo methodInfo in human1.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance))
                {
                    if (methodInfo.ReturnType == typeof(System.String))
                    {
                        try
                        {
                            result = methodInfo.Invoke(human1, null);
                            break;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                    }
                }
            }

            Type type = Type.GetType(GetType().Namespace + "." + humanCase.ChildType);
            if (type != null)
            {
                child = Activator.CreateInstance(type);
                PropertyInfo nameProperty = child.GetType().GetProperty("Name");
                PropertyInfo surnameProperty = child.GetType().GetProperty("Surname");
                if (nameProperty != null && surnameProperty != null)
                {
                    nameProperty.SetValue(child, result);
                    if (nameProperty.GetValue(child, null).ToString() == "Student" || nameProperty.GetValue(child, null).ToString() == "Botan")
                    {
                        surnameProperty.SetValue(child, surnameProperty.GetValue(child, null) + "ович");
                    }
                    else
                    {
                        surnameProperty.SetValue(child, surnameProperty.GetValue(child, null) + "овна");
                    }
                }
            }
            else
            {
                return this;
            }
            return (IHasName)child;

        }
        public static void CheckCouple(Human human, Human human1)
        {
            if (Woman(human) && Woman(human1) || Man(human) && Man(human1))
                throw new InvalidCoupleArgument("Couple must have different sexes");
        }
        protected static bool Man(Human human)
        {
            return human is Student || human is Botan;
        }

        protected static bool Woman(Human human)
        {
            return human is Girl || human is PrettyGirl || human is SmartGirl;
        }
    }
}
