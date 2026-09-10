# Analysis - Controlled Concurrency (Unbounded vs Limited)

## Scenario
Processing a large number of independent I/O-bound operations.

## Unbounded Approach (Task.WhenAll on many tasks)
Observed problems at scale:
- Massive number of concurrent Tasks
- Extremely high number of active Timers
- ThreadPool queue growth and thread injection
- Significant memory pressure (large GC Heap, LOH, Gen 2)
- High GC pause time
- Elevated lock contention

Root cause: Unbounded concurrency. The system is allowed to start as many operations as there are items, without any limit.

## Limited Approach (Parallel.ForEachAsync with MaxDegreeOfParallelism)
Results:
- Stable memory usage
- Almost no GC pressure
- Very low ThreadPool activity
- Predictable and controlled resource consumption

## Key Insight
For I/O-bound work, unlimited parallelism is often more dangerous than beneficial.
The bottleneck is rarely CPU — it is memory, timers, thread pool, and external resource limits.

Limiting the degree of concurrency dramatically improves stability and reduces overhead, even though the work is asynchronous.