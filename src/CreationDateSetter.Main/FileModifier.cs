namespace CreationDateSetter.Main
{
    public class FileModifier
    {
        public static void ChangeCreationDate(string absolutePath, DateTimeOffset creationDate)
        {
            try
            {
                Directory.SetCreationTime(absolutePath, creationDate.DateTime);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unable to set creation date {creationDate} for file {absolutePath}. Got exception {ex.Message}");
            }
            
        }
    }
}
