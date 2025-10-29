using System;

namespace lab5_part_2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter a new password: ");
                string password = Console.ReadLine();

                // Call the method that checks the password
                CheckPasswordComplexity(password);

                // If no exception is thrown, the password is valid
                Console.WriteLine("Password meets the length requirement.");
            }
            catch (PasswordComplexityException ex) // Handle the custom exception
            {
                Console.WriteLine($"Invalid Password Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle any other unexpected errors
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Password check complete. Press Enter to exit.");
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Checks if a password is at least 8 characters long.
        /// </summary>
        /// <param name="password">The password string to check.</param>
        public static void CheckPasswordComplexity(string password)
        {
            // Check if length is at least 8 characters
            if (string.IsNullOrEmpty(password) || password.Length < 8)
            {
                // Throw the custom exception if the rule is violated
                throw new PasswordComplexityException("Password must be at least 8 characters long.");
            }
        }
    }
}