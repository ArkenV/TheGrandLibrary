⍝ Define a vector (1-dimensional array)
v ← 1 2 3 4 5

⍝ Scalar operation: Add 1 to each element (demonstrating element-wise operations)
v + 1  ⍝ Result: 2 3 4 5 6

⍝ Reduction: Sum of all elements (demonstrating reduction operations)
+/v  ⍝ Result: 15

⍝ Outer product: Multiplication table (demonstrating higher-dimensional operations)
v ∘.× v  ⍝ Result: 5x5 matrix of products

⍝ Sorting and ranking (demonstrating built-in array operations)
⍋v  ⍝ Grade up (indices that would sort the array)
⍒v  ⍝ Grade down (indices that would sort the array in descending order)

⍝ Matrix operations
m ← 3 3 ⍴ ⍳9  ⍝ Reshape the first 9 integers into a 3x3 matrix
⍝ m is now:
⍝ 1 2 3
⍝ 4 5 6
⍝ 7 8 9

+/m      ⍝ Sum of each column: 12 15 18
+⌿m      ⍝ Sum of each row: 6 15 24

⍝ Function composition and mapping (demonstrating higher-order functions)
factorial ← {×/1+⍳⍵}  ⍝ Define a factorial function
factorial 5  ⍝ Result: 120
factorial¨v  ⍝ Map factorial over each element of v

⍝ Tacit programming (point-free style)
avg ← +/ ÷ ≢  ⍝ Define average function without explicit arguments