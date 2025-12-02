using AdventOfCode.Elves.IOHelpers;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2025.Tests
{
    internal class DayTwoTests
    {
        [TestCase("12")]
        [TestCase("23")]
        [TestCase("34")]
        [TestCase("341")]
        [TestCase("34534")]
        public void IDValidityChecker_Should_Declare_Valid_ID_As_Valid(string id)
        {
            IDValidityChecker checker = new IDValidityChecker();

            checker.Check(id).Should().BeTrue();
        }

        [TestCase("11")]
        [TestCase("3232")]
        [TestCase("123123")]
        public void IDValidityChecker_Should_Detect_Invalid_IDs(string id)
        {
            IDValidityChecker checker = new IDValidityChecker();

            checker.Check(id).Should().BeFalse();
        }

        [Test]
        public void IDCrawler_Should_Check_All_IDs_In_Small_Range()
        {
            Mock<IIDValidityChecker> mockChecker = new Mock<IIDValidityChecker>();
            IDCrawler crawler = new IDCrawler(mockChecker.Object);

            crawler.Crawl("11-12");

            mockChecker.Verify(m => m.Check("11"), Times.Once);
            mockChecker.Verify(m => m.Check("12"), Times.Once);
        }

        [Test]
        public void IDCrawler_Should_Check_All_IDs_In_Medium_Range()
        {
            Mock<IIDValidityChecker> mockChecker = new Mock<IIDValidityChecker>();
            IDCrawler crawler = new IDCrawler(mockChecker.Object);

            crawler.Crawl("11-16");

            mockChecker.Verify(m => m.Check("11"), Times.Once);
            mockChecker.Verify(m => m.Check("12"), Times.Once);
            mockChecker.Verify(m => m.Check("13"), Times.Once);
            mockChecker.Verify(m => m.Check("14"), Times.Once);
            mockChecker.Verify(m => m.Check("15"), Times.Once);
            mockChecker.Verify(m => m.Check("16"), Times.Once);
        }

        [Test]
        public void IDCrawler_Should_Check_All_IDs_In_Large_Range()
        {
            Mock<IIDValidityChecker> mockChecker = new Mock<IIDValidityChecker>();
            IDCrawler crawler = new IDCrawler(mockChecker.Object);

            crawler.Crawl("96-110");

            mockChecker.Verify(m => m.Check("96"), Times.Once);
            mockChecker.Verify(m => m.Check("97"), Times.Once);
            mockChecker.Verify(m => m.Check("98"), Times.Once);
            mockChecker.Verify(m => m.Check("99"), Times.Once);
            mockChecker.Verify(m => m.Check("100"), Times.Once);
            mockChecker.Verify(m => m.Check("101"), Times.Once);
            mockChecker.Verify(m => m.Check("102"), Times.Once);
            mockChecker.Verify(m => m.Check("103"), Times.Once);
            mockChecker.Verify(m => m.Check("104"), Times.Once);
            mockChecker.Verify(m => m.Check("105"), Times.Once);
            mockChecker.Verify(m => m.Check("106"), Times.Once);
            mockChecker.Verify(m => m.Check("107"), Times.Once);
            mockChecker.Verify(m => m.Check("108"), Times.Once);
            mockChecker.Verify(m => m.Check("109"), Times.Once);
            mockChecker.Verify(m => m.Check("110"), Times.Once);
        }

        [Test]
        public void IDCrawler_Should_Return_All_Invalid_IDs_In_Range()
        {
            IDCrawler crawler = new IDCrawler(new IDValidityChecker());

            var result = crawler.Crawl("11-22");

            result.Should().BeEquivalentTo(new List<int> { 11, 22 });
        }
    }
}
