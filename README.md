# Matrix1
Matrix extension class for non-Complex Matrices (doubles of 2D arrays)

Onece you have declared a Matrix, M, such as this...
    /        \
    |  3  1  |
M = |  5  2  |
    \        /

like this...
            var M = new double[2, 2];
            M[0, 0] = 3;
            M[0, 1] = 1;
            M[1, 0] = 5;
            M[1, 1] = 2;

Then you can perform sophisticated matrix operations.

Add to another matrix
Subtract from a matrix
Multiply by a constant
Multiply by a matrix
Raise to powers
Calculate SQuare roots
Calculate determinant matrix
Calculate Transpose matrix
Calculate Adjunct matrix
Calculate Cofactor matrix
Calculate Inverse matrix
Rotation matrix 
Calculate Eigen values
Calculate Eigen vectors
Calculate simultaneous equations 

//// The inverse matrix of M
var v = M.InverseMatrix()




(C) Steven Digby, 29 August 2017
