// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MatrixTests.Steps.cs" company="Azven.com">
//   (C) Steven Digby
// </copyright>
// <summary>
//   The matrix tests steps.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Matrix1.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    using NUnit.Framework;

    using TechTalk.SpecFlow;

    /// <summary>The matrix tests steps.</summary>
    [Binding]
    public class MatrixTestsSteps
    {
        /// <summary>The example matrix.</summary>
        private double[,] exampleMatrix1;

        /// <summary>The example matrix 2.</summary>
        private double[,] exampleMatrix2;

        /// <summary>The example string matrix.</summary>
        private string exampleStringMatrix;

        /// <summary>The actual matrix.</summary>
        private double[,] actualMatrix;

        /// <summary>The actual boolean result.</summary>
        private bool? actualBooleanResult;

        /// <summary>The actual value.</summary>
        private double actualDoubleResult;

        /// <summary>The root matrix 1.</summary>
        private List<double[,]> actualRootMatrices = new List<double[,]>();

        /// <summary>The actual eigen vectors.</summary>
        private List<double[,]> actualEigenVectors = new List<double[,]>();

        /// <summary>The actual eigen values.</summary>
        private List<double> actualEigenValues = new List<double>();

        /// <summary>The triangular type.</summary>
        private MatrixExtensions.TriangularType triangularType;

        /// <summary>Given the following matrix.</summary>
        /// <param name="exampleMatrixTable">The example matrix table.</param>
        [Given(@"The following matrix")]
        public void GivenTheFollowingMatrix(Table exampleMatrixTable)
        {
            this.exampleMatrix1 = ConvertTableToMatrix(exampleMatrixTable);
        }

        /// <summary>Given another matrix.</summary>
        /// <param name="exampleMatrixTable">The example matrix table.</param>
        [Given(@"another matrix")]
        public void GivenAnotherMatrix(Table exampleMatrixTable)
        {
            this.exampleMatrix2 = ConvertTableToMatrix(exampleMatrixTable);
        }

        /// <summary>Given the index is.</summary>
        /// <param name="index">The index.</param>
        [Given(@"the index is (.*)")]
        public void GivenTheIndexIs(double index)
        {
            this.actualDoubleResult = index;
        }

        /// <summary>Given the string.</summary>
        /// <param name="matrix">The matrix.</param>
        [Given(@"The string ""(.*)""")]
        public void GivenTheString(string matrix)
        {
            this.exampleStringMatrix = matrix;
        }

        /// <summary>When i transpose the matrix.</summary>
        [When(@"I transpose the matrix")]
        public void WhenITransposeTheMatrix()
        {
            this.actualMatrix = this.exampleMatrix1.Transpose();
        }

        /// <summary>When i compare the matrices for equality.</summary>
        [When(@"I compare the matrices for equality")]
        public void WhenICompareTheMatricesForEquality()
        {
            this.actualBooleanResult = this.exampleMatrix1.IsEqual(this.exampleMatrix2);
        }

        /// <summary>When i compare the matrix to matrix.</summary>
        /// <param name="matrixType">The matrix type.</param>
        [When(@"I compare the matrix to (.*) matrix")]
        public void WhenICompareTheMatrixToMatrix(string matrixType)
        {
            // matrixType = "a zero" / "an identity"
            this.exampleMatrix2 = matrixType == "a zero" ? this.exampleMatrix1.ZeroMatrix() : this.exampleMatrix1.IdentityMatrix();

            this.actualBooleanResult = this.exampleMatrix1.IsEqual(this.exampleMatrix2);
        }

        /// <summary>When i look_ up element row column.</summary>
        /// <param name="row">The row.</param>
        /// <param name="column">The column.</param>
        [When(@"I look-up element row (.*), column (.*)")]
        public void WhenILookUpElementRowColumn(int row, int column)
        {
            this.actualDoubleResult = this.exampleMatrix1.GetElement(row - 1, column - 1);
        }

        /// <summary>When i add the two matrices.</summary>
        [When(@"I add the two matrices")]
        public void WhenIAddTheTwoMatrices()
        {
            this.actualMatrix = this.exampleMatrix1.AddMatrix(this.exampleMatrix2);
        }

        /// <summary>When i subtract the second matrix from the first.</summary>
        [When(@"I subtract the second matrix from the first")]
        public void WhenISubtractTheSecondMatrixFromTheFirst()
        {
            this.actualMatrix = this.exampleMatrix1.SubtractMatrix(this.exampleMatrix2);
        }

        /// <summary>When i multiply the first matrix by the constant.</summary>
        /// <param name="constant">The constant.</param>
        [When(@"I multiply the first matrix by the constant (.*)")]
        public void WhenIMultiplyTheFirstMatrixByTheConstant(double constant)
        {
            this.actualMatrix = this.exampleMatrix1.MultiplyMatrixByConstant(constant);
        }

        /// <summary>When i multiply the first matrix by the second.</summary>
        [When(@"I multiply the first matrix by the second")]
        public void WhenIMultiplyTheFirstMatrixByTheSecond()
        {
            this.actualMatrix = this.exampleMatrix1.MultiplyMatrix(this.exampleMatrix2);
        }

        /// <summary>When i extract the submatrix of row column.</summary>
        /// <param name="row">The row.</param>
        /// <param name="column">The column.</param>
        [When(@"I extract the submatrix of row (.*) column (.*)")]
        public void WhenIExtractTheSubmatrixOfRowColumn(int row, int column)
        {
            this.actualMatrix = this.exampleMatrix1.SubMatrix(row - 1, column - 1);
        }

        /// <summary>When i negate the matrix.</summary>
        [When(@"I negate the matrix")]
        public void WhenINegateTheMatrix()
        {
            this.actualMatrix = this.exampleMatrix1.Negate();
        }

        /// <summary>When i extract the minor matrix of column.</summary>
        /// <param name="column">The column.</param>
        [When(@"I extract the minor matrix of column (.*)")]
        public void WhenIExtractTheMinorMatrixOfColumn(int column)
        {
            this.actualMatrix = this.exampleMatrix1.MinorMatrix(column - 1);
        }

        /// <summary>When i calculate the determinant.</summary>
        [When(@"I calculate the determinant")]
        public void WhenICalculateTheDeterminant()
        {
            this.actualDoubleResult = this.exampleMatrix1.Determinant();
        }

        /// <summary>When i calculate the cofactor matrix.</summary>
        [When(@"I calculate the cofactor matrix")]
        public void WhenICalculateTheCofactorMatrix()
        {
            this.actualMatrix = this.exampleMatrix1.CoFactorMatrix();
        }

        /// <summary>When i calculate the adjunct matrix.</summary>
        [When(@"I calculate the adjunct matrix")]
        public void WhenICalculateTheAdjunctMatrix()
        {
            this.actualMatrix = this.exampleMatrix1.Adjunct();
        }

        /// <summary>When i calculate the inverse matrix.</summary>
        [When(@"I calculate the inverse matrix")]
        public void WhenICalculateTheInverseMatrix()
        {
            this.actualMatrix = this.exampleMatrix1.InverseMatrix();
        }

        /// <summary>When i get the lowest term matrix.</summary>
        [When(@"I get the lowest term matrix")]
        public void WhenIGetTheLowestTermMatrix()
        {
            this.actualMatrix = this.exampleMatrix1.ReduceMatrixToLowestTerms(out this.actualDoubleResult);
        }

        /// <summary>When i get the eigen value.</summary>
        [When(@"I get the Eigen value")]
        public void WhenIGetTheEigenValue()
        {
            var ev = this.exampleMatrix1.EigenValues2X2();

            this.actualEigenValues.AddRange(ev);
        }

        /// <summary>When i get the eigen vectors.</summary>
        [When(@"I get the Eigen vectors")]
        public void WhenIGetTheEigenVectors()
        {
            var ev = this.exampleMatrix1.EigenVectors2X2();

            this.actualEigenVectors.AddRange(ev);
        }

        /// <summary>When i raise the matrix to the power of.</summary>
        /// <param name="index">The index.</param>
        [When(@"I raise the matrix to the power of (.*)")]
        public void WhenIRaiseTheMatrixToThePowerOf(double index)
        {
            this.actualMatrix = this.exampleMatrix1.Pow(index);
        }

        /// <summary>When i divide the first matrix by the second.</summary>
        [When(@"I divide the first matrix by the second")]
        public void WhenIDivideTheFirstMatrixByTheSecond()
        {
            this.actualMatrix = this.exampleMatrix1.DivideMatrix(this.exampleMatrix2)[0];
        }

        /// <summary>When check to see if the matrix is.</summary>
        /// <param name="checker">The checker.</param>
        [When(@"check to see if the matrix is (.*)")]
        public void WhenCheckToSeeIfTheMatrixIs(string checker)
        {
            switch (checker.ToLower())
            {
                case "diagonal":
                    this.actualBooleanResult = this.exampleMatrix1.IsDiagonal();
                    break;
                case "involution":
                    this.actualBooleanResult = this.exampleMatrix1.IsInvolutionMatrix();
                    break;
                case "scalar":
                    this.actualBooleanResult = this.exampleMatrix1.IsScalarMatrix();
                    break;
                case "nilpotent for all":
                    this.actualBooleanResult = this.exampleMatrix1.IsNilPotent();
                    break;
                case "nilpotent":
                    this.actualBooleanResult = this.exampleMatrix1.IsNilPotentForSpecifiedIndex((int)this.actualDoubleResult);
                    break;
                case "triangular":
                    this.triangularType = this.exampleMatrix1.IsTriangularMatrix();
                    break;
                default:
                    Assert.Fail();
                    break;
            }
        }

        /// <summary>When i get the trace of the matrix.</summary>
        [When(@"I get the trace of the matrix")]
        public void WhenIGetTheTraceOfTheMatrix()
        {
            this.actualDoubleResult = this.exampleMatrix1.Trace();
        }

        /// <summary>When i join the matrix to an identity matrix.</summary>
        [When(@"I join the matrix to an identity matrix")]
        public void WhenIJoinTheMatrixToAnIdentityMatrix()
        {
            this.actualMatrix = this.exampleMatrix1.JoinMatrixToIdentity();
        }

        /// <summary>When i extract a matrix.</summary>
        /// <param name="ordinal">The ordinal.</param>
        [When(@"I extract a (.*) matrix")]
        public void WhenIExtractAMatrix(string ordinal)
        {
            switch (ordinal.ToLower())
            {
                case "left":
                    this.actualMatrix = this.exampleMatrix1.LeftMatrix();  
                    break;
                case "right":
                    this.actualMatrix = this.exampleMatrix1.RightMatrix();
                    break;
                default:
                    Assert.Fail();
                    break;
            }
        }

        /// <summary>When i convert the string to a matrix.</summary>
        [When(@"I convert the string to a matrix")]
        public void WhenIConvertTheStringToAMatrix()
        {
            this.actualMatrix = this.exampleStringMatrix.ConvertStringToMatrix();
        }

        /// <summary>When i calculate the square roots of the matrix.</summary>
        [When(@"I calculate the square roots of the matrix")]
        public void WhenICalculateTheSquareRootsOfTheMatrix()
        {
            this.actualRootMatrices.Clear();
            this.actualRootMatrices.AddRange(this.exampleMatrix1.SquareRoots());
        }

        /// <summary>When i calculate the rref.</summary>
        [When(@"I calculate the RREF")]
        public void WhenICalculateTheRref()
        {
            // RREF = Reduced Row Echelon Form
            this.actualMatrix = this.exampleMatrix1.ReducedRowEchelonForm();
        }

        /// <summary>The when i augment the matrix with the following vector.</summary>
        /// <param name="vectorTable">The vector table.</param>
        [When(@"I augment the matrix with the following vector")]
        public void WhenIAugmentTheMatrixWithTheFollowingVector(Table vectorTable)
        {
            var vector = ConvertTableToMatrix(vectorTable);

            this.exampleMatrix1 = this.exampleMatrix1.AugmentMatrix(vector);
        }

        /// <summary>The when i find highest magnitude element in the matrix.</summary>
        [When(@"I Find Highest magnitude Element In the Matrix")]
        public void WhenIFindHighestMagnitudeElementInTheMatrix()
        {
            this.actualDoubleResult = this.exampleMatrix1.FindHighestElementInMatrix();
        }
         
        /// <summary>Then the result will be.</summary>
        /// <param name="expectedBooleanResult">The expected boolean result.</param>
        [Then(@"the result will be (.*)")]
        public void ThenTheResultWillBe(bool expectedBooleanResult)
        {
            Assert.AreEqual(this.actualBooleanResult, expectedBooleanResult);
        }

        /// <summary>Then the result should be.</summary>
        /// <param name="expectedMatrixTable">The expected matrix table.</param>
        [Then(@"the result should be")]
        public void ThenTheResultShouldBe(Table expectedMatrixTable)
        {
            var expectedMatrix = ConvertTableToMatrix(expectedMatrixTable);

            var bResult = expectedMatrix.IsEqual(this.actualMatrix);

            Assert.IsTrue(bResult);
        }

        /// <summary>Then the result is.</summary>
        /// <param name="expectedValue">The expected value.</param>
        [Then(@"the result is (.*)")]
        public void ThenTheResultIs(double expectedValue)
        {
            Assert.AreEqual(expectedValue, this.actualDoubleResult);
        }

        /// <summary>Then the resulting matrix an identity matrix.</summary>
        /// <param name="condition">The condition.</param>
        [Then(@"the resulting matrix (.*) an identity matrix")]
        public void ThenTheResultingMatrixAnIdentityMatrix(string condition)
        {
            this.exampleMatrix2 = this.actualMatrix.IdentityMatrix();

            var bResult = this.actualMatrix.IsEqual(this.exampleMatrix2);

            // condition = "will be" / "will not be"
            switch (condition)
            {
                case "will be":
                    Assert.IsTrue(bResult);
                    break;
                case "will not be":
                    Assert.IsFalse(bResult);
                    break;
                default:
                    Assert.Fail();
                    break;
            }
        }

        /// <summary>Then the eigen values are and.</summary>
        /// <param name="expectedEigenValue1">The expected eigen value 1.</param>
        /// <param name="expectedEigenValue2">The expected eigen value 2.</param>
        [Then(@"the Eigen values are (.*) and (.*)")]
        public void ThenTheEigenValuesAreAnd(double expectedEigenValue1, double expectedEigenValue2)
        {
            Assert.IsTrue(this.actualEigenValues.Contains(expectedEigenValue1));
            
            Assert.IsTrue(this.actualEigenValues.Contains(expectedEigenValue2));
        }

        /// <summary>Then the eigen vectorTable is.</summary>
        /// <param name="tableVector">The table vectorTable.</param>
        [Then(@"the Eigen vector is")]
        [Then(@"the other vector is")]
        public void ThenTheEigenVectorIs(Table tableVector)
        {
            var expectedVector = ConvertTableToMatrix(tableVector);

            var vectorFound = this.actualEigenVectors.Aggregate(false, (current, vector) => current || vector.IsEqual(expectedVector));

            Assert.IsTrue(vectorFound);
        }

        /// <summary>Then the matrix type will be.</summary>
        /// <param name="matrixType">The matrix type.</param>
        [Then(@"the matrix type will be (.*)")]
        public void ThenTheMatrixTypeWillBe(string matrixType)
        {
            switch (matrixType.ToLower())
            {
                case "not triangular":
                    Assert.IsTrue(this.triangularType == MatrixExtensions.TriangularType.NotTrangular);
                    break;
                case "null":
                    Assert.IsTrue(this.triangularType == MatrixExtensions.TriangularType.NullMatrix);
                    break;
                case "diagonal":
                    Assert.IsTrue(this.triangularType == MatrixExtensions.TriangularType.DiagonalMatrix);
                    break;
                case "identity":
                    Assert.IsTrue(this.triangularType == MatrixExtensions.TriangularType.IdentityMatrix);
                    break;
                case "upper":
                    Assert.IsTrue(this.triangularType == MatrixExtensions.TriangularType.UpperTriangular);
                    break;
                case "lower":
                    Assert.IsTrue(this.triangularType == MatrixExtensions.TriangularType.LowerTriangular);
                    break;
                default:
                    Assert.Fail();
                    break;
            }
        }

        /// <summary>Then one root should be.</summary>
        /// <param name="rootTable">The root table.</param>
        [Then(@"one root should be")]
        public void ThenOneRootShouldBe(Table rootTable)
        {
            var expectedRoot = ConvertTableToMatrix(rootTable);

            var found = this.actualRootMatrices.Any(m => m.IsEqual(expectedRoot));

            Assert.IsTrue(found);
        }

        /// <summary>Convert the SpecFlow table in to a matrix.</summary>
        /// <param name="inTable">The SpecFlow table.</param>
        /// <returns>The the 2D double matrix.</returns>
        private static double[,] ConvertTableToMatrix(Table inTable)
        {
            var returnMatrix = new double[inTable.RowCount, inTable.Header.Count];

            for (var r = 0; r < inTable.RowCount; r++)
            {
                for (var c = 0; c < inTable.Header.Count; c++)
                {
                    returnMatrix[r, c] = double.Parse(inTable.Rows[r][c]);
                }
            }

            return returnMatrix;
        }
    }
}
