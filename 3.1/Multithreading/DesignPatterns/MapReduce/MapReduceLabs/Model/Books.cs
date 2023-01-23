using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bogus;

namespace MapReduceLabs.Model
{
    internal class Books
    {
        public long Id { get; set; }
        public String Name { get; set; }
        public BooksEnum.CategoryEnum Category { get; set; }

        public static IEnumerable<Books> CreateListFake()
        {
            var category = new[] { BooksEnum.CategoryEnum.Technology, BooksEnum.CategoryEnum.Bussiness, BooksEnum.CategoryEnum.Romance };

            var orderIds = 0;
            var testOrders = new Faker<Books>()
                //Ensure all properties have rules. By default, StrictMode is false
                //Set a global policy by using Faker.DefaultStrictMode
                .StrictMode(true)
                //OrderId is deterministic
                .RuleFor(o => o.Id, _ => orderIds++)
                //Pick some fruit from a basket
                .RuleFor(o => o.Category, f => f.PickRandom(category))
                //A random quantity from 1 to 10
                .RuleFor(o => o.Name, f => f.Lorem.Paragraph());

            return testOrders.Generate(1000).ToList<Books>();
        }
    }
    public static class BooksEnum
    {
        public enum CategoryEnum
        {
            Technology = 1,
            Bussiness = 2,
            Romance = 3,
        }
    }
}
