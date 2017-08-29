Feature: MatrixTests
	In order to avoid silly mistakes
	I want to test the matrix tools

@matrixTests
Scenario: Test the IsEqual method
	Given The following matrix
	| C1 | C2 |
	| 7  | 6  |
	| 5  | 4  |
	And another matrix
	| C1 | C2 |
	| 7  | 6  |
	| 5  | 4  |
	When I compare the matrices for equality
	Then the result will be True

@matrixTests
Scenario: Test the IsEqual method for inequality
	Given The following matrix
	| C1 | C2 |
	| 7  | 6  |
	| 5  | 4  |
	And another matrix
	| C1 | C2 |
	| 7  | 6  |
	| 5  | 3  |
	When I compare the matrices for equality
	Then the result will be False

@matrixTests
Scenario: Test that a zero matrix can be recognised
	Given The following matrix
	| C1 | C2 |
	| 0  | 0  |
	| 0  | 0  |
	When I compare the matrix to a zero matrix
	Then the result will be True

@matrixTests
	Scenario: Test that a matrix can be recognised as not a NULL matrix
	Given The following matrix
	| C1 | C2 |
	| 1  | 0  |
	| 0  | 0  |
	When I compare the matrix to a zero matrix
	Then the result will be False

@matrixTests
Scenario: Test that an identity matrix can be recognised
	Given The following matrix
	| C1 | C2 |
	| 1  | 0  |
	| 0  | 1  |
	When I compare the matrix to an identity matrix
	Then the result will be True

@matrixTests
Scenario: Test that a matrix can be recognised as not an identity matrix
	Given The following matrix
	| C1 | C2 |
	| 1  | 0  |
	| 0  | 0  |
	When I compare the matrix to an identity matrix
	Then the result will be False

@matrixTests
Scenario: Extract an element from the matrix
	Given The following matrix
	| C1 | C2 |
	| 7  | 6  |
	| 5  | 4  |
	| 3  | 2  |
	When I look-up element row 2, column 2
	Then the result is 4

@matrixTests
Scenario: Transpose a matrix
	Given The following matrix
	| C1 | C2 |
	| 7  | 6  |
	| 5  | 4  |
	| 3  | 2  |
	When I transpose the matrix
	Then the result should be 
	| C1 | C2 | C3 |
	| 7  | 5  | 3  |
	| 6  | 4  | 2  |

@matrixTests
Scenario: Can I add two matrices together
	Given The following matrix
	| C1 | C2 |
	| 7  | 6  |
	| 5  | 4  |
	And another matrix
	| C1 | C2 |
	| -6 | -3 |
	| 0  | 3  |
	When I add the two matrices
	Then the result should be 
	| C1 | C2 |
	| 1  | 3  |
	| 5  | 7  |  

@matrixTests
Scenario: Can I subtract one matrix from another
	Given The following matrix
	| C1 | C2 |
	| 7  | 6  |
	| 5  | 4  |
	And another matrix
	| C1 | C2 |
	| 2  | 3  |
	| 1  | -1 |
	When I subtract the second matrix from the first
	Then the result should be 
	| C1 | C2 |
	| 5  | 3  |
	| 4  | 5  |  

@matrixTests
Scenario: Can I multiply one matrix by a constant
	Given The following matrix
	| C1 | C2 |
	| 1  | -2 |
	| -1 | 3  |
	When I multiply the first matrix by the constant 3
	Then the result should be 
	| C1 | C2 |
	| 3  | -6 |
	| -3 | 9  |

@matrixTests
Scenario: Can I multiply one matrix with another
	Given The following matrix
	| C1 | C2 |
	| 7  | 6  |
	| 5  | 4  |
	And another matrix
	| C1 | C2 |
	| 2  | 3  |
	| 1  | -1 |
	When I multiply the first matrix by the second
	Then the result should be 
	| C1 | C2 |
	| 20 | 15 |
	| 14 | 11 |

@matrixTests
Scenario: Extract a sub-matrix
	Given The following matrix
	| C1 | C2 | C3 |
	| 1  | 2  | 3  |
	| 0  | 4  | 5  |
	| 1  | 0  | 6  |
	When I extract the submatrix of row 2 column 3
	Then the result should be 
	| C1 | C2 |
	| 1  | 2  |
	| 1  | 0  |

