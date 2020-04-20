using NUnit.Framework;

namespace AZCore.Test
{
    public class Tests
    {
        private UserService user;
        UserPermissionService t1;
        [SetUp]
        public void Setup()
        {
            var con = new MySql.Data.MySqlClient.MySqlConnection("server=127.0.0.1;database=azcore;uid=root;pwd=;CharSet=utf8;");
            this.user = new UserService(con);
            t1 = new UserPermissionService(con);
        }

        [Test]
        public void Test1()
        {
            Setup();
           var id= user.Insert(new UserModel() { Email="admin@cd.com"});
            user.Update(p => p.Status == Database.EntityStatus.NoActive ,p2=>p2.Id>1);
            user.Delete( p2 => p2.Id > 2);
            Assert.Pass();
        }
    }
}