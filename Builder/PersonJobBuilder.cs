using System;
using System.Collections.Generic;
using System.Text;

namespace Builder.Fluent
{
    


    public abstract class PersonFluentBuilder
    {
        protected Person person = new Person();

        public Person Build()
        {
            return person;
        }
    }

    public class PersonInfoBuilder<SELF> : PersonFluentBuilder where SELF : PersonInfoBuilder<SELF>
    {
        protected Person person = new Person();

        public SELF Called(string name)
        {
            person.Name = name;
            return (SELF)this;
        }
    }

    public class PersonJobBuilder<SELF> : PersonInfoBuilder<PersonJobBuilder<SELF>> where SELF : PersonJobBuilder<SELF>
    {
        public SELF WorksAsA(string position)
        {
            person.Position = position;
            return (SELF)this;
        }
    }
}
