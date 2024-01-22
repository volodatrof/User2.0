using System;

using System.Collections.Generic;

using System.IO;

using System.Linq;

class Program

{

    static List<User> users = new List<User>();

    static void Main()

    {

        Console.OutputEncoding = System.Text.Encoding.UTF8;

        while (true)

        {

            Console.WriteLine("1. Показати всіх користувачів");

            Console.WriteLine("2. Показати користувача за іменем");

            Console.WriteLine("3. Додати користувача");

            Console.WriteLine("4. Оновити користувача");

            Console.WriteLine("5. Видалити користувача");

            Console.WriteLine("6. Зберегти у файл");

            Console.WriteLine("7. Зчитати з файлу");

            Console.WriteLine("8. Вихід");

            Console.Write("Зробіть вибір: ");

            string choice = Console.ReadLine();

            switch (choice)

            {

                case "1":

                    ShowAllUsers();

                    break;

                case "2":

                    ShowUserByNameFromConsole();

                    break;

                case "3":

                    AddUserFromConsole();

                    break;

                case "4":

                    UpdateUserFromConsole();

                    break;

                case "5":

                    DeleteUserFromConsole();

                    break;

                case "6":

                    SaveToFile("users.txt");

                    break;

                case "7":

                    ReadFromFile("users.txt");

                    break;

                case "8":

                    Console.WriteLine("Вихід з програми");

                    return;

                default:

                    Console.WriteLine("ПОМИЛКА");

                    break;

            }

        }

    }

    static void AddUserFromConsole()

    {

        Console.Write("Введіть ім'я: ");

        string userName = Console.ReadLine();

        Console.Write("Введіть прізвище: ");

        string userLastName = Console.ReadLine();

        Console.Write("Введіть email: ");

        string userEmail = Console.ReadLine();

        Console.Write("Введіть номер телефону: ");

        string userPhoneNumber = Console.ReadLine();

        if (IsUniqueName(userName) && IsUniquePhoneNumber(userPhoneNumber) && IsNameValid(userName) && IsNameValid(userLastName) && IsEmailValid(userEmail) && IsPhoneNumberValid(userPhoneNumber))

        {

            AddUser(new User(userName, userLastName, userEmail, userPhoneNumber));

            Console.WriteLine("Успішно!");

        }

        else

        {

            Console.WriteLine("Помилка в імені прізвищі email або номері телефону");

        }

    }

    static bool IsUniqueName(string name)

    {

        return !users.Any(u => u.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

    }

    /*static void ShowUserByIdFromConsole()

    {

        Console.Write("Введіть ід користувача: ");

        if (int.TryParse(Console.ReadLine(), out int userId))

        {

            ShowUserById(userId);

        }

        else

        {

            Console.WriteLine("Невірний ід");

        }

    }*/

    static bool IsUniquePhoneNumber(string phoneNumber)

    {

        return !users.Any(u => u.PhoneNumber.Equals(phoneNumber));

    }

    static void ShowAllUsers()

    {

        if (users.Any())

        {

            foreach (var user in users)

            {

                Console.WriteLine($"Ім'я: {user.Name}, Прізвище: {user.LastName}, Email: {user.Email}, Номер телефону: {user.PhoneNumber}");

            }

        }

        else

        {

            Console.WriteLine("Немає користувачів");

        }

    }

    static void ShowUserByNameFromConsole()

    {

        Console.Write("Введіть ім'я користувача: ");

        string userName = Console.ReadLine();

        if (IsNameValid(userName))

        {

            ShowUserByName(userName);

        }

        else

        {

            Console.WriteLine("Помилка в імені");

        }

    }

    static void UpdateUserFromConsole()

    {

        Console.Write("Введіть ім'я для оновлення: ");

        string oldUserName = Console.ReadLine();

        Console.Write("Нове ім'я користувача: ");

        string newUserName = Console.ReadLine();

        Console.Write("Нове прізвище користувача: ");

        string newUserLastName = Console.ReadLine();

        Console.Write("Новий email: ");

        string newUserEmail = Console.ReadLine();

        Console.Write("Новий номер телефону: ");

        string newUserPhoneNumber = Console.ReadLine();

        if (IsNameValid(oldUserName) && IsNameValid(newUserName) && IsNameValid(newUserLastName) && IsEmailValid(newUserEmail) && IsPhoneNumberValid(newUserPhoneNumber))

        {

            UpdateUser(oldUserName, new User(newUserName, newUserLastName, newUserEmail, newUserPhoneNumber));

            Console.WriteLine("Успішно");

        }

        else

        {

            Console.WriteLine("Помилка в імені, прізвищі, email або номері телефону");

        }

    }

    static void DeleteUserFromConsole()

    {

        Console.Write("Введіть ім'я користувача: ");

        string deleteUser = Console.ReadLine();

        if (IsNameValid(deleteUser))

        {

            DeleteUser(deleteUser);

            Console.WriteLine("");

        }

        else

        {

            Console.WriteLine("Помилка в імені");

        }

    }

    static bool IsNameValid(string name)

    {

        return !string.IsNullOrWhiteSpace(name);

    }

    static bool IsEmailValid(string email)

    {

        return !string.IsNullOrWhiteSpace(email) && email.Contains("@");

    }

    static bool IsPhoneNumberValid(string phoneNumber)

    {

        return !string.IsNullOrWhiteSpace(phoneNumber);

    }

    static void AddUser(User user)

    {

        users.Add(user);

    }

    static void ShowUserByName(string name)

    {

        var user = users.FirstOrDefault(u => u.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (user != null)

        {

            Console.WriteLine($"Ім'я: {user.Name}, Прізвище: {user.LastName}, Email: {user.Email}, Номер телефону: {user.PhoneNumber}");

        }

        else

        {

            Console.WriteLine("Користувача не знайдено");

        }

    }

    static void DeleteUser(string name)

    {

        var user = users.FirstOrDefault(u => u.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (user != null)

        {

            users.Remove(user);

            Console.WriteLine("Користувача видалено");

        }

        else

        {

            Console.WriteLine("Користувача не знайдено");

        }

    }

    static void UpdateUser(string oldName, User newUser)

    {

        var user = users.FirstOrDefault(u => u.Name.Equals(oldName, StringComparison.OrdinalIgnoreCase));

        if (user != null)

        {

            user.Name = newUser.Name;

            user.LastName = newUser.LastName;

            user.Email = newUser.Email;

            user.PhoneNumber = newUser.PhoneNumber;

            Console.WriteLine("Користувача оновлено");

        }

        else

        {

            Console.WriteLine("Користувача не знайдено");

        }

    }

    static void SaveToFile(string fileName)

    {

        using (StreamWriter sw = new StreamWriter(fileName))

        {

            foreach (var user in users)

            {

                sw.WriteLine($"{user.Name},{user.LastName},{user.Email},{user.PhoneNumber}");

            }

        }

        Console.WriteLine("Дані збережено у файл");

    }

    static void ReadFromFile(string fileName)

    {

        users.Clear();

        using (StreamReader sr = new StreamReader(fileName))

        {

            string line;

            while ((line = sr.ReadLine()) != null)

            {

                string[] parts = line.Split(',');

                if (parts.Length == 4)

                {

                    users.Add(new User(parts[0], parts[1], parts[2], parts[3]));

                }

            }

        }

        Console.WriteLine("Дані завантажено з файлу");

    }

}

class User

{

    public string Name { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public User(string name, string lastName, string email, string phoneNumber)

    {

        Name = name;

        LastName = lastName;

        Email = email;

        PhoneNumber = phoneNumber;

    }

}