using System;
using System.Speech.Recognition;
using System.Threading;

namespace SubtitlesApp
{
    class TestSpeechRecognizer
    {

        // Indicate whether the asynchronous emulate recognition  
        // operation has completed.  
        static bool completed;

        public void Start()
        {

            // Initialize an instance of the shared recognizer.  
            using (SpeechRecognizer recognizer = new SpeechRecognizer())
            {

                // Create and load a sample grammar.  
                Grammar testGrammar =
                  new Grammar(new GrammarBuilder("testing testing"));
                testGrammar.Name = "Test Grammar";
                recognizer.LoadGrammar(testGrammar);

                // Attach event handlers for recognition events.  
                recognizer.SpeechRecognized +=
                  new EventHandler<SpeechRecognizedEventArgs>(
                    SpeechRecognizedHandler);

                completed = false;
                
                // Wait for the asynchronous operation to complete.  
                while (!completed)
                {
                    Console.WriteLine(recognizer.State);
                    Thread.Sleep(333);
                    Console.Clear();
                }

                completed = false;

                // Start asynchronous emulated recognition.  
                // This does not match the grammar or generate a SpeechRecognized event.  
                recognizer.EmulateRecognizeAsync("testing one two three");

                // Wait for the asynchronous operation to complete.  
                while (!completed)
                {
                    Console.WriteLine(recognizer.State);
                    Thread.Sleep(333);
                    Console.Clear();
                }
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        // Handle the SpeechRecognized event.  
        static void SpeechRecognizedHandler(
          object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result != null)
            {
                Console.WriteLine("Recognition result = {0}",
                  e.Result.Text ?? "<no text>");
                completed = true;
            }
            else
            {
                Console.WriteLine("No recognition result");
            }
        }
    }
}