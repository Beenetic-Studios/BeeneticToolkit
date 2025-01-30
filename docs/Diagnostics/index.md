#### [Diagnostics](index.md 'index')

## Diagnostics Assembly
### Namespaces

<a name='BeeneticToolkit.Diagnostics'></a>

## BeeneticToolkit.Diagnostics Namespace

The [BeeneticToolkit.Diagnostics](index.md#BeeneticToolkit.Diagnostics 'BeeneticToolkit.Diagnostics') namespace provides utility classes for tracking and profiling  
execution performance, memory usage, exception handling, and method call frequencies.
- **[CallFrequencyTracker](CallFrequencyTracker.md 'BeeneticToolkit.Diagnostics.CallFrequencyTracker')** `Class` Tracks the frequency of method calls.
  - **[GetCallCount(string)](CallFrequencyTracker.GetCallCount(string).md 'BeeneticToolkit.Diagnostics.CallFrequencyTracker.GetCallCount(string)')** `Method` Gets the call count for a specified method.
  - **[GetReport()](CallFrequencyTracker.GetReport().md 'BeeneticToolkit.Diagnostics.CallFrequencyTracker.GetReport()')** `Method` Gets a formatted report of all tracked call counts.
  - **[Increment(string)](CallFrequencyTracker.Increment(string).md 'BeeneticToolkit.Diagnostics.CallFrequencyTracker.Increment(string)')** `Method` Increments the call count for a specified method.
- **[ExceptionTracker](ExceptionTracker.md 'BeeneticToolkit.Diagnostics.ExceptionTracker')** `Class` Provides utilities for detailed exception tracking and reporting.
  - **[Track(Exception, string, Nullable&lt;ExceptionCategory&gt;, string, string, int)](ExceptionTracker.Track(Exception,string,Nullable_ExceptionCategory_,string,string,int).md 'BeeneticToolkit.Diagnostics.ExceptionTracker.Track(System.Exception, string, System.Nullable<BeeneticToolkit.Diagnostics.ExceptionCategory>, string, string, int)')** `Method` Tracks an exception with detailed method context and an optional category.
  - **[TrackWithCategory(Exception, ExceptionCategory, string, string, string, int)](ExceptionTracker.TrackWithCategory(Exception,ExceptionCategory,string,string,string,int).md 'BeeneticToolkit.Diagnostics.ExceptionTracker.TrackWithCategory(System.Exception, BeeneticToolkit.Diagnostics.ExceptionCategory, string, string, string, int)')** `Method` Tracks an exception with detailed method context, using a specified category.
- **[ExecutionTimer](ExecutionTimer.md 'BeeneticToolkit.Diagnostics.ExecutionTimer')** `Class` Provides utilities for measuring the execution time of methods.
  - **[MeasureExecutionTime(Action)](ExecutionTimer.MeasureExecutionTime(Action).md 'BeeneticToolkit.Diagnostics.ExecutionTimer.MeasureExecutionTime(System.Action)')** `Method` Measures the execution time of a method that does not return a result.
  - **[MeasureExecutionTime&lt;T&gt;(Func&lt;T&gt;)](ExecutionTimer.MeasureExecutionTime_T_(Func_T_).md 'BeeneticToolkit.Diagnostics.ExecutionTimer.MeasureExecutionTime<T>(System.Func<T>)')** `Method` Measures the execution time of a method that returns a result.
- **[MemoryProfiler](MemoryProfiler.md 'BeeneticToolkit.Diagnostics.MemoryProfiler')** `Class` Provides tools for profiling memory usage during method execution.
  - **[MeasureMemoryUsage(Action, bool)](MemoryProfiler.MeasureMemoryUsage(Action,bool).md 'BeeneticToolkit.Diagnostics.MemoryProfiler.MeasureMemoryUsage(System.Action, bool)')** `Method` Measures the change in memory usage before and after a method's execution (void method).
  - **[MeasureMemoryUsage&lt;T&gt;(Func&lt;T&gt;, bool)](MemoryProfiler.MeasureMemoryUsage_T_(Func_T_,bool).md 'BeeneticToolkit.Diagnostics.MemoryProfiler.MeasureMemoryUsage<T>(System.Func<T>, bool)')** `Method` Measures the change in memory usage before and after a method's execution.
- **[ExceptionCategory](ExceptionCategory.md 'BeeneticToolkit.Diagnostics.ExceptionCategory')** `Enum` Represents the category of an exception for tracking and reporting purposes.
  - **[Critical](ExceptionCategory.md#BeeneticToolkit.Diagnostics.ExceptionCategory.Critical 'BeeneticToolkit.Diagnostics.ExceptionCategory.Critical')** `Field` Indicates a critical exception that requires immediate attention.
  - **[Info](ExceptionCategory.md#BeeneticToolkit.Diagnostics.ExceptionCategory.Info 'BeeneticToolkit.Diagnostics.ExceptionCategory.Info')** `Field` Indicates an informational exception that does not require immediate action.
  - **[Warning](ExceptionCategory.md#BeeneticToolkit.Diagnostics.ExceptionCategory.Warning 'BeeneticToolkit.Diagnostics.ExceptionCategory.Warning')** `Field` Indicates a warning exception that may not be critical but should be reviewed.