using DungeonMaster.Heroes;

namespace DungeonMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Wizard myWizard = new("Ben");
            myWizard.Display();
        }
    }
}