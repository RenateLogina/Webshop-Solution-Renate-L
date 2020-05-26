using System;
using System.Linq;
using WebShop.Logic;
using Xunit;

namespace WebShop.Tests
{
    public class UserTests
    {
        [Fact]
        public void TestCreateUser()
        {
            string mail = GetRandomText();
            //tests jāvar izsaukt vairākkārt, tāpēc īpašības ir jāģenerē
            UserManager.Create("testname", mail, "testpass");

            var user = UserManager.GetByEmail(mail);

            //ja asertācija ir pareiza -> tests veiksmīgs
            Assert.NotNull(user);
            Assert.Equal(user.Email, mail);

        }
        [Fact]
        public void TestCreateItem()
        {
            string name = GetRandomText();
            var random = new Random();
            int categoryId = random.Next(CategoryManager.GetAll().Count);
            ItemManager.Create(name, "testdescription", "testimage", categoryId, 5);

            var item = ItemManager.GetAll().FirstOrDefault(c => c.Name == name);
            Assert.NotNull(item);
            Assert.Equal(item.Name, name);
        }

        [Fact]
        public void TestGetuser()
        {
            string mail = GetRandomText();
            string password = "testpass";
            UserManager.Create("testname",mail, password);

            var user = UserManager.GetByEmailAndPassword(mail, password);
            Assert.NotNull(user);
            Assert.Equal(user.Email, mail);
            Assert.Equal(user.Password, password);
        }

        public static string GetRandomText()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 8);
            // lai nav strīpiņas. Substring- ieraksta garums
        }
    }
}
