namespace ExceptionHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BasicExceptionHandling();
            MultipleExceptionTypes();
            FinalyBlockUsage();
            CustomExceptionClass();
            ExceptionPropagation();
            UsingThrowAndCatch();
        }

        static void BasicExceptionHandling()
        {
            Console.Write("Enter a number: ");
            try
            {
                // Convert the input to an integer using int.Parse().
                int number = int.Parse(Console.ReadLine());

                // Output the input if correct
                Console.WriteLine($"You entered: {number}");
            }
            catch (FormatException)
            {
                // Handle FormatException if the user enters a non-numeric value.
                Console.WriteLine("Error: Please enter a valid number.");
            }
        }

        static void MultipleExceptionTypes()
        {
            Console.Write("Enter a number: ");
            try
            {
                // Implement BasicExceptionHandling code with the following modification
                int number = int.Parse(Console.ReadLine());

                // Output the input if correct
                Console.WriteLine($"You entered: {number}");
            }
            catch (FormatException)
            {
                // Handle FormatException if the user enters a non-numeric value.
                Console.WriteLine("Error: Please enter a valid number.");
            }
            catch (OverflowException)
            {
                // Handle OverflowException for cases where the number is too large or small for an int.
                Console.WriteLine("Error: The number is too large or too small for an integer.");
            }
        }

        static void FinalyBlockUsage()
        {
            Console.Write("Enter a number: ");
            try
            {
                // Implement BasicExceptionHandling code with the following modification
                int number = int.Parse(Console.ReadLine());

                // Output the input if correct
                Console.WriteLine($"You entered: {number}");
            }
            catch (FormatException)
            {
                // Handle FormatException if the user enters a non-numeric value.
                Console.WriteLine("Error: Please enter a valid number.");
            }
            finally
            {
                // Display a message whether an exception was caught or not.
                Console.WriteLine("executed.");
            }
        }

        // Class for custom exception type
        class NegativeNumberException : ApplicationException
        {
            public NegativeNumberException(string message) : base(message) { }
        }

        static void CustomExceptionClass()
        {
            Console.Write("Enter a number: ");
            try
            {
                // Implement BasicExceptionHandling code with the following modification
                int number = int.Parse(Console.ReadLine());

                // Throw NegativeNumberException if the user enters a negative number.
                if (number < 0)
                {
                    throw new NegativeNumberException("Error: Negative numbers are not allowed.");
                }

                // Output the input if correct
                Console.WriteLine($"You entered: {number}");
            }
            catch (FormatException)
            {
                // Handle FormatException if the user enters a non-numeric value.
                Console.WriteLine("Error: Please enter a valid number.");
            }
            catch (NegativeNumberException ex)
            {
                // Handle NegativeNumberException and display an appropriate message.
                Console.WriteLine(ex.Message);
            }
        }

        static void ExceptionPropagation()
        {
            Console.Write("Enter a number: ");
            try
            {
                // Implement BasicExceptionHandling code with the following modification
                int number = int.Parse(Console.ReadLine());

                // Call CheckNumber inside a try block and handle the exception.
                CheckNumber(number);

                // Output the input if correct
                Console.WriteLine($"You entered: {number}");
            }
            catch (FormatException)
            {
                // Handle FormatException if the user enters a non-numeric value.
                Console.WriteLine("Error: Please enter a valid number.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                // Handle ArgumentOutOfRangeException thrown by CheckNumber.
                Console.WriteLine(ex.Message);
            }
        }

        // Function to check if a number is greater than 100
        static void CheckNumber(int number)
        {
            if (number > 100)
            {
                throw new ArgumentOutOfRangeException("Error: Number cannot be greater than 100.");
            }
        }

        static void UsingThrowAndCatch()
        {
            Console.Write("Enter a number: ");
            try
            {
                // Implement BasicExceptionHandling code with the following modification
                int number = int.Parse(Console.ReadLine());

                // Modify the CheckNumberWithLogging function to log the exception message before throwing it.
                CheckNumberWithLogging(number);

                // Output the input if correct
                Console.WriteLine($"You entered: {number}");
            }
            catch (FormatException)
            {
                // Handle FormatException if the user enters a non-numeric value.
                Console.WriteLine("Error: Please enter a valid number.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                // Catch the exception in the main program and display the logged message.
                Console.WriteLine($"Logged Exception: {ex.Message}");
            }
        }

        // Function to check if a number is greater than 100 and log the exception message
        static void CheckNumberWithLogging(int number)
        {
            try
            {
                if (number > 100)
                {
                    throw new ArgumentOutOfRangeException("Error: Number cannot be greater than 100.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception message before re-throwing it.
                Console.WriteLine($"Logging: {ex.Message}");
                throw;
            }
        }
    }
}
