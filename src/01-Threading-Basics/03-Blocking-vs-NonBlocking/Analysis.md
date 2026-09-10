# Analysis - 01-Threading-Basics / 03-Blocking-vs-NonBlocking

## Comparison (500 items)

| Version          | Time     | Queue Length | Thread Count | Behavior                          |
|------------------|----------|--------------|--------------|-----------------------------------|
| Blocking         | ~48 s    | ~489         | 10–11        | Worker threads occupied by Sleep  |
| Non-Blocking     | ~1 s     | ~0           | 6–7          | Timers only, threads stay free    |

## Key Takeaway
Blocking ThreadPool threads drastically reduces effective concurrency and increases latency.  
Prefer non-blocking async APIs (`Task.Delay`, true async I/O) whenever possible.