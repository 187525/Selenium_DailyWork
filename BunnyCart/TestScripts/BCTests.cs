using BunnyCart.PageObjects;
using RedDiff;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BunnyCart.Utillities;

namespace BunnyCart.TestScripts
{
    internal class BCTests :CoreCodes

    {


        [Test]
        public void SignUpTest()
        {
            BCHP bchp = new BCHP(driver);
            bchp.ClickCreateAccount();
            //try
            //{
            //    Assert.That(driver.FindElement(By.XPath("//div[" + "@class='modal-inner-wrap']//following::h1[2]")).Text, Is.EqualTo("Create an Account"));
            //}
            //catch (AssertionException)
            //{
            //    Console.WriteLine("Create account modal not present");
            //}
            //bchp.SignUpButton("Abc", "Def", "ghi@gmail.com", "12345", "12345", "9876543210");
            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string? excelFilePath = currDir + "/TestData/InputData.xlsx";
            string? sheetName = "CreateAccount";

            List<ExcelData> excelDataList = ExcelUtilities.ReadExcelData(excelFilePath, sheetName);

            foreach (var excelData in excelDataList)
            {

                string? firstName = excelData?.FirstName;
                string? lastName = excelData?.LastName;
                string? email = excelData?.Email;
                string? pwd = excelData?.Password;
                string? conpwd = excelData?.ConfirmPassword;
                string? mbno = excelData?.MobileNumber;

                Console.WriteLine($"First Name: {firstName}, Last Name: {lastName}, Email: {email}, Password: {pwd}, Confirm Password: {conpwd}, Mobile Number: {mbno}");


                bchp.SignUpButton(firstName, lastName, email, pwd, conpwd, mbno);
                // Assert.That(""."")

            }

        }

    }


}

