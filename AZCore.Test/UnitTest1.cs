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
            this.user.FullName = "Xin cahfo";
            this.user.Email = "email.@omcm";
            this.user.PhoneNumber = "034463867";
            this.user.UserName = "haunv";
            this.user.Password = "xin chào";
            this.user.Insert().Wait();
            Assert.Pass();
        }
    }
}