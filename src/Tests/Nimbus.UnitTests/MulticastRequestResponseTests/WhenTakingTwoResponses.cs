using System;
using System.Linq;
using NUnit.Framework;
using Shouldly;

namespace Nimbus.UnitTests.MulticastRequestResponseTests
{
    [TestFixture]
    internal class WhenTakingTwoResponses : GivenAWrapperWithTwoResponses
    {
        private readonly TimeSpan _timeout = TimeSpan.FromSeconds(1);

        private string[] _result;

        protected override void When()
        {
            _result = Subject.ReturnResponsesOpportunistically(_timeout).Take(2).ToArray();
        }

        [Test]
        public void TheElapsedTimeShouldBeLessThanTheTimeout()
        {
            ElapsedTime.ShouldBeLessThan(_timeout);
        }

        [Test]
        public void ThereShouldBeTwoResults()
        {
            _result.Count().ShouldBe(2);
        }
    }
}