@matrixTests
Scenario: Get the negative matrix
	Given The following matrix
	| C1 | C2 |
	| -1  | 0  |
	| 2  | -4  |
	When I negate the matrix
	Then the result should be 
	| C1 | C2 |
	| 1  | 0  |
	| -2 | 4  |

@matrixTests
Scenario: Extract a minor matrix
	Given The following matrix
	| C1 | C2 | C3 |
	| 1  | 2  | 3  |
	| 0  | 4  | 5  |
	| 1  | 0  | 6  |
	When I extract the minor matrix of column 2
	Then the result should be 
	| C1 | C2 |
	| 0  | 5  |
	| 1  | 6  |

@matrixTests
Scenario: Calculate the cofactor 
	Given The following matrix
	| C1 | C2 | C3 |
	| 1  | 2  | 3  |
	| 0  | 4  | 5  |
	| 1  | 0  | 6  |
	When I calculate the cofactor matrix
	Then the result should be 
	| C1  | C2 | C3 |
	| 24  | 5  | -4 |
	| -12 | 3  | 2  |
	| -2  | -5 | 4  |

@matrixTests
Scenario: Calculate the determinant (2x2)
	Given The following matrix
	| C1 | C2 |
	| 7  | 6  |
	| 5  | 4  |
	When I calculate the determinant
	Then the result is -2

@matrixTests
Scenario: Calculate the determinant (4x4)
	Given The following matrix
	| C1 | C2 | C3 | C4 |
	| 3  | 2  | 0  | 1  |
	| 4  | 0  | 1  | 2  |
	| 3  | 0  | 2  | 1  |
	| 9  | 2  | 3  | 1  |
	When I calculate the determinant
	Then the result is 24

@matrixTests
Scenario: Calculate the adjunct (2x2)
	Given The following matrix
	| C1 | C2 |
	| 7  | 6  |
	| 5  | 4  |
	When I calculate the adjunct matrix
	Then the result should be 
	| C1 | C2 |
	| 4  | -6 |
	| -5 | 7  |

@matrixTests
Scenario: Calculate the adjunct (3x3)
	Given The following matrix
	| C1 | C2 | C3 |
	| -3 | 2  | -5 |
	| -1 | 0  | -2 |
	| 3  | -4 | 1  |
	When I calculate the adjunct matrix
	Then the result should be 
	| C1 | C2 | C3 |
	| -8 | 18 | -4 |
	| -5 | 12 | -1 |
	| 4  | -6 | 2  |

@matrixTests
Scenario: Calculate the inverse matrix
	Given The following matrix
	| C1 | C2 |
	| 4  | 7  |
	| 2  | 6  |
	When I calculate the inverse matrix
	Then the result should be 
	| C1   | C2   |
	| 0.6  | -0.7 |
	| -0.2 | 0.4  |

@matrixTests
Scenario: Calculate the inverse matrix (reverse check)
	Given The following matrix
	| C1 | C2 |
	| 4  | 7  |
	| 2  | 6  |
	And another matrix
	| C1   | C2   |
	| 0.6  | -0.7 |
	| -0.2 | 0.4  |
	When I multiply the first matrix by the second
	Then the resulting matrix will be an identity matrix

@matrixTests
Scenario: Calculate the inverse matrix (reverse check, fail)
	Given The following matrix
	| C1 | C2 |
	| 4  | 7  |
	| 2  | 6  |
	And another matrix
	| C1  | C2   |
	| 0.6 | -0.7 |
	| 2   | 0.4  | 
	When I multiply the first matrix by the second
	Then the resulting matrix will not be an identity matrix

@matrixTests
Scenario: Get the lowest terms of a given matrix
	Given The following matrix
	| C1   | C2   |
	| -128 | 256  |
	| 1024 | -512 |
	When I get the lowest term matrix
	Then the result should be 
	| C1 | C2 |
	| -1 | 2  |
	| 8  | -4 |
	And the result is 128

@matrixTests
Scenario: Get the lowest terms of a given matrix (2)
	Given The following matrix
	| C1  | C2  |
	| -12 | 24  |
	| 36   | -48 |
	When I get the lowest term matrix
	Then the result should be 
	| C1 | C2 |
	| -1 | 2  |
	| 3  | -4 |
	And the result is 12

