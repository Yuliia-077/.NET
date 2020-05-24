using System;
using System.Collections.Generic;
using System.Text;

namespace Lab
{
    class TestCollections
    {
        private List<Person> People { get; set; }
        private List<string> ListString { get; set; }
        private Dictionary<Person, Student> DictPerson { get; set; }
        private Dictionary<string, Student> DictString { get; set; }
        public TestCollections(int size)
        {
            Student st;
            People = new List<Person>();
            ListString = new List<string>();
            DictPerson = new Dictionary<Person, Student>();
            DictString = new Dictionary<string, Student>();
            for (int i = 0; i < size; i++)
            {
                st = Create(i);
                People.Add(st.Person);
                DictPerson.Add(st.Person, st);
                DictString.Add(st.ToString(), st);
            }
        }
        public static Student Create(int i)
        {
            List<Exam> ex = new List<Exam>();
            for (int j = 0; j < 3; j++)
            {
                ex.Add(new Exam($"Subject{j}", j * i % 5, new DateTime(2020, 1 + i % 9 + j, 1 + i % 28 + j)));
            }
            List<Test> t = new List<Test>();
            for (int j = 0; j < 3; j++)
            {
                t.Add(new Test($"Test{j}", true));
            }
            Education education = Education.Master;
            if (i %3==0)
            {
                education = Education.Bachelor;
            }
            if (i % 3 == 1)
            {
                education = Education.Master;
            }
            if (i % 3 == 2)
            {
                education = Education.SecondEducation;
            }
            Student st = new Student($"FirstName{i}", $"Surname{i}", new DateTime(1990 + i % 10, 1 + i % 12, 1 + i % 20), education, i * 100, ex, t);
            return st;
        }
        public void MeasureTime(int[] indexes)
        {
            foreach (var index in indexes)
            {
                var value = Create(index);
                var key = value.Person;
                var start = new DateTime();
                start = DateTime.Now;
                var answer = People.Contains(key);
                var end = (DateTime.Now - start).TotalMilliseconds;
                Console.WriteLine("People list at index {0}: time in milliseconds " + end + " {1}", index, answer);
                start = DateTime.Now;
                answer = ListString.Contains(key.ToString());
                end = (DateTime.Now - start).TotalMilliseconds;
                Console.WriteLine("Persons list toString at index {0}: time in milliseconds " + end + " {1}", index, answer);
                start = DateTime.Now;
                answer = DictPerson.ContainsKey(key);
                end = (DateTime.Now - start).TotalMilliseconds;
                Console.WriteLine("Dictionary<Person, Student> key at index {0}: time in milliseconds " + end + " {1}", index, answer);
                start = DateTime.Now;
                answer = DictString.ContainsKey(key.ToString());
                end = (DateTime.Now - start).TotalMilliseconds;
                Console.WriteLine("Dictionary<string, Student> key at index {0}: time in milliseconds " + end + " {1}", index, answer);
            }

        }
    }
}
