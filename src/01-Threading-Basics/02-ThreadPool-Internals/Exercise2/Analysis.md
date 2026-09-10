# Analysis - 01-Threading-Basics / 02-ThreadPool-Internals (Starvation)

## Scenario
Mix of blocking work (`Thread.Sleep` inside `Task.Run`) and async work (`Task.Delay` + continuation).

## Observed Behavior
- ThreadPool Queue Length grows significantly while blocking tasks hold worker threads.
- Async continuations are delayed and often complete in a burst only after blocking tasks finish.
- Thread injection is gradual; thread count does not explode immediately.
- Console output of async work appears late and clustered.

## Root Cause
Blocking ThreadPool worker threads prevents async continuations from running promptly → queue buildup and apparent starvation of non-blocking work.

## Key Lesson
Never block ThreadPool threads for extended periods.
Blocking (Sleep, sync-over-async, long locks, etc.) reduces the effective capacity of the ThreadPool and delays unrelated async work.