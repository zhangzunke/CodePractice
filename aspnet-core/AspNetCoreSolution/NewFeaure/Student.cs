using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NewFeaure
{
    public class Student
    {
        public Student(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }

        public void Deconstruct(out string name, out int age)
        {
            name = Name;
            age = Age;
        }
    }

    public class ActiveUsers : IEnumerable<Student>
    {
        List<Student> users = new List<Student>();

        public void Append(Student student)
        {
            users.Add(student);
        }

        public IEnumerator<Student> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public static class ActiveUsersExtensions
    {
        public static void Add(this ActiveUsers users, Student s)
            => users.Append(s);
    }
}
