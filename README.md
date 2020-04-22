# [Tower of Hanoi](https://github.com/Feodoros/WorkSpace/blob/master/HanoiTowards/Program.cs)
![](https://blog-c7ff.kxcdn.com/blog/wp-content/uploads/2016/12/Tower-of-hanoi.gif)

## About algoritm
We have 3 pegs.
Task: transfer discs from one peg to another using the third peg.


We recursively solve the Hanoi tower problem for n rings.
If the towers n = 3, then we solve the problem for n = 2, and then for n = 1 (with each decrease in n, our maximum ring decreases, that is, recursively going down, we climb the tower).
The case n = 1 is the recursion stopping point.
