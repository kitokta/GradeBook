namespace GradeBook
{
    class Menu
    {
        public static void home()
        {
            bool exit = false;
            do
            {
                Program.PrintColorMessage(ConsoleColor.Green, "\nBem vinde ao sistema!\nEscolha a opção desejada: ");
                Program.PrintColorMessage(ConsoleColor.White, "------------------------");
                Program.PrintColorMessage(ConsoleColor.Cyan, "1 - Cadastrar novo aluno");
                Program.PrintColorMessage(ConsoleColor.White, "------------------------");
                Program.PrintColorMessage(ConsoleColor.Cyan, "2 - Acessar dados aluno");
                Program.PrintColorMessage(ConsoleColor.White, "------------------------");
                Program.PrintColorMessage(ConsoleColor.Cyan, "3 - Sair");
                Program.PrintColorMessage(ConsoleColor.White, "------------------------");
                string input = Console.ReadLine();
                Console.Clear();
                var choice = checkChoice(input, "home");
                if (choice == false) Menu.home();
                else
                {

                    if (input == "1") Register();

                    else if (input == "2") studentsData();

                    else if (input == "3")
                    {
                        Program.PrintColorMessage(ConsoleColor.Green, "\nObrigade por usar nosso sistema!\n");
                        exit = true;
                    }
                }
            } while (exit != true);
        }

        public static void Register()
        {
            Program.PrintColorMessage(ConsoleColor.Yellow, "\nDigite 0 a qualquer momento para retornar ao menu principal");
            Program.PrintColorMessage(ConsoleColor.White, "------------------------");
            Program.PrintColorMessage(ConsoleColor.Green, "Tela de cadastro\n\nPor favor digite o nome do aluno: ");
            string name = Console.ReadLine();
            Console.Clear();
            if (name != "0")
            {
                Student aluno = new Student(name);
                alunos.Add(aluno);
                bool exit = false;
                do
                {
                    Program.PrintColorMessage(ConsoleColor.White, "------------------------");
                    Program.PrintColorMessage(ConsoleColor.Green, "Você gostaria de cadastrar mais um aluno?");
                    Program.PrintColorMessage(ConsoleColor.White, "------------------------");
                    Program.PrintColorMessage(ConsoleColor.Cyan, "1 - Cadastrar novo aluno");
                    Program.PrintColorMessage(ConsoleColor.White, "------------------------");
                    Program.PrintColorMessage(ConsoleColor.Cyan, "0 - Voltar ao menu");
                    Program.PrintColorMessage(ConsoleColor.White, "------------------------");
                    string input = Console.ReadLine();
                    Console.Clear();
                    bool choice = checkChoice(input, "cadastro");
                    if (choice == true)
                    {
                        if (input == "1") { exit = true; Register(); }
                        else if (input == "0") { exit = true; }
                    }
                } while (exit != true);
            }
        }

        public static void studentsData()
        {
            bool exit = false;
            bool choice;
            do
            {
                Student.getStudentsList(alunos);
                Program.PrintColorMessage(ConsoleColor.Green, "\nEscolha o aluno que deseja verificar as informações: ");
                string input = Console.ReadLine();
                Console.Clear();
                choice = checkChoice(input, "studentsData");
                if (input == "0") exit = true;
                else if (choice == true && exit != true) studentMenu(input);
            } while (choice != true);
        }

        public static void studentMenu(string input)
        {
            bool exit = false;
            bool choice;
            do
            {
                int index = Int32.Parse(input);
                string name = Student.getName(alunos, index - 1);
                Program.PrintColorMessage(ConsoleColor.Yellow, "\nDigite 0 a qualquer momento para retornar ao menu principal");
                Program.PrintColorMessage(ConsoleColor.White, "------------------------");
                Program.PrintColorMessage(ConsoleColor.Green, $"Você está vendo as informações de: {name}");
                Program.PrintColorMessage(ConsoleColor.White, "------------------------");
                Program.PrintColorMessage(ConsoleColor.Cyan, "1 - Adicionar Nota");
                Program.PrintColorMessage(ConsoleColor.White, "------------------------");
                Program.PrintColorMessage(ConsoleColor.Cyan, "2 - Imprimir Notas");
                Program.PrintColorMessage(ConsoleColor.White, "------------------------");
                Program.PrintColorMessage(ConsoleColor.Cyan, "3 - Imprimir Média");
                Program.PrintColorMessage(ConsoleColor.White, "------------------------");
                Program.PrintColorMessage(ConsoleColor.Cyan, "0 - Voltar ao menu");
                Program.PrintColorMessage(ConsoleColor.White, "------------------------");
                var inputChoice = Console.ReadLine();
                choice = checkChoice(inputChoice, "studentsMenu");
                Console.Clear();
                if (choice == true)
                {
                    int checkQuantity;
                    if (inputChoice == "1")
                    {
                        bool noteAdded = false;

                        while (noteAdded != true)
                        {
                            Program.PrintColorMessage(ConsoleColor.Green, "Quantas notas deseja adicionar agora?");
                            var quantity = Console.ReadLine();
                            if (!int.TryParse(quantity, out checkQuantity)) Program.PrintColorMessage(ConsoleColor.Red, "\nPor favor digite um número...");
                            else
                            {
                                checkQuantity = Int32.Parse(quantity);
                                int i = 0;
                                int j = 1;
                                bool validNote;
                                double grade;
                                while (i != checkQuantity)
                                {
                                    do
                                    {
                                        validNote = false;
                                        Program.PrintColorMessage(ConsoleColor.Green, $"Escreva a nota número {j}");
                                        var inputGrade = Console.ReadLine();
                                        if (double.TryParse(inputGrade, out grade))
                                        {
                                            grade = Double.Parse(inputGrade);
                                        }

                                        if (!double.TryParse(inputGrade, out grade))
                                        {
                                            Program.PrintColorMessage(ConsoleColor.Red, "Por favor, digite uma nota válida.");
                                        }
                                        else if (grade < 0 || grade > 100)
                                        {
                                            Program.PrintColorMessage(ConsoleColor.Red, "Por favor, digite uma nota válida.");
                                        }
                                        else
                                        {
                                            validNote = true;
                                            Student.addGrade(alunos, index - 1, grade);
                                            j++;
                                            i++;
                                            if (i == checkQuantity) noteAdded = true;
                                        }
                                    } while (validNote != true);
                                    Console.Clear();

                                }
                            }
                        }
                    }

                    else if (inputChoice == "2")
                    {
                        alunos[index - 1].printGrades();
                    }

                    else if (inputChoice == "3")
                    {
                        alunos[index - 1].printAverage();
                    }

                    else if (inputChoice == "0")
                    {
                        exit = true;
                    }

                }
            } while (exit != false);
        }



        public static bool checkChoice(string inputChoice, string menu)
        {
            int choice = 0;
            if (int.TryParse(inputChoice, out choice))
            {
                choice = Int32.Parse(inputChoice);
            }

            if (menu == "home")
            {
                if (!int.TryParse(inputChoice, out choice) || (choice > 3 && choice <= 0))
                {
                    Program.PrintColorMessage(ConsoleColor.Red, "\nEssa não é uma opção válida...");
                    return false;
                }
                return true;
            }

            else if (menu == "cadastro")
            {
                if (!int.TryParse(inputChoice, out choice) || (choice > 1 && choice < 0))
                {
                    Program.PrintColorMessage(ConsoleColor.Red, "\nEssa não é uma opção válida...");
                    return false;
                }
                return true;
            }
            else if (menu == "studentsData")
            {
                if (!int.TryParse(inputChoice, out choice) || choice > alunos.Count || choice < 0)
                {
                    Program.PrintColorMessage(ConsoleColor.Red, "\nEssa não é uma opção válida...");
                    return false;
                }
                return true;
            }
            else if (menu == "studentsMenu")
            {
                if (!int.TryParse(inputChoice, out choice) || choice > 3 || choice < 0)
                {
                    Program.PrintColorMessage(ConsoleColor.Red, "\nEssa não é uma opção válida...");
                    return false;
                }
                return true;
            }
            return false;
        }



        private static List<Student> alunos = new List<Student>();
        private static List<double> notas = new List<double>();
    }
}