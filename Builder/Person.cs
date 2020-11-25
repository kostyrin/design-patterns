using System;
using System.Collections.Generic;
using System.Text;
using Builder.Fluent;

namespace Builder
{
    public class Person
    {
        public string Name { get; set; }
        public string Position { get; set; }

        public string Street, Postcode, City;

        public string CompanyName;

        public int AnnualIncome;
        //public class Builder : PersonJobBuilder<Builder>
        //{

        //}

        //public static Builder New => new Builder();
    }
}
