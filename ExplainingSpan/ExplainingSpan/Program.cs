using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;

namespace ExplainingSpan
{
    class Program
    {
       
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Benchy>();
        }
        
        ///// <summary>
        ///// This is a sample usage of to span.
        ///// </summary>
        ///// <returns></returns>
        //public static ReadOnlySpan<char> YearAsText()
        //{
        //    ReadOnlySpan<char> dateAsSpan = _dateAsText;
        //    var yearAsText = dateAsSpan.Slice(6);
        //    return yearAsText;
        //}

        
    }
    
    [MemoryDiagnoser]
    public class Benchy
    {
        private static readonly string _dateAsText = "08 07 2021";

        [Benchmark]
        public  (int day, int month, int year) DateWithStringAndSubstring()
        {
            
            var dayAsText = _dateAsText.Substring(0, 2);
            var monthAsText = _dateAsText.Substring(3, 2);
            var yearAsText = _dateAsText.Substring(6);
            var day = int.Parse(dayAsText);
            var month = int.Parse(monthAsText);
            var year = int.Parse(yearAsText);
            return (day, month, year);
        }

        [Benchmark]
        public  (int day, int month, int year) DateWithStringAndSpan()
        {
            //It is only allocated in the stack (arbitrary memory) and doesn't need to clean up by gC.
            //ReadOnlySpan<char>
            ReadOnlySpan<char> dateAsSpan = _dateAsText;
            var dayAsText = dateAsSpan.Slice(0, 2);
            var monthAsText = dateAsSpan.Slice(3, 2);
            var yearAsText = dateAsSpan.Slice(6);
            var day = int.Parse(dayAsText);
            var month = int.Parse(monthAsText);
            var year = int.Parse(yearAsText);
            return (day, month, year);
        }

    }
}