﻿using System;
using NUnit.Framework;
using CurrencyCloud.Entity;
using CurrencyCloud.Tests.Mock.Data;
using CurrencyCloud.Entity.Pagination;
using CurrencyCloud.Tests.Mock.Http;
using CurrencyCloud.Environment;
using System.Threading.Tasks;

namespace CurrencyCloud.Tests
{
    [TestFixture]
    class IbansTest
    {
        Client client = new Client();
        Player player = new Player("../../Mock/Http/Recordings/Ibans.json");

        [OneTimeSetUpAttribute]
        public void SetUp()
        {
            player.Start(ApiServer.Mock.Url);
            player.Play("SetUp");

            var credentials = Authentication.Credentials;

            client.InitializeAsync(Authentication.ApiServer, credentials.LoginId, credentials.ApiKey).Wait();
        }

        [OneTimeTearDownAttribute]
        public void TearDown()
        {
            player.Play("TearDown");

            client.CloseAsync().Wait();

            player.Close();
        }

        /// <summary>
        /// Successfully finds IBANS.
        /// </summary>
        [Test]
        public async Task Find()
        {
            player.Play("Find");

            var iban = Ibans.Iban1;

            PaginatedIbans found = await client.FindIbansAsync(new IbanFindParameters
            {
                Currency = iban.Currency
            });

            Console.WriteLine("Found: " + found.Ibans[0]);

            Assert.AreEqual(iban.Id, found.Ibans[0].Id);
            Assert.AreEqual(iban.IbanCode, found.Ibans[0].IbanCode);
            Assert.AreEqual(iban.AccountId, found.Ibans[0].AccountId);
            Assert.AreEqual(iban.Currency, found.Ibans[0].Currency);
            Assert.AreEqual(iban.AccountHolderName, found.Ibans[0].AccountHolderName);
            Assert.AreEqual(iban.BankInstitutionName, found.Ibans[0].BankInstitutionName);
            Assert.AreEqual(iban.BankInstitutionAddress, found.Ibans[0].BankInstitutionAddress);
            Assert.AreEqual(iban.BankInstitutionCountry, found.Ibans[0].BankInstitutionCountry);
            Assert.AreEqual(iban.BicSwift, found.Ibans[0].BicSwift);
        }

        /// <summary>
        /// Successfully finds sub-account IBANs.
        /// </summary>
        [Test]
        public async Task FindSubAccountsIbans()
        {
            player.Play("FindSubAccountsIbans");

            var iban = Ibans.Iban1;

            PaginatedIbans found = await client.FindSubAccountsIbansAsync(new IbanFindParameters());

            Console.WriteLine("Found: " + found.Ibans[0]);

            Assert.AreEqual(iban.Id, found.Ibans[0].Id);
            Assert.AreEqual(iban.IbanCode, found.Ibans[0].IbanCode);
            Assert.AreEqual(iban.AccountId, found.Ibans[0].AccountId);
            Assert.AreEqual(iban.Currency, found.Ibans[0].Currency);
            Assert.AreEqual(iban.AccountHolderName, found.Ibans[0].AccountHolderName);
            Assert.AreEqual(iban.BankInstitutionName, found.Ibans[0].BankInstitutionName);
            Assert.AreEqual(iban.BankInstitutionAddress, found.Ibans[0].BankInstitutionAddress);
            Assert.AreEqual(iban.BankInstitutionCountry, found.Ibans[0].BankInstitutionCountry);
            Assert.AreEqual(iban.BicSwift, found.Ibans[0].BicSwift);
        }

        /// <summary>
        /// Successfully gets sub-account IBANs.
        /// </summary>
        [Test]
        public async Task GetSubAccountsIbans()
        {
            player.Play("GetSubAccountsIbans");

            var iban = Ibans.Iban1;

            PaginatedIbans found = await client.GetSubAccountsIbansAsync(iban.Id);

            Console.WriteLine("Found: " + found.Ibans[0]);

            Assert.AreEqual(iban.Id, found.Ibans[0].Id);
            Assert.AreEqual(iban.IbanCode, found.Ibans[0].IbanCode);
            Assert.AreEqual(iban.AccountId, found.Ibans[0].AccountId);
            Assert.AreEqual(iban.Currency, found.Ibans[0].Currency);
            Assert.AreEqual(iban.AccountHolderName, found.Ibans[0].AccountHolderName);
            Assert.AreEqual(iban.BankInstitutionName, found.Ibans[0].BankInstitutionName);
            Assert.AreEqual(iban.BankInstitutionAddress, found.Ibans[0].BankInstitutionAddress);
            Assert.AreEqual(iban.BankInstitutionCountry, found.Ibans[0].BankInstitutionCountry);
            Assert.AreEqual(iban.BicSwift, found.Ibans[0].BicSwift);
        }
    }
}
