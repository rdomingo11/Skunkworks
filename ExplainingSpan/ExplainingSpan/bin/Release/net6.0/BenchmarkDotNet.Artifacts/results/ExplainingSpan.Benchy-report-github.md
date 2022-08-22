``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19041.746 (2004/May2020Update/20H1)
Intel Xeon CPU E5-2640 v4 2.40GHz, 2 CPU, 2 logical and 2 physical cores
.NET SDK=6.0.201
  [Host]     : .NET 6.0.3 (6.0.322.12309), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 6.0.3 (6.0.322.12309), X64 RyuJIT


```
|                     Method |      Mean |    Error |   StdDev |  Gen 0 | Allocated |
|--------------------------- |----------:|---------:|---------:|-------:|----------:|
| DateWithStringAndSubstring | 114.95 ns | 0.750 ns | 0.702 ns | 0.0073 |      96 B |
|      DateWithStringAndSpan |  61.46 ns | 1.254 ns | 1.288 ns |      - |         - |
