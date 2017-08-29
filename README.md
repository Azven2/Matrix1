# Matrices
## non-complex matrices
This is a project including a Matrix extension class for **non-Complex Matrices** (2D arrays of doubles). It also includes gherkin feature file tests (NUnit test runner) with significant code coverage.  The program is just a demo. Extract the extension classes into your project to use the matrix tools.

Once you have declared a Matrix, M, where M =    
| 3, 1 |   
| 5, 2 |   

like this...
- var M = new double[2, 2];
-             M[0, 0] = 3;
-             M[0, 1] = 1;
-             M[1, 0] = 5;
-             M[1, 1] = 2;


Then you can perform sophisticated matrix operations.

- Add to another matrix
- Subtract from a matrix
- Multiply by a constant
- Multiply by a matrix
- Raise to powers
- Calculate Square roots
- Calculate determinant matrix
- Calculate Transpose matrix
- Calculate Adjunct matrix
- Calculate Cofactor matrix
- Calculate Inverse matrix
- Rotation matrix 
- Calculate Eigen values
- Calculate Eigen vectors
- **Calculate simultaneous equations**

//// Example:   
//// The inverse matrix, v, of M is calculated like this   
var v = M.InverseMatrix()


(C) Steven Digby, 29 August 2017