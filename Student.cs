
namespace GradeBook
{
    class Student
    {
        public Student(string name)
        {
            Grades = new List<double>();
            this.name = name;
        }
        public void printGrades()
        {
            System.Console.WriteLine($"Lista das Notas de {this.name}:");
            foreach (var grade in this.Grades)
            {
                if (grade >= 60)
                {
                    Program.PrintColorMessage(ConsoleColor.Green, $"{grade}");
                    Program.PrintColorMessage(ConsoleColor.White, "------------------------");
                }

                else
                {
                    Program.PrintColorMessage(ConsoleColor.Red, $"{grade}");
                    Program.PrintColorMessage(ConsoleColor.White, "------------------------");
                }
            }
        }
        public void printAverage()
        {
            double sum = 0;
            foreach (int grade in this.Grades)
            {
                sum += grade;
            }
            System.Console.WriteLine($"A soma das Notas é: {sum}");
            Program.PrintColorMessage(ConsoleColor.White, "------------------------");
            var avg = sum / this.Grades.Count;
            System.Console.WriteLine($"A média é: {avg}");
            Program.PrintColorMessage(ConsoleColor.White, "------------------------");
        }

        public static void addGrade(List<Student> alunos, int index, double grade)
        {

            alunos[index].Grades.Add(grade);

        }
        public static string getName(List<Student> alunos, int index)
        {
            string name = alunos[index].name;
            return name;
        }

        public static void getStudentsList(List<Student> alunos)
        {
            Program.PrintColorMessage(ConsoleColor.Yellow, "\nDigite 0 a qualquer momento para retornar ao menu principal\n");
            for (int i = 0; i < alunos.Count; i++)
            {
                Program.PrintColorMessage(ConsoleColor.White, "------------------------");
                Program.PrintColorMessage(ConsoleColor.Green, $"{i + 1}- {alunos[i].name} ");
            }
        }

        private List<double> Grades;
        private string name;

    }
}
