Producer/consumer pattern

One of the best patterns to execute long-running operations is the producer/consumer pattern. 
In this pattern, there are producers and consumers, and one or more producers are connected to one or more consumers through a shared data structure known as BlockingCollection. 
BlockingCollection is a fixed-sized collection used in parallel programming. 
If the collection is full, the producers are blocked, and if the collection is empty, no more consumers should be added:

____________    _____________   ____________
|           |   |           |   |           |
| Producer1 |   | Producer1 |   | Producer1 |
|___________|   |___________|   |___________|
      |               |                |
      |---------------|----------------|
                      |             
           ___________v___________                  
           |                     |              
           | Blocking Collection |              
           |_____________________|      
                     /\          
                     |           
     -----------------------------  
_____|________              _____|_______
|            |             |             |
| Consumer 1 |             | Consumer 2  |
|____________|             |_____________|
 


System.Threading.Tasks.Dataflow.BufferBlock<T>

Especifica o tipo de dados armazenados em buffer por esse bloco de fluxo de dados.

https://docs.microsoft.com/pt-br/dotnet/api/system.threading.tasks.dataflow.bufferblock-1?view=net-6.0