namespace MonkeyShock.Dyn365.Utilities.Common
{
    public interface IConsole
    {
        string ReadLine();

        void Write(string value);

        void WriteLine();

        void WriteLine(string value); 
    }
}
