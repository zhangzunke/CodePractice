using System;
using System.Collections.Generic;
using System.Text;

namespace NewFeaure
{
    public class User
    {
        private string _name;

        public User(string name) => _name = name;

        public string Name
        {
            get => _name;
            set => _name = value;
        }

    }
}
