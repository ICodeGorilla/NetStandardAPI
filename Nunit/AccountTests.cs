using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Service.DTO;
using Shared.Core.Helper.Test;
using SharedLibraryCore.Controllers;

namespace NTests
{
    [TestFixture]
    public class AccountTests : BaseTests
    {
        //Given I have all the information needed to create a user
        //When I create it
        //Then I should be able to retrieve it by ID
        [Test]
        public void SaveAccountSuccessfullyTest()
        {
            //Given
            var accountController = ServiceProvider.ResolveController<AccountController>();
            var expected = GetTestingAccountDto();

            //When
            var actual = accountController.Post(expected).GetOkObjectResult<AccountDto>();
            
            //Then
            EqualityHelper.PropertyValuesAreEqual(expected, actual, new[]{ "AccountId", "LastModifiedBy", "LastModified", "Contact" });
            EqualityHelper.AssertListsAreEqual(expected.Contact, actual.Contact, new[] { "AccountId", "LastModifiedBy", "LastModified", "ContactId" });
        }

        //Given I have users in the database
        //When I retrieve all of them
        //Then I should see the one item I added in 
        [Test]
        public void GetAllAccountSuccessfullyTest()
        {
            //Given
            var accountController = ServiceProvider.ResolveController<AccountController>();
            var expected = CreateAccountForTest(accountController);

            //When
            var allAccounts = accountController.Get().GetOkObjectResult<List<AccountDto>>();

            //Then
            var actual = allAccounts.First(x => x.AccountId == expected.AccountId);
            EqualityHelper.PropertyValuesAreEqual(expected, actual, new[] { "AccountId", "LastModifiedBy", "LastModified", "Contact" });
        }

        //Given I have an account
        //When I create a new account with that information
        //Then I should receive an error
        [Test]
        public void SaveAccountWithErrorTest()
        {
            //Given
            var accountController = ServiceProvider.ResolveController<AccountController>();
            var expected = new AccountDto();

            //When -> Then
            accountController.Post(expected).CheckBadRequest();
        }

        //Given I have a saved account
        //When I retrieve it with an ID
        //Then it should match the expected item
        [Test]
        public void RetrieveAccountByIdSuccessfullyTest()
        {
            //Given
            var accountController = ServiceProvider.ResolveController<AccountController>();
            var expected = CreateAccountForTest(accountController);

            //When
            var actual = accountController.Get(expected.AccountId).GetOkObjectResult<AccountDto>();

            //Then
            EqualityHelper.PropertyValuesAreEqual(expected, actual, new[] { "Contact" });
            EqualityHelper.AssertListsAreEqual(expected.Contact, actual.Contact, new string[0]);
        }

        //Given I have a ficticious ID
        //When I retrieve it 
        //Then I should receive an error
        [Test]
        public void GetAccountByIdFailedTest()
        {
            //Given
            var accountController = ServiceProvider.ResolveController<AccountController>();

            //When -> Then
            accountController.Get(-1).CheckNotFound();
        }

        //Given I have a saved account
        //When I delete it
        //Then I should not be able to retrieve it
        [Test]
        public void DeleteAccountuccessfullyTest()
        {
            //Given
            var accountController = ServiceProvider.ResolveController<AccountController>();
            var savedAccount = CreateAccountForTest(accountController);

            //When
            accountController.Delete(savedAccount.AccountId).CheckOkResult();

            //Then
            accountController.Get(savedAccount.AccountId).CheckNotFound();
        }

        //Given I have a ficticious ID
        //When I delete it 
        //Then I should not receive an error
        [Test]
        public void DeleteAccountByIdFailedTest()
        {
            //Given
            var accountController = ServiceProvider.ResolveController<AccountController>();

            //When -> Then
            accountController.Delete(-1).CheckOkResult();
        }

        private AccountDto CreateAccountForTest(AccountController accountController)
        {
            var expected = GetTestingAccountDto();
            return accountController.Post(expected).GetOkObjectResult<AccountDto>();
        }

        private static AccountDto GetTestingAccountDto()
        {
            return new AccountDto
            {
                AccountReference = "Test Reference",
                Address = "Test address",
                CompanyName = "Test company name",
                Contact = new List<ContactDto>
                {
                    new ContactDto
                    {
                        EmailAddress = "Test@test.com",
                        Name = "Test Name"
                    }
                }
            };
        }
    }
}