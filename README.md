besttrip
========

This project is based on a programming puzzle. A cub driver needs to find a route from one city to another without running out of gas. Between each pair of cities are possible clients ready to pay for a drive, allowing the cab driver to accumulate a certain amount of money each time it travels from one city to another.  Some routes charge a toll, resulting in losing a certain amount of money.  The program  has to compute a route maximizing the profit.

 Assume that we have the following connections:
 
A --------->B distance: 10  profit: 40

B --------->C distance: 15  profit: 5

C --------->B distance: 15  profit: 30

A --------->C distance: 30  profit: 50

If a cab driver has gas for 40 miles and travels from A to C, the best trip is A -> B -> C -> B -> C with profit 55. 

 As you see, it is a complex problem: the paths have to maximize  profit, can include cycles,  can visit the end node more  than one time  and  can have negative weight. It is obvious that such algorithms as Dijkstry or Bellman-Ford will not work here;  also, it is obvious that it cannot be solved in exactly the same way as the  problem with finding a simple connections between two arbitrary nodes.

Since the solution can be a helpful starting point for dealing with the real life programming problems and I could not find any of this kind out there already, I decide to put together this project to demonstrate how can you tackle the problem.

I hope that it will be useful.