@matrixTests
Scenario: Get the lowest terms of a given matrix (no change)
	Given The following matrix
	| C1 | C2 |
	| -4 | 7  |
	| 2  | -6 |
	When I get the lowest term matrix
	Then the result should be 
	| C1 | C2 |
	| -4 | 7  |
	| 2  | -6 |
	And the result is 1

@matrixTests
Scenario: Get Eigen value of a 2x2 matrix
	Given The following matrix
	| C1 | C2 |
	| 2  | 4  |
	| 3  | 13 |
	When I get the Eigen value
	Then the Eigen values are 1 and 14

@matrixTests
Scenario: Get Eigen vectors of a 2x2 matrix
	Given The following matrix
	| C1 | C2 |
	| 3  | 5  |
	| -2 | -4 |
	When I get the Eigen vectors
	Then the Eigen vector is
	| V  |
	| 5  |
	| -2 |
	And the other vector is
	| V  |
	| 1  |
	| -1 |

@matrixTests
Scenario: Can raise a matrix to a power
	Given The following matrix
	| C1 | C2 |
	| 1  | 2  |
	| -1 | 1  |
	When I raise the matrix to the power of 3
	Then the result should be 
	| C1 | C2 |
	| -5 | 2  |
	| -1 | -5 |

@matrixTests
Scenario: Can raise a matrix to the power of -1
	Given The following matrix
	| C1 | C2 |
	| 4  | 7  |
	| 2  | 6  |
	When I raise the matrix to the power of -1
	Then the result should be 
	| C1   | C2   |
	| 0.6  | -0.7 |
	| -0.2 | 0.4  |

@matrixTests
Scenario: Can raise an identity matrix to a power
	Given The following matrix
	| C1 | C2 | C3 |
	| 1  | 0  | 0  |
	| 0  | 1  | 0  |
	| 0  | 0  | 1  |
	When I raise the matrix to the power of 3
	Then the result should be 
	| C1 | C2 | C3 |
	| 1  | 0  | 0  |
	| 0  | 1  | 0  |
	| 0  | 0  | 1  |

@matrixTests
Scenario: Can raise a diagonal matrix to a power
	Given The following matrix
	| C1 | C2 | C3 |
	| 3  | 0  | 0  |
	| 0  | -2 | 0  |
	| 0  | 0  | 2  |
	When I raise the matrix to the power of 3
	Then the result should be 
	| C1 | C2 | C3 |
	| 27 | 0  | 0  |
	| 0  | -8 | 0  |
	| 0  | 0  | 8  |

@matrixTests
Scenario: Can I divide one matrix with another
	Given The following matrix
	| C1 | C2 |
	| 20 | 15 |
	| 14 | 11 |
	And another matrix
	| C1 | C2 |
	| 7  | 6  |
	| 5  | 4  |
	When I divide the first matrix by the second
	Then the result should be 
	| C1 | C2 |
	| 2  | 3  |
	| 1  | -1 |
	
@matrixTests
Scenario: Can recognise a diagonal matrix (pass)
	Given The following matrix
	| C1 | C2 | C3 |
	| 3  | 0  | 0  |
	| 0  | -2 | 0  |
	| 0  | 0  | 2  |
	When check to see if the matrix is diagonal
	Then the result will be True

@matrixTests
Scenario: Can recognise a diagonal matrix (fail)
	Given The following matrix
	| C1 | C2 | C3 |
	| 3  | 0  | 0  |
	| 0  | -2 | 0  |
	| 1  | 0  | 2  |
	When check to see if the matrix is diagonal
	Then the result will be False

@matrixTests
Scenario: Can recognise a scalar matrix (pass)
	Given The following matrix
	| C1 | C2 | C3 |
	| 4  | 0  | 0  |
	| 0  | 4  | 0  |
	| 0  | 0  | 4  |
	When check to see if the matrix is scalar
	Then the result will be True

@matrixTests
Scenario: Can recognise a scalar matrix (fail1)
	Given The following matrix
	| C1 | C2 | C3 |
	| 4  | 0  | 0  |
	| 0  | 4  | 0  |
	| 0  | 0  | 6  |
	When check to see if the matrix is scalar
	Then the result will be False

