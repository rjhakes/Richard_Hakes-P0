using System;
using Xunit;
using StoreModels;

namespace StoreTests
{
    public class CustomerModelTests
    {
        Customer testCustomer = new Customer();
        
        [Fact]
        public void CustomerNameShouldBeSet()
        {
            string testName = "John Deer";
            //Act
            testCustomer.CustName = testName;
            //Assert
            Assert.Equal(testName, testCustomer.CustName);
        }

        [Thheory]

        
    }
}
