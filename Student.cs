using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace Lab
{
    [Serializable]
    class Student : Person, IDateAndCopy
    {
        public Person Person
        {
            get => new Person(FirstName, Surname, DateOfBirth);
            set => Person = value;
        }
        
        private Education education;

        public Education Education
        {
            get => education;
            set => education = value;
        }

        private int numberOfGroup;

        public int NumberOfGroup
        {
            get => numberOfGroup;
            set 
            {
                if(value <= 100 && value >= 699)
                {
                    throw new Exception("The number of group must be 100 to 699!");
                }
                else
                {
                    numberOfGroup = value;
                }
            }
        }

        private List<Exam> exams = new List<Exam>();

        public List<Exam> Exams
        {
            get => exams;
            set => exams = value;
        }

        private List<Test> tests = new List<Test>();

        public List<Test> Tests
        {
            get => tests;
            set => tests = value;
        }

        public Student(string firstName, string surname, DateTime dateOfBirth, Education education, int numberOfGroup, List<Exam> exams, List<Test> tests):base(firstName, surname, dateOfBirth)
        {
            Education = education;
            NumberOfGroup = numberOfGroup;
            Exams = exams;
            Tests = tests;
        }

        public Student() : base()
        {
            Education = Education.SecondEducation;
            NumberOfGroup = 1;
            Exam ex = new Exam();
            exams.Add(ex);
            Test t = new Test();
            tests.Add(t);
        }

        public double AverageValue
        {
            get
            {
                double sum = 0;
                foreach (Exam x in exams)
                {
                    sum += x.mark;
                }
                return sum / exams.Count;

            }

        }

        public bool this[Education education]
        {
            get
            {
                return education == Education;
            }
        }

        public void AddExams(params Exam[] exams)
        {
            for (int i = 0; i < exams.Length; i++)
            {
                this.exams.Add(exams[i]);
            }
        }

        public override string ToString()
        {
            string str;
            str = base.ToString() + " " + Education + " " + NumberOfGroup;
            foreach (Exam ex in Exams)
            {
                str += " " + ex.ToString();
            }
            foreach (Test t in Tests)
            {
                str += " " + t.ToString();
            }
            return str;
        }

        public override string ToShortString()
        {
            return base.ToString() + " " + Education + " " + NumberOfGroup + " " + AverageValue;
        }

        public override bool Equals(object obj)
        {
            return obj is Student student && 
                   education == student.education &&
                   numberOfGroup == student.numberOfGroup &&
                   EqualityComparer<List<Exam>>.Default.Equals(exams, student.exams) &&
                   EqualityComparer<List<Test>>.Default.Equals(tests, student.tests);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(education, numberOfGroup, exams, tests);
        }

        public static bool operator ==(Student left, Student right)
        {
            return EqualityComparer<Student>.Default.Equals(left, right);
        }

        public static bool operator !=(Student left, Student right)
        {
            return !(left == right);
        }

        public Student DeepCopy(Student st)
        {
            if (st is Person serialisedObject)
            {
                using (MemoryStream ms = new MemoryStream())
                {   
                    BinaryFormatter form = new BinaryFormatter();
                    try 
                    {
                        form.Serialize(ms, st);
                        ms.Position = 0;
                        return (Student)form.Deserialize(ms);
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception);
                    }
                    finally
                    {
                        ms.Close();
                    }
                }

            }
            throw new ArgumentException($"I cannot convert { nameof(serialisedObject) } to Student");
        }

        public IEnumerable GetExamsAndTests()
        {
            foreach (Exam ex in Exams)
            {
                yield return ex;

            }
            foreach (Test t in Tests)
            {
                yield return t;

            }
        }

        public IEnumerable GetExams(int mark)
        {
            foreach (Exam ex in Exams)
            {
                if (ex.mark > mark)
                {
                    yield return ex;
                }
            }
        }
        public bool Save(string filename)
        {
            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, this.ToString());
                    fs.Close();
                }
                return true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return false;
            }
        }
        public bool Load(string filename)
        {
            try
            {
                using (FileStream fs = File.OpenRead(filename))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    Student st = (Student)formatter.Deserialize(fs);
                    this.FirstName = st.FirstName;
                    this.Surname = st.Surname;
                    this.DateOfBirth = st.DateOfBirth;
                    this.NumberOfGroup = st.NumberOfGroup;
                    this.Education = st.Education;
                    this.Exams = st.Exams;
                    this.Tests = st.Tests;
                    fs.Close();
                }
                return true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return false;
            }
        }
        public static bool Save(string filename, Student st)
        {
            return st.Save(filename);
        }
        public static bool Load(string filename, Student st)
        {
            return st.Load(filename);
        }
        public bool AddFromConsole()
        {
            Console.WriteLine("Hello. Enter the exam information for this example:");
            Console.WriteLine("Exam name,4,02/12/2020");
            string[] data = Console.ReadLine().Split(',');
            try
            {
                if (data.Length != 3) throw new Exception("The information was entered incorrectly!");

                AddExams(new Exam(data[0], int.Parse(data[1]), DateTime.Parse(data[2])));
                return true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return false;
            }
        }

    }
}
