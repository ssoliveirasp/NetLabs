Dataflow pattern

The dataflow pattern is a generalized pattern with a one-to-many and a many-to-one relationship. 
For example, the following diagram represents two tasks, Task 1 and Task 2, that execute in parallel, and a third task, 
Task 3, that will only start when both of the first two tasks are completed. Once Task 3 is completed, Task 4 and Task 5 will be executed in parallel:

___________                 ___________
|         |                 |         |
| Tasks1  |                 | Tasks2  |
|_________|                 |_________|
      |                         |
      |------------|-------------
                   |             
                ___v_____                  
               |         |              
               | Tasks3  |              
               |_________|      
                   /\          
                    |           
     -----------------------------  
_____|_____                 _____|_____
|         |                 |         |
| Tasks4  |                 | Tasks5  |
|_________|                 |_________|
      