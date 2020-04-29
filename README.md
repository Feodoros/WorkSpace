# Work Space
### Content

<p align="center">
*  <a href="#Algorithm Rutishauser">Algorithm Rutishauser</a> 
*  <a href="#Binary search">Binary search</a> 
*  <a href="#Crossword">Crossword</a> 
*  <a href="#Directory depth">Directory depth</a> 
*  <a href="#FindSimilar">FindSimilar</a> 
*  <a href="#Generic Collections">Generic Collections</a> 
*  <a href="#HashSearchFile">HashSearchFile</a> 
*  <a href="#Largest path">Largest path</a> 
*  <a href="#Sort by length">Sort by length</a> 
*  <a href="#Tower of Hanoi">Tower of Hanoi</a> 
*  <a href="#Word generator">Word generator</a> 
</p>

# [Algorithm Rutishauser](https://github.com/Feodoros/WorkSpace/blob/master/AlgorithmRutishauser/StructureList.cs)

Feature: full bracket structure of the expression. Example:
D:=((C-(B*L))+K)

The algorithm assigns each character from the string a level number

1. If it is an opening bracket or a variable, then the value is increased by 1;

2. If the operation mark or closing bracket, then decreases by 1.

The algorithm consists of the following steps:

1. complete the leveling;

2. search for line items with the maximum level value;

3. select three - two operands with the maximum value of the level and the operation that is concluded between them;

4. The result of computing the triples is denoted by an auxiliary variable;

5. remove the selected triple from the source line along with its brackets, and put in its place an auxiliary variable indicating the result, with the level value one less than the selected triple;

6. Perform items 2 - 5 until one variable remains in the input line, indicating the general result of the expression.

In addition, we implemented our list based on an array. It has: indices, count, add (in any place), remove, etc.

# [Binary search](https://github.com/Feodoros/WorkSpace/blob/master/BinSearch/Program.cs)
![](https://sun9-15.userapi.com/c857320/v857320109/180096/002vsj8buk8.jpg)
Search the coordinates of an element in 2d array.

We have a sorted array from smallest to largest. We find the middle of the line of the array and compare the element arr [i, mid] with X ( i - number of line in the array). If they match, the problem is solved. if not, then we increase or decrease the right and left borders depending on whether our element is smaller or greater than X.

# [Crossword](https://github.com/Feodoros/WorkSpace/blob/master/Cross/Program.cs)
You have a key word and an array of words (their number is equal to the number of letters in the main word). The algorithm outputs an array with the key highlighted by the word.
We are looking for the intersection indices of words with the word key
Pad each word with spaces
And display
![](https://sun9-58.userapi.com/c205828/v205828109/10aea6/f3boQI59Slc.jpg)


# [Tower of Hanoi](https://github.com/Feodoros/WorkSpace/blob/master/HanoiTowards/Program.cs)
![](https://blog-c7ff.kxcdn.com/blog/wp-content/uploads/2016/12/Tower-of-hanoi.gif)

## About algoritm
We have 3 pegs.
Task: transfer discs from one peg to another using the third peg.


We recursively solve the Hanoi tower problem for n rings.
If the towers n = 3, then we solve the problem for n = 2, and then for n = 1 (with each decrease in n, our maximum ring decreases, that is, recursively going down, we climb the tower).
The case n = 1 is the recursion stopping point.
