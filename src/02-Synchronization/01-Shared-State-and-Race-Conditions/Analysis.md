# Analysis - 02-Synchronization / 01-Shared-State-and-Race-Conditions

## Problem
Multiple concurrent tasks were modifying shared mutable state (`_processedCount` and `List<int>`) without synchronization.

## Observed Symptoms
- Incorrect and non-deterministic final counts
- High memory pressure, GC activity, and ThreadPool load when concurrency was unbounded
- Classic race condition on both the counter and the collection

## Root Cause
- `x++` is not an atomic operation
- `List<T>` is not thread-safe
- No synchronization around shared state

## Correct Approaches Demonstrated
1. `lock` around both write and read operations (simple and clear)
2. `Interlocked.Increment` + `ConcurrentBag<T>` (better scalability for high contention)

## Key Lessons
- Any shared mutable state accessed by multiple threads/tasks needs protection
- Returning a live reference to a non-thread-safe collection is dangerous
- Prefer returning a snapshot (`ToList()` under lock) or using concurrent collections
- Race conditions are especially common in ASP.NET Core when using Singleton services or static state

## Performance Note
Adding proper synchronization fixed correctness.
Limiting concurrency (from previous exercises) remains important for resource control.