using System;
using System.Collections.Generic;
using System.Text;

namespace Builder
{
    public class PersonFacadeBuilder
    {
        protected  Person person =  new Person();

        public PersonJobFacadeBuilder Works => new PersonJobFacadeBuilder(person);
        public PersonAddressBuilder Lives => new PersonAddressBuilder(person);

        public static implicit operator Person(PersonFacadeBuilder personFacadeBuilder)
        {
            return personFacadeBuilder.person;
        }
    }

    public class PersonAddressBuilder : PersonFacadeBuilder
    {
        public PersonAddressBuilder(Person person)
        {
            this.person = person;
        }

        public PersonAddressBuilder Street(string street)
        {
            person.Street = street;
            return this;
        }
    }

    public class PersonJobFacadeBuilder : PersonFacadeBuilder
    {
        public PersonJobFacadeBuilder(Person person)
        {
            this.person = person;
        }

        public PersonJobFacadeBuilder At(string companyName)
        {
            person.CompanyName = companyName;
            return this;
        }

        public PersonJobFacadeBuilder AsA(string position)
        {
            person.Position = position;
            return this;
        }

        public PersonJobFacadeBuilder Earning(int amount)
        {
            person.AnnualIncome = amount;
            return this;
        }
    }
}
