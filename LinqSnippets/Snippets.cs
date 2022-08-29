namespace LinqSnippets
{
    public class Snippets
    {
        public static IEnumerable<string> BasicLinq()
        {
            string[] cars =
            {
                "WV Golf",
                "WV California",
                "Audi A3",
                "Audi A5",
                "Fiat Punto",
                "Seat Ibiza",
                "Seat León",
                "...Audi..."
            };

            //1. SELECT * of cars
            var carList = from car in cars select car;

            //2. SELECT WHERE car is Audi

            var audiList = from car in cars where car.Contains("Audi") select car;

            return audiList;
        }

        public static void LinqNumbers()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };


            var processedNumberList = numbers.Where(x => x != 9).OrderBy(num => num).Select(x => x * 3);

            foreach (var item in processedNumberList)
            {
                Console.WriteLine(item);
            }
        }
        public static void SearchExamples()
        {
            List<string> textList = new List<string> { "a", "b", "c", "", "e", "f", "", "h", "i", "fffffffffffffj", "" };
            List<string> textList1 = new List<string> { "a" };

            //1.First of all elements
            var first = textList.First();
            Console.WriteLine(first);

            //2. First element that is "c"
            var cText = textList.First(text => text.Equals("c"));
            Console.WriteLine(cText);

            //3. First element that contains "j"
            var jText = textList.First(text => text.Contains("j"));
            Console.WriteLine(jText);

            //4. First element that contains "z" or default
            var firstOrDefaultText = textList.FirstOrDefault(text => text.Contains("z"));//"" or first element that contains "z"
            Console.WriteLine(firstOrDefaultText);

            //5. Last element that contains "z" or default
            var lastOrDefaultText = textList.LastOrDefault(text => text.Contains("z"));//"" or last element that contains "z"
            Console.WriteLine(lastOrDefaultText);


            //6. Single Values
            //var uniqueText = textList1.Single();
            //var uniqueorDefaultTexts = textList1.SingleOrDefault();

            //7. 
            int[] evenNumbers = { 2, 4, 6, 8 };
            int[] otherEvenNumbers = { 2, 0, 6 };
            //Obtain { 4, 8 }
            var myEvenNumbers = evenNumbers.Except(otherEvenNumbers);

            foreach (var item in myEvenNumbers)
            {
                Console.Write(item + " ");
            }

        }

        public static void MultipleSelect()
        {
            //SELECT MANY
            string[] myOpinions =
                {
                "Opinion 1, text 1",
                "Opinion 2, text 2",
                "Opinion 3, text 3"
                };

            var myOpinionSelect = myOpinions.SelectMany(opinion => opinion.Split(","));

            var enterprises = new[]
            {
                new Enterprise()
                {
                    Id = 1,
                    Name="Enterprise 1",
                    Employees = new List<Employee>
                    {
                        new Employee()
                        {
                            Id=1,
                            Name="Martin",
                            Email="martin@gmail.com",
                            Salary=3000
                        },
                        new Employee()
                        {
                            Id=2,
                            Name="Pepe",
                            Email="Pepe@gmail.com",
                            Salary=1000
                        },
                        new Employee()
                        {
                            Id=3,
                            Name="Juanjo",
                            Email="Juanjo@gmail.com",
                            Salary=2000
                        }
                    }
                },
                new Enterprise()
                {
                    Id = 2,
                    Name="Enterprise 2",
                    Employees = new List<Employee>
                    {
                        new Employee()
                        {
                            Id=4,
                            Name="Ana",
                            Email="ana@gmail.com",
                            Salary=3000
                        },
                        new Employee()
                        {
                            Id=5,
                            Name="Naria",
                            Email="maria@gmail.com",
                            Salary=1500
                        },
                        new Employee()
                        {
                            Id=6,
                            Name="Marta",
                            Email="marta@gmail.com",
                            Salary=4000
                        }
                    }
                }
            };

            //Obtain all Employees of all Enterprises
            var employeeList = enterprises.SelectMany(e => e.Employees);

            //Know if any list is empty
            bool hasEnterprises = enterprises.Any();

            bool hasEmployees = enterprises.Any(enterprise => enterprise.Employees.Any());

            //All enterprises at least employees with at least 1000$ of salary
            bool hasEmployeeWithSalaryMoreThanOrEqual1000 =
                enterprises.Any(empresa => empresa.Employees.Any(empleado => empleado.Salary >= 1000));

        }


        public static void LinqCollection()
        {
            var firstList = new List<string>() { "a", "b", "c" };
            var secondList = new List<string>() { "a", "c", "d" };

            // INNER JOIN
            var commonResult = from primerElemento in firstList
                               join segundoElemento in secondList
                               on primerElemento equals segundoElemento
                               select new { primerElemento, segundoElemento };


            var commonResult2 = firstList.Join(
                secondList,
                primerElemento => primerElemento,
                segundoElemento => segundoElemento,
                (primerElemento, segundoElemento) => new { primerElemento, segundoElemento });


            //OUTER JOIN - LEFT

            var leftOuterJoin = from primerElemento in firstList
                                join segundoElemento in secondList
                                on primerElemento equals segundoElemento
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where primerElemento != temporalElement
                                select new { Element = primerElemento };

            var leftOuterJoin2 = from primerElemento in firstList
                                 from segundoElemento in secondList.Where(segElem => segElem == primerElemento).DefaultIfEmpty()
                                 select new { Element = primerElemento, SecondElement = segundoElemento };





            //OUTER JOIN - RIGHT
            var rightOuterJoin = from segundoElemento in secondList
                                 join primerElemento in firstList
                                 on segundoElemento equals primerElemento
                                 into temporalList
                                 from temporalElement in temporalList.DefaultIfEmpty()
                                 where segundoElemento != temporalElement
                                 select new { Element = segundoElemento };

            //UNION
            var unionList = leftOuterJoin.Union(rightOuterJoin);



        }
        public static void SkipTakeLinq()
        {
            var myList = new[]
            {
                1,2,3,4,5,6,7,8,9,10
            };

            //SKIP
            var skipTwoFirstValues = myList.Skip(2);

            var skipLastTwoValues = myList.Skip(2);

            var skipWhileSmallerThan4 = myList.SkipWhile(num => num < 4);

            //TAKE

            var takeTwoFirstValues = myList.Take(2);

            var takeLastTwoValues = myList.TakeLast(2);

            var takeWhileSmallerThan4 = myList.TakeWhile(num => num < 4);
        }


        //Paging with Skip "& Take

        static public IEnumerable<T> GetPage<T>(IEnumerable<T> collection, int pageNumber, int resultsPerPage)
        {
            int startIndex = (pageNumber - 1) * resultsPerPage;
            return collection.Skip(startIndex).Take(resultsPerPage);
        }

        // Variables

        static public void LinqVariables()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var aboveAverage = from number in numbers
                               let average = numbers.Average()
                               let nSquare = Math.Pow(number, 2)
                               where nSquare > average
                               select number;

            foreach (int number in aboveAverage)
            {
                Console.WriteLine("Number: {0} Square: {1}", number, Math.Pow(number, 2));
            }
        }

        //ZIP

        static public void ZipLinq()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6 };
            string[] stringNumbers = { "one", "two", "three", "four", "five", "six" };

            IEnumerable<string> zipNumbers = numbers.Zip(stringNumbers, (number, word) => number + "=" + word);

            //{"1=one", "2=two",...ets}
        }

        static public void RepeatRangeLinq()
        {
            //Generate collection from 1-1000 *--> RANGE
            IEnumerable<int> first1000 = Enumerable.Range(1, 1000);

            //Repeat a value N times
            IEnumerable<string> fiveXs = Enumerable.Repeat("X", 5);
        }

        static public void StudentsLinq()
        {
            var classRoom = new[]
            {
                new Student
                {
                    Id=1,
                    Name="Martín",
                    Grade=90,
                    Certified=true

                },
                new Student
                {
                    Id=2,
                    Name="Juan",
                    Grade=50,
                    Certified=false

                },
                new Student
                {
                    Id=3,
                    Name="Ana",
                    Grade=96,
                    Certified=true

                },
                new Student
                {
                    Id=4,
                    Name="Álvaro",
                    Grade=18,
                    Certified=false

                },
                new Student
                {
                    Id=5,
                    Name="Pedro",
                    Grade=50,
                    Certified=true

                }
            };
            var certifiedStudents = from student in classRoom
                                    where student.Certified
                                    select student;

            var notcertifiedStudents = from student in classRoom
                                       where student.Certified = false
                                       select student;

            var approvedStudents = from student in classRoom
                                   where student.Grade >= 50 && student.Certified == true
                                   select student.Name;
        }

        static public void AllLinq()
        {
            var numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            bool allAreSmallerThan10 = numbers.All(x => x < 10); //true

            bool allAreBiggerOrEqualThan2 = numbers.All(x => x >= 2); //false

            var emptyList = new List<int>();

            bool allNumbersAreGreaterThan0 = emptyList.All(x => x >= 10); //true
        }

        static public void AggregateQueries()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //sum all numbers
            int sum = numbers.Aggregate((prevSum, current) => prevSum + current);

            //0,1 => 1
            //1,2 => 3
            //3,3 => 6
            //6,4 => 10
            //10,5 => 15

            string[] words = { "hello,", "my", "name", "is", "Martín" };
            string greeting = words.Aggregate((prevWord, current) => prevWord + current);

            //"","hello,"=>hello,
            //"hello,","my"=>hello, my
            //etc..
        }

        static public void GroupByExamples()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var grouped = numbers.GroupBy(x => x % 2 == 0);


            // Obtain only even numbers and generate two groups
            // We will have two groups:
            // 1.The group that doesnt fit the condition (odd numbers)
            // 2.The gruop that fit the condition (even numbers)

            foreach (var group in grouped)
            {
                foreach (var value in group)
                {
                    Console.WriteLine(value);//1,3,5,7,9... 2,4,6,8,10 (first the odds and then the even)
                }
            }

            // Another example

            var classRoom = new[]
            {
                new Student
                {
                    Id=1,
                    Name="Martín",
                    Grade=90,
                    Certified=true

                },
                new Student
                {
                    Id=2,
                    Name="Juan",
                    Grade=50,
                    Certified=false

                },
                new Student
                {
                    Id=3,
                    Name="Ana",
                    Grade=96,
                    Certified=true

                },
                new Student
                {
                    Id=4,
                    Name="Álvaro",
                    Grade=18,
                    Certified=false

                },
                new Student
                {
                    Id=5,
                    Name="Pedro",
                    Grade=50,
                    Certified=true

                }
            };

            var certifiedQuery = classRoom.GroupBy(student => student.Certified);

            // We obtain two groups
            // 1. Not certified Students
            // 2. Certified Students

            foreach (var item in certifiedQuery)
            {
                Console.WriteLine(item.Key);
                foreach (var student in item)
                {
                    Console.WriteLine(student.Name);
                }
            }
        }

        static public void RelationsLinq()
        {
            List<Post> post = new List<Post>
            {
                new Post
                {
                    Id=1,
                    Tittle="My fisrt post",
                    Content= "My first content",
                    Created=DateTime.Now,
                    Comments= new List<Comment>()
                    {
                        new Comment()
                        {
                            Id=1,
                            Created= DateTime.Now,
                            Tittle="My first comment",
                            Content="My first content"
                        },
                        new Comment()
                        {
                            Id=2,
                            Created= DateTime.Now,
                            Tittle="My second comment",
                            Content="My second content"
                        }
                    }

                },
                new Post
                {
                    Id=2,
                    Tittle="My second post",
                    Content= "My second content",
                    Created=DateTime.Now,
                    Comments= new List<Comment>()
                    {
                        new Comment()
                        {
                            Id=3,
                            Created= DateTime.Now,
                            Tittle="My third comment",
                            Content="My third content"
                        },
                        new Comment()
                        {
                            Id=4,
                            Created= DateTime.Now,
                            Tittle="My fourth comment",
                            Content="My fourth content"
                        }
                    }
                }
            };

            var commentContent = post.SelectMany(post => post.Comments,
                (post, comment) => new { PostId = post.Id, CommentContent = comment.Content });

        }
    }
}
