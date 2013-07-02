using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectBindingDemo.ViewModels;

namespace ObjectBindingDemo.Tests
{
    [TestClass]
    public class SalaryCalculatorTests
    {
        [TestMethod]
        public void IsCalculatable_Is_False_By_Default()
        {
            //Arrange
            var sut = new SalaryCalculatorViewModel();
            //Act

            //Assert
            Assert.IsFalse(sut.IsSalaryCalculatable);
        }
        [TestMethod]
        public void IsCalculatable_Is_False_When_Basic_is_Zero()
        {
            //Arrange
            var sut = new SalaryCalculatorViewModel();

            //Act
            sut.Basic = 0;

            //Assert
            Assert.IsFalse(sut.IsSalaryCalculatable);
        }

        [TestMethod]
        public void IsCalculatable_Is_True_When_All_Three_Salary_Components_Are_Non_Zero()
        {
            //Arrange
            var sut = new SalaryCalculatorViewModel();

            //Act
            sut.Basic = sut.Hra = sut.Da = 10000;
            sut.Tax = 10;

            //Assert
            Assert.IsTrue(sut.IsSalaryCalculatable);
        }
    }
}
