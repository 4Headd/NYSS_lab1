using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lab1
{
    class Notebook
    {
        private Dictionary<int, Person> notes;
        private int id = 1;
        public Notebook()
        {
            notes = new Dictionary<int, Person>();
        }

        public void AddNote(Person person)
        {   
            notes.Add(id, person);
            ++id;
        }


        public bool EditNote(int id)
        {
            if (notes.ContainsKey(id))
            {
                Person person = new Person();
                person.FillFields();
                notes[id] = person;
                return true;
            }
            return false;
        }


        public bool RemoveNote(int id)
        {
            if (notes.ContainsKey(id))
            {
                notes.Remove(id);
                return true;
            }
            return false;
        }

        public Person Find(int id)
        {
            if (notes.ContainsKey(id))
            {
                
                return notes[id];
            }
            return null;
        }
        
        public void PrintAll()
        {
            foreach (var note in notes)
            {
                Console.WriteLine("#" + note.Key + " " + note.Value.Surname + " " + note.Value.Name + " " + note.Value.PhoneNumber);
            }
        }

        public void ConsoleMenuInfo()
        {
            Console.WriteLine("Лист команд:");
            Console.WriteLine("ADD, чтобы добавить запись в книжку");
            Console.WriteLine("EDIT, чтобы редактировать существующую запись в книжке");
            Console.WriteLine("DELETE, чтобы удалить существующую запись в книжке");
            Console.WriteLine("FIND, чтобы вывести все существующие в книжке записи");
            Console.WriteLine("PRINT, чтобы вывести краткую информацию о всех записях");
            Console.WriteLine("INFO, чтобы вывести лист команд");
            Console.WriteLine("END, чтобы выйти");
        }

        public void ConsoleMenu()
        {
            ConsoleMenuInfo();

            Commands command;
            do
            {
                Enum.TryParse(Console.ReadLine(), out command);
                switch (command)
                {
                    case Commands.ADD:
                        {
                            Person person = new Person();
                            person.FillFields();
                            AddNote(person);
                            break;
                        }


                    case Commands.EDIT:
                        {
                            Console.Write("Введите id записи, которую желаете изменить: ");
                            int idToEdit = Convert.ToInt32(Console.ReadLine());

                            if (EditNote(idToEdit))
                            {
                                Console.WriteLine($"Запись с id {idToEdit} изменена");
                            }
                            else
                            {
                                Console.WriteLine($"Запись с id {idToEdit} не существует");
                            }

                            break;
                        }


                    case Commands.DELETE:
                        Console.Write("Введите id записи, которую желаете удалить: ");
                        int idToDelete = Convert.ToInt32(Console.ReadLine());

                        if (RemoveNote(idToDelete))
                        {
                            Console.WriteLine($"Запись с id {idToDelete} удалена");
                        }
                        else
                        {
                            Console.WriteLine($"Записи с id {idToDelete} не существует");
                        }

                        break;


                    case Commands.FIND:
                        {
                            Console.Write("Введите id записи, которую желаете найти: ");
                            int idToFind = Convert.ToInt32(Console.ReadLine());

                            Person person = Find(idToFind);

                            if (person != null)
                            {
                                Console.WriteLine(person);
                            }
                            else
                            {
                                Console.WriteLine($"Записи id {idToFind} не существует");
                            }

                            break;
                        }


                    case Commands.PRINT:
                        PrintAll();
                        break;


                    case Commands.INFO:
                        ConsoleMenuInfo();
                        break;


                    case Commands.END:
                        break;


                    default:
                        Console.WriteLine("Неверная команда");
                        break;
                }
            } while (command != Commands.END);

        }

        static void Main(string[] args)
        {
            Notebook notebook = new Notebook();
            notebook.ConsoleMenu();
        }
    }

    public enum Commands
    {
        ERROR, // default value
        ADD,
        EDIT,
        DELETE,
        FIND,
        PRINT,
        INFO,
        END
    }
}
