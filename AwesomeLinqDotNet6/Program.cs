namespace AwesomeLinqDotNet6
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //1. Chunk
            var names = new[] { "Nick", "Mike", "John", "Leyla", "David", "Damian" };

            //Nick, Mike, John
            //Leyla, David, Damian

            //var chunked = ChunkBy(names, 3);
            //.NET 6
            var chunked = names.Chunk(3);

            IEnumerable<IEnumerable<T>> ChunkBy<T>(IEnumerable<T> source, int chunkSize)
            {
                return source
                    .Select((x, i) => new { Index = i, Value = x })
                    .GroupBy(x => x.Index / chunkSize)
                    .Select(x => x.Select(v => v.Value));
            }


            //2. TryGetNonEnumeratedCount
            var firstSet = new[] { "Nick Chapsas" };
            var secondSet = new[] { "Peter Chapsas" };
            var thirdSet = new[] { "Maria Chapsas" };

            IEnumerable<string> names2 = firstSet.Concat(secondSet).Concat(thirdSet);

            var count2 = names.Count(); //This will force to execute enumeration twice.
            var orderedNames2 = names.OrderBy(x => x);

            if (names.TryGetNonEnumeratedCount(out var countx))
            {
                //Did not force an enumeration to be executed twice.
            }

            //3. Zipping
            var names3 = new[] { "Nick Chapsas", "Peter Chapsas", "Maria Chapsas" };
            var ages = new[] { 28, 22, 25 };
            var yearsOfExperience = new[] {10, 5, 2 };

            IEnumerable<(string Name, int Age, int YearsOfExp)> zip = names3.Zip(ages, yearsOfExperience);
            
            Console.ReadKey();

            //4. MaxBy, MinBy, Other By's
            // Distinct by, Intersect by, Union by, Accept by
            var family = new[]
            {
                new FamilyMember("Nick Chapsas", 28),
                new FamilyMember("Peter Chapsas", 22),
                new FamilyMember("Maria Chapsas", 25),
            };

            var youngestOld = family.OrderBy(x => x.Age).First();
            var oldestOld = family.OrderByDescending(x => x.Age).First();

            var youngest = family.MinBy(x => x.Age);
            var oldest = family.MaxBy(x => x.Age);

            //5. ElementAt

            var names5 = new[] { "Nick", "Mike", "John", "Leyla", "David", "Damian" };
            var name5 = names5.ElementAt(5);
            var thirdItemFromTheEnd = names5.ElementAt(^3);

            // The result is John and Leyla
            // Documentation = https://www.youtube.com/watch?v=sIXKpyhxHR8
            var slice = names5.Skip(2).Take(2);
            var slice2 = names5.Take(2..4);
            var lastThree = names.Take(^3..);


        }

        public class FamilyMember
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public FamilyMember(string lName, int lAge)
            {
                Name = lName;
                Age = lAge;
            }
        }

        
    }
}