@matrixTests
Scenario: Can recognise a scalar matrix (fail2)
	Given The following matrix
	| C1 | C2 | C3 |
	| 3  | 0  | 0  |
	| 0  | 3  | 0  |
	| 1  | 0  | 3  |
	When check to see if the matrix is scalar
	Then the result will be False

@matrixTests
Scenario: Can recognise a involution matrix (pass)
	Given The following matrix
	| C1 | C2 |
	| 4  | -1 |
	| 15 | -4 |
	When check to see if the matrix is involution
	Then the result will be True

@matrixTests
Scenario: Can recognise a nilpotent matrix for an index (pass)
	Given The following matrix
	| C1 | C2 | C3 |
	| 5  | -3 | 2  |
	| 15 | -9 | 6  |
	| 10 | -6 | 4  |
	And the index is 2
	When check to see if the matrix is nilpotent
	Then the result will be True

@matrixTests
Scenario: Can recognise a nilpotent matrix for all indecise (pass)
	Given The following matrix
	| C1 | C2 | C3 | C4 |
	| 0  | 2  | 1  | 6  |
	| 0  | 0  | 1  | 2  |
	| 0  | 0  | 0  | 3  |
	| 0  | 0  | 0  | 0  |
	When check to see if the matrix is nilpotent for all
	Then the result will be True

@matrixTests
Scenario: Can recognise a triangular matrix and return its type (fail)
	Given The following matrix
	| C1 | C2 | C3 | C4 |
	| 0  | 2  | 1  | 6  |
	| 0  | 0  | 1  | 2  |
	| 0  | 0  | 0  | 3  |
	| 1  | 0  | 0  | 0  |
	When check to see if the matrix is triangular
	Then the matrix type will be Not Triangular

@matrixTests
Scenario: Can recognise a triangular matrix and return its type (upper)
	Given The following matrix
	| C1 | C2 | C3 | C4 |
	| 0  | 2  | 1  | 6  |
	| 0  | 0  | 1  | 2  |
	| 0  | 0  | 0  | 3  |
	| 0  | 0  | 0  | 0  |
	When check to see if the matrix is triangular
	Then the matrix type will be Upper

@matrixTests
Scenario: Can recognise a triangular matrix and return its type (lower)
	Given The following matrix
	| C1 | C2 | C3 | C4 |
	| 0  | 0  | 0  | 0  |
	| 3  | 0  | 0  | 0  |
	| 5  | 6  | 0  | 0  |
	| 2  | -1 | 3  | 0  |
	When check to see if the matrix is triangular
	Then the matrix type will be Lower

@matrixTests
Scenario: Get the trace of a given matrix
	Given The following matrix
	| C1 | C2 |
	| -4 | 7  |
	| 2  | -6 |
	When I get the trace of the matrix
	Then the result is -10

@matrixTests
Scenario: Can I join a matrix to an identity matrix
	Given The following matrix
	| C1 | C2 |
	| 20 | 15 |
	| 14 | 11 |
	When I join the matrix to an identity matrix
	Then the result should be 
	| C1 | C2 | C3 | C4 |
	| 20 | 15 | 1  | 0  |
	| 14 | 11 | 0  | 1  |

@matrixTests
Scenario: Can I extract a matrix from the left half of a matrix
	Given The following matrix
	| C1 | C2 | C3 | C4 |
	| 2  | 5  | 1  | 4  |
	| 4  | 1  | 7  | 3  |
	When I extract a left matrix
	Then the result should be 
	| C1 | C2 |
	| 2  | 5  |
	| 4  | 1  |

@matrixTests
Scenario: Can I extract a matrix from the right half of a matrix
	Given The following matrix
	| C1 | C2 | C3 | C4 |
	| 2  | 5  | 1  | 4  |
	| 4  | 1  | 7  | 3  |
	When I extract a right matrix
	Then the result should be 
	| C1 | C2 |
	| 1  | 4  |
	| 7  | 3  |

