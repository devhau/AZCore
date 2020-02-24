using NUnit.Framework;

namespace AZCore.Test
{
    public class Tests
    {
        private AZUser user;
        [SetUp]
        public void Setup()
        {
            this.user = new AZUser(new MySql.Data.MySqlClient.MySqlConnection("server=127.0.0.1;database=viec1.com;uid=root;pwd=;"));
        }

        [Test]
        public void Test1()
        {
            Setup();
            this.user.CreateTableIfNotExitAsync().Wait();
            this.user.Id = 1;
            this.user.FullName = "22333";
            this.user.Email = "2222email.@omcm";
            this.user.PhoneNumber = "2234463867";
            this.user.UserName = "22haunv";
            this.user.Password = "22xin chào";
            this.user.Update().Wait();
            Assert.Pass();
        }
    }
}