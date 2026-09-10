# Analysis - 01-Threading-Basics / 02-ThreadPool-Internals

## Goal
Observe how the ThreadPool reacts to different workloads (I/O-bound vs CPU-bound).

## Key Observations
- ThreadPool maintains a dynamic number of worker threads (started near processor count, grows under load).
- Queue length grows when work arrives faster than available threads can process it.
- `ThreadPool Completed Work Item Count` is a rate (items/sec), not the number of threads.
- I/O-bound work (Task.Delay) mostly uses timers and releases threads quickly → low thread demand.
- CPU-bound work occupies real threads → ThreadPool injects more threads and queue pressure increases significantly.
- Thread injection is gradual (hill-climbing algorithm), not instantaneous.

## Important Takeaways
1. Unbounded creation of Tasks is dangerous mainly because of how it interacts with the ThreadPool and timers.
2. I/O-bound and CPU-bound workloads stress the ThreadPool in completely different ways.
3. Monitoring ThreadPool Thread Count + Queue Length is essential when diagnosing concurrency issues.
4. Understanding these internals explains why limiting concurrency (previous exercises) dramatically improves stability.