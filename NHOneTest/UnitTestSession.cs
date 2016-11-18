using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHOne.Util;
using NHibernate;
using NHOne.Model;

namespace NHOneTest
{
    [TestClass]
    public class UnitTestSession
    {
        [TestMethod]
        public void TestMethodUser()
        {
            User user = new User();
            user.Username = "zhangsan";
            user.Password = "zhangsan123";
            user.Gender = 'M';
            user.Phone = "12345678";
            user.Age = 24;

            Console.WriteLine(user);

            
        }

        [TestMethod]
        public void TestSessionFactory()
        {
            ISessionFactory sessionFactory =  YangNHibernate.getSessionFactory();
            Assert.IsNotNull(sessionFactory);
        }

        [TestMethod]
        public void TestSession()
        {
            ISession session = YangNHibernate.getSession();
            Assert.IsNotNull(session);
            session.Close();
        }



        [TestMethod]
        public void TestSaveUser()
        {
            User user = createUser();
            ISession session  = YangNHibernate.getSession();

            ITransaction tx = session.BeginTransaction();
            session.Save(user);
            tx.Commit();

            session.Close();
        
        }



        private User createUser()
        {
            User user = new User();
            user.Username = "zhangsan";
            user.Password = "zhangsan123";
            user.Gender = 'M';
            user.Phone = "12345678";
            user.Age = 24;

            return user;
        }
    }
}
