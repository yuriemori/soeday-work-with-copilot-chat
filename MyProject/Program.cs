// See https://aka.ms/new-console-template for more information

using System.Data;
using System.Reflection;
using System.Text.RegularExpressions;

namespace MyProject
{
    public static class Program
    {        
        static void Main(string[] args)
        {
             // Employeeオブジェクトのリストを作成
            List<Employee> employees = new List<Employee>();

            // ユーザーからの入力を受け取る
            Console.WriteLine("Employeeの情報を入力してください:");
            Console.Write("First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("Age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Department: ");
            string department = Console.ReadLine();
            Console.Write("Address: ");
            string address = Console.ReadLine();
            Console.Write("Phone Number: ");
            string phoneNumber = Console.ReadLine();
            Console.Write("Hire Date (yyyy/MM/dd): ");
            DateTime hireDate = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Salary: ");
            decimal salary = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Position: ");
            string position = Console.ReadLine();        

            // Emailのバリデーション
            if (!IsEmailValid(email))
            {
                Console.WriteLine("無効なメールアドレスです。");
                return;
            }

            // Employeeオブジェクトの作成
            Employee employee = new Employee()
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                Department = department,
                Address = address,
                PhoneNumber = phoneNumber,
                HireDate = hireDate,
                Salary = salary,
                Email = email,
                Position = position
            };

            employees.Add(employee);

            // DataTableに変換
            Employee.ToDataTable(employees);

        }
 

        //適切なメアドだったらtrueを返す
        public static bool IsEmailValid(string email)
        {
            // emailがNullの場合はfalseを返す
            if (email == null)
            {
                return false;
            }
            // 全角文字が含まれているか確認
            if (ContainsFullWidthCharacters(email))
            {
                return false;
            }

            // 正規表現を使用してメールアドレスの形式をチェック
            var regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            // バグ：気付くかどうか微妙な意図的な条件判定ミス
            return !regex.IsMatch(email);            
        }

        private static bool ContainsFullWidthCharacters(string email)
        {
            // 全角文字のUnicode範囲を定義
            int start = 0xFF00;
            int end = 0xFFEF;

            foreach (char c in email)
            {
                // バグ: 最初の文字と最後の文字がチェックから漏れる
                if (c > start && c < end)
                {
                    return true;
                }
            }

            return false;
        }
    }

    public class Employee
    {
        public string FirstName { get; set; }          // Null非許容
        public string LastName { get; set; }           // Null非許容
        public int Age { get; set; }                   // Null非許容
        public string Department { get; set; }         // Null非許容
        public string? Address { get; set; }            // Null許容
        public string? PhoneNumber { get; set; }        // Null許容
        public DateTime? HireDate { get; set; }         // Null許容
        public decimal? Salary { get; set; }            // Null許容
        public string Email { get; set; }              // Null非許容
        public string? Position { get; set; }           // Null許容

       


        public static DataTable ToDataTable<T>(List<T> items)
        {
            var dataTable = new DataTable(typeof(T).Name);

            // プロパティの取得
            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in props)
            {
                // DataTableの列を作成
                dataTable.Columns.Add(prop.Name);
            }

            foreach (T item in items)
            {
                var values = new object[props.Length];

                for (int i = 0; i < props.Length; i++)
                {
                    // プロパティの値を取得
                    values[i] = props[i].GetValue(item, null);
                }

                // バグ：意図的な境界値チェックミス
                if (dataTable.Rows.Count > 10)
                {
                    Console.WriteLine("登録できるデータは10件までです");
                    return dataTable;
                }

                // DataTableに行を追加　バグ：Nullを許容しないデータの登録をblockできない
                dataTable.Rows.Add(values);
            }

            // DataTableを返す
            return dataTable;
        }
    }
}