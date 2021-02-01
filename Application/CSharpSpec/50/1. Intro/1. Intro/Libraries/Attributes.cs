using System;
using System.Reflection;

namespace _1.Intro.Libraries
{
    public class HelpAttribute : Attribute
    {
        string url;
        string topic;

        public HelpAttribute(string url)
        {
            this.url = url;
        }

        public string Url
        {
            get { return url; }
        }

        public string Topic
        {
            get { return topic; }
            set { topic = value; }
        }
    }
    //
    [Help("http://msdn.microsoft.com/.../MyClass.htm")]
    public class Widget
    {
        [Help("http://msdn.microsoft.com/.../MyClass.htm", Topic = "Display")]
        public void Display(string text) { }
    }
    //
    class AttributeProxy
    {
        public static void ShowHelp(MemberInfo member)
        {
            HelpAttribute a = Attribute.GetCustomAttribute(member,
            typeof(HelpAttribute)) as HelpAttribute;
            if (a == null)
            {
                Console.WriteLine("No help for {0}", member);
            }
            else
            {
                Console.WriteLine("Help for {0}:", member);
                Console.WriteLine("  Url={0}, Topic={1}", a.Url, a.Topic);
            }
        }
    }
}
