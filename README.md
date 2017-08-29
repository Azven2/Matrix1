# Matrices 1
## non-complex matrices
_This is a project including a Matrix extension class for **non-Complex Matrices** (2D arrays of doubles). It also includes gherkin feature file tests (NUnit test runner) with significant code coverage.  The program is just a demo. Extract the extension classes into your project to use the matrix tools._   

_Once you have declared a Matrix, M, where M =_   
| 3, 1 |   
| 5, 2 |   

_like this..._  
var M = new double[2, 2];   
            M[0, 0] = 3;   
            M[0, 1] = 1;   
            M[1, 0] = 5;   
            M[1, 1] = 2;   


_Then you can perform sophisticated matrix operations._

- Add to another matrix
- Subtract from a matrix
- Multiply by a constant
- Multiply by a matrix
- Raise to powers
- Calculate Square roots
- Calculate a determinant 
- Calculate a Transpose matrix
- Calculate an Adjunct matrix
- Calculate a Cofactor matrix
- Calculate an Inverse matrix
- Calculate a Rotation matrix 
- Calculate Eigen values
- Calculate Eigen vectors
- **Calculate simultaneous equations**

//// Example:   
//// The inverse matrix, v, of M is calculated like this   
var v = M.InverseMatrix()


(C) Steven Digby, 29 August 2017
