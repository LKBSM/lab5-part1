using System;
using System.Diagnostics;

namespace lab5_part_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string logMessage = "Operation completed successfully.";
            EventLogEntryType logType = EventLogEntryType.Information;

            try
            {
                Console.Write("Enter the first number: ");
                // Try to parse the first number
                int num1 = int.Parse(Console.ReadLine());

                Console.Write("Enter the second number: ");
                // Try to parse the second number
                int num2 = int.Parse(Console.ReadLine());

                // Check for division by zero
                if (num2 == 0)
                {
                    throw new DivideByZeroException("Cannot divide by zero.");
                }

                // Perform the division
                double result = (double)num1 / num2;
                Console.WriteLine($"Result of {num1} / {num2} = {result}");
            }
            // Handle multiple exceptions with different catch blocks
            catch (FormatException ex)
            {
                // This catches errors from int.Parse()
                Console.WriteLine("Error: Please enter valid integers.");
                logMessage = $"Error: {ex.Message}";
                logType = EventLogEntryType.Error;
            }
            catch (DivideByZeroException ex)
            {
                // This catches the division by zero
                Console.WriteLine("Error: Cannot divide by zero.");
                logMessage = $"Error: {ex.Message}";
                logType = EventLogEntryType.Error;
            }
            catch (Exception ex)
            {
                // A general handler for any other unexpected errors
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                logMessage = $"Unexpected Error: {ex.Message}";
                logType = EventLogEntryType.Error;
            }
            finally
            {
                // This block always executes to log the error (or success) 
                LogToEventViewer(logMessage, logType);
                Console.WriteLine("\nLogging attempt finished. Press Enter to exit.");
                Console.ReadLine();
            }
        }

        static void LogToEventViewer(string message, EventLogEntryType type)
        {
            // Note: Writing to the Event Log may require administrator privileges.
            // You may need to run Visual Studio as an Administrator for this to work.
            try
            {
                // Use the "Application" log as specified
                using (EventLog eventLog = new EventLog("Application"))
                {
                    // Set the source as specified
                    eventLog.Source = "Application";

                    // Write the entry
                    eventLog.WriteEntry(message, type, 101, 1);
                }
                Console.WriteLine("Successfully logged to Event Viewer.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CRITICAL ERROR: Could not write to Event Log. \nReason: {ex.Message}");
                Console.WriteLine("Please try running Visual Studio as an Administrator.");
            }
        }
    }
}