@matrixTests
Scenario: Can I create a matrix from a string 1
	Given The string "[ 1, 4, -2 ; 7, 3, 5]"
	When I convert the string to a matrix
	Then the result should be 
	| C1 | C2 | C3 |
	| 1  | 4  | -2 |
	| 7  | 3  | 5  |

@matrixTests
Scenario: Can I create a matrix from a string 2
	Given The string "[ 1, 4 ; -2, 7 ; 3, 5]"
	When I convert the string to a matrix
	Then the result should be 
	| C1 | C2 |
	| 1  | 4  |
	| -2 | 7  |
	| 3  | 5  |

@matrixTests
Scenario: Can I find the square root of a 2x2 matrix
	Given The following matrix
	| C1 | C2 |
	| 33 | 24 |
	| 48 | 57 |
	When I calculate the square roots of the matrix
	Then one root should be 
	| C1 | C2 |
	| 5  | 2  |
	| 4  | 7  |
	And one root should be 
	| C1 | C2 |
	| 1  | 4  |
	| 8  | 5  |
	And one root should be 
	| C1 | C2 |
	| -5 | -2 |
	| -4 | -7 |
	And one root should be 
	| C1 | C2 |
	| -1 | -4 |
	| -8 | -5 |

@matrixTests
Scenario: Can I find the Reduced Row Echelon Form of a matrix 1
	Given The following matrix
	| C1 | C2 | C3 | C4 | C5 |
	| -1 | 1  | 1  | 1  | 7  |
	| 2  | -1 | 0  | 0  | 1  |
	| 2  | -2 | 1  | 0  | -7 |
	| -3 | 1  | 1  | 1  | 1  |
	When I calculate the RREF
	Then the result should be 
	| C1 | C2 | C3 | C4 | C5 |
	| 1  | 0  | 0  | 0  | 3  |
	| 0  | 1  | 0  | 0  | 5  |
	| 0  | 0  | 1  | 0  | -3 |
	| 0  | 0  | 0  | 1  | 8  |

@matrixTests
Scenario: Can I find the Reduced Row Echelon Form of a matrix 2
	Given The following matrix
	| C1 | C2 | C3 | C4 | C5 |
	| 2  | 3  | 5  | 1  | 7  |
	| 5  | 0  | 2  | 2  | -1 |
	| 7  | 1  | 1  | 1  | 0  |
	| 3  | 1  | 3  | 1  | 0  |
	When I calculate the RREF
	Then the result should be 
	| C1 | C2 | C3 | C4 | C5 |
	| 1  | 0  | 0  | 0  | -1 |
	| 0  | 1  | 0  | 0  | 5  |
	| 0  | 0  | 1  | 0  | -2 |
	| 0  | 0  | 0  | 1  | 4  |


@matrixTests
Scenario: Can I find the Reduced Row Echelon Form of a matrix 3
	Given The following matrix
	| C1 | C2 | C3 |
	| 2  | -3 | -1 |
	| -1 | 2  | -1 |
	When I calculate the RREF
	Then the result should be 
	| C1 | C2 | C3 |
	| 1  | 0  | -5 |
	| 0  | 1  | -3 |

@matrixTests
Scenario: Can I find the Reduced Row Echelon Form of a matrix and a vector
	Given The following matrix
	| C1 | C2 | C3 | C4 | 
	| -1 | 1  | 1  | 1  | 
	| 2  | -1 | 0  | 0  | 
	| 2  | -2 | 1  | 0  | 
	| -3 | 1  | 1  | 1  | 	
	When I augment the matrix with the following vector
	| C1 |
	| 7  |
	| 1  |
	| -7 |
	| 1  |
	And I calculate the RREF
	Then the result should be 
	| C1 | C2 | C3 | C4 | C5 |
	| 1  | 0  | 0  | 0  | 3  |
	| 0  | 1  | 0  | 0  | 5  |
	| 0  | 0  | 1  | 0  | -3 |
	| 0  | 0  | 0  | 1  | 8  |

@MatrixTests
Scenario: Find the highestMagnitude number in a matrix
	Given The following matrix
			 | C1  | C2 | C3 |
			 | -1  | 2  | -4 |
			 | 2   | 3  | -7 |
			 | -10 | 7  | 5  |
	When I Find Highest magnitude Element In the Matrix
	Then the result is 10


