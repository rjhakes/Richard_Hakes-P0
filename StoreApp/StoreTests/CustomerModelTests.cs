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

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void CustomerNameShouldNotBeEmpty(string testName) 
        {
            //Act and Assert
            Assert.Throws<ArgumentNullException>(() => testCustomer.CustName = testName);
        }

    }
}
