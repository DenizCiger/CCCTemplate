namespace CCCTemplate
{
    internal class Program
    {
        public const int LEVEL = 1;
        static void Main(string[] args)
        {
            string[][] inputs = Util.GetInputs(LEVEL);
            List<string[]> outputs = new List<string[]>();

            HandleInputs(inputs, outputs);

            Util.GenerateOutputs(LEVEL, outputs.ToArray());
            bool exampleOutEquals = Util.CompareExampleOutEquals(LEVEL, $"level{LEVEL}_example.out");
        }
        private static void HandleInputs(string[][] inputs, List<string[]> outputs)
        {
            switch (LEVEL)
            {
                case 1:
                    foreach (string[] input in inputs)
                    {
                        List<string> output = new List<string>();

                        // Implement logic here
                        // Add all the output lines of a single input file to the output list
                        


                        // Ouput of all files are then stored in the outputs list
                        outputs.Add(output.ToArray());
                    }
                    break;
                default:
                    throw new ArgumentException("Invalid level");
            }
        }
    }
}
