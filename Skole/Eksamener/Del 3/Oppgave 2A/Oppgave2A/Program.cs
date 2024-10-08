namespace StudentSøknad
{
    class Program
    {
        static void Main()
        {
            var student = new StudentStatus();
            
            // Demonstrasjon av bruk
            Console.WriteLine($"Current Status: {student.Status}"); 
            // Forventet resultat: "Har Søkt"
            
            student.ChangeStatus("Levert dokumentasjon");
            Console.WriteLine($"Updated Status: {student.Status}"); 
            // Forventet resultat: "Levert dokumentasjon"
            
            Console.WriteLine($"Had Status 'Har Søkt': {student.HadStatus("Har Søkt")}"); 
            // Forventet resultat: true
            Console.WriteLine($"Had Status 'Fått Tilbud': {student.HadStatus("Fått Tilbud")}"); 
            // Forventet resultat: false
        }
    }
}