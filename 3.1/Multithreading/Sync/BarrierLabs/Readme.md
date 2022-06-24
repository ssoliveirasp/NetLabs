Barrier

Permite que várias tarefas trabalhem de forma colaborativa em um algoritmo em paralelo por meio de várias fases.

https://docs.microsoft.com/pt-br/dotnet/api/system.threading.barrier?view=net-6.0

Results

 With Barrier

2.1 Findins the nicest tea cup (only takes a second).
1.1 Putting the kettle on (take a bit longer).
Phase 0 is finished
1.2 Putting water into the cup
2.2 Adding tea
Phase 1 is finished
2.3 Adding sugar
1.3 Putting the kettle away.
Phase 2 is finished

 ** Enjoy you cup of tea**

 Without Barrier

1.1 Putting the kettle on (take a bit longer).
2.1 Findins the nicest tea cup (only takes a second).
2.2 Adding tea
2.3 Adding sugar
1.2 Putting water into the cup
1.3 Putting the kettle away.

 ** Enjoy you cup of tea**
