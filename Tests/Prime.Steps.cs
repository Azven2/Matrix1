// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Prime.Steps.cs" company="Just">
//   (C) Steven Digby, 18 Aug 2017
// </copyright>
// <summary>
//   The prime steps.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Matrix1.Tests
{
    using NUnit.Framework;

    using TechTalk.SpecFlow;

    /// <summary>The prime steps.</summary>
    [Binding]
    public class PrimeSteps
    {
        /// <summary>The primeness.</summary>
        private readonly Primeness primeness = new Primeness();

        /// <summary>The test number.</summary>
        private int testNumber;

        /// <summary>The actual is prime.</summary>
        private bool actualIsPrime;

        /// <summary>The given a possible prime number.</summary>
        /// <param name="p">The p.</param>
        [Given(@"A possible prime number (.*)")]
        public void GivenAPossiblePrimeNumber(int p)
        {
            this.testNumber = p;
        }

        /// <summary>The when i check for primeality.</summary>
        [When(@"I check for Primeality")]
        public void WhenICheckForPrimeality()
        {
            this.actualIsPrime = this.primeness.IsPrime(this.testNumber);
        }

        /// <summary>The then the answer will be.</summary>
        /// <param name="expectedIsPrime">The expected is prime.</param>
        [Then(@"the answer will be (.*)")]
        public void ThenTheAnswerWillBe(bool expectedIsPrime)
        {
            Assert.AreEqual(this.actualIsPrime, expectedIsPrime);
        }
    }
}
