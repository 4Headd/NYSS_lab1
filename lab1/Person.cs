using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }

        
        public int PhoneNumber { get; set; }

        public string Country { get; set; }

        public string BirthDate { get; set; }

        public string Organization { get; set; }

        public string Position { get; set; }

        public string OtherNotes { get; set; }


        public void FillFields()
        {
            Console.Write("Фамилия: ");
            Surname = ValidateRequiredFields(Console.ReadLine(), "Фамилия");

            Console.Write("Имя: ");
            Name = ValidateRequiredFields(Console.ReadLine(), "Имя");

            Console.Write("Отчество (необязательно): ");
            Patronymic = Console.ReadLine();

            Console.Write("Номер телефона: ");
            int phoneNumber;
            while (!int.TryParse(Console.ReadLine(), out phoneNumber))
            {
                Console.WriteLine("Данное поле является обязательным для заполнения только цифрами");
                Console.Write("Номер телефона: ");
            }
            PhoneNumber = phoneNumber;

            Console.Write("Страна: ");
            Country = ValidateRequiredFields(Console.ReadLine(), "Страна");

            Console.Write("Дата рождения (необязательно): ");
            BirthDate = Console.ReadLine();

            Console.Write("Организация (необязательно): ");
            Organization = Console.ReadLine();

            Console.Write("Должность (необязательно): ");
            Position = Console.ReadLine();

            Console.Write("Заметки (необязательно): ");
            OtherNotes = Console.ReadLine();
        }

        private string ValidateRequiredFields(string fieldValue, string fieldName)
        {
            while (string.IsNullOrEmpty(fieldValue))
            {
                Console.WriteLine("Данное поле является обязательным для заполнения");
                Console.Write(fieldName + ": ");
                fieldValue = Console.ReadLine();
            }
            return fieldValue;
        }

        public override string ToString()
        {
            return $"{Surname} {Name} {Patronymic}".Trim() + $" {PhoneNumber} " + (((($"{Country} {BirthDate}").Trim() + $" {Organization} ").Trim() + $" {Position} ").Trim() + $" {OtherNotes} ").Trim();
        }

    }
}
