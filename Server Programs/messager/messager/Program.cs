using System.Net;
using System.Net.Sockets;

class program {
    class User {
        public string username;
        public string password;
        public TcpClient tcpClient;
        public User(string USERNAME, string PASSWORD) {
            this.username = USERNAME;
            this.password = PASSWORD;
        }
    }
    static void Main(string[] args)
    {
        string username;
        string password;

        // have the user login
        Console.WriteLine("Login, please.");
        Console.Write("Username:");
        username = Console.ReadLine();
        Console.Write("Password:");
        password = Console.ReadLine();

        Console.Write("Creating User...");
        User user = new User(username, password);
        Console.Write(" done\n");
    }
}