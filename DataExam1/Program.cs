namespace DataExam1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Import and create the Tree
            Console.WriteLine("Import and create the Tree");
            Thread.Sleep(4000);

            List<DefenceStrategies>? DefencesList = Utilities
                .ReadFromJson<List<DefenceStrategies>>("defenceStrategiesBalanced.json");
            DefenceStrategiesBST defenceStrategiesBST = new DefenceStrategiesBST();
            defenceStrategiesBST.InsertList(DefencesList);

            
            //print the tree
            Console.WriteLine("print the tree");
            Thread.Sleep(4000);
            defenceStrategiesBST.PreOrder();

            //Import threats from json file
            Console.WriteLine("Import threats from json file");
            Thread.Sleep(4000);
            List<Threats>? Threatslist = Utilities
                .ReadFromJson<List<Threats>>("defenceStrategiesBalanced.json");

            //Active the the defences
            Utilities.ActiveDefenceLoop(defenceStrategiesBST, Threatslist);


        }
    }
}
