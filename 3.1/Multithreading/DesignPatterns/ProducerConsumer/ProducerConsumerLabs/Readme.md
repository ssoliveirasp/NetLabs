﻿Producer/consumer pattern
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
 


System.Collections.Concurrent.BlockingCollection<T>	

Fornece funcionalidades de bloqueio e delimitação para coleções thread-safe que implementam System.Collections.Concurrent.IProducerConsumerCollection<T>. 
Os threads de produtor são bloqueados se nenhum slot estiver disponível, ou se a coleção estiver cheia. 
Threads de consumidor são bloqueados se a coleção estiver vazia. 
Esse tipo também oferece suporte ao acesso sem bloqueio de produtores e consumidores. 
BlockingCollection<T> pode ser usado como uma classe base ou repositório de backup para fornecer bloqueio e limitação a qualquer classe de coleção que ofereça suporte a IEnumerable<T>.

https://docs.microsoft.com/pt-br/dotnet/standard/parallel-programming/data-structures-for-parallel-programming