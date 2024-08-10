-- Demonstrating immutability, pure functions, and higher-order functions
module FunctionalExample where

-- Pure function
factorial :: Integer -> Integer
factorial 0 = 1
factorial n = n * factorial (n - 1)

-- Higher-order function
applyTwice :: (a -> a) -> a -> a
applyTwice f x = f (f x)

-- List processing with recursion and pattern matching
sum' :: Num a => [a] -> a
sum' [] = 0
sum' (x:xs) = x + sum' xs

-- Function composition
composed :: Integer -> Integer
composed = (*2) . (+3) . factorial

main :: IO ()
main = do
    putStrLn $ "Factorial of 5: " ++ show (factorial 5)
    putStrLn $ "Apply twice (*2) to 3: " ++ show (applyTwice (*2) 3)
    putStrLn $ "Sum of [1..5]: " ++ show (sum' [1..5])
    putStrLn $ "Composed function on 4: " ++ show (composed 4)