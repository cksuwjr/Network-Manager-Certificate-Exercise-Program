using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;



namespace Router
{
    class RouterProgram
    {
        static void Main(string[] args)
        {
            RouterProgram Pg = new RouterProgram();



            string[] text = File.ReadAllLines(@"../../textfile\routerpro.txt");

            string state; // 콘솔 상태

            // 분류 찾기
            int sequence;
            for(sequence = 0; sequence < text.Length; sequence++)
            {
                if (text[sequence] == "Router")
                    break;
            }

            Console.WriteLine(text.Length);
            while(sequence < text.Length)
            {
                if (text[sequence] != "") 
                {
                    // 문제 찾기
                    if (text[sequence][0].ToString() == "+")
                    {
                        Console.WriteLine(text[sequence].Substring(1));
                        // 문제 초입

                        // 구성요소 초기화
                        Console.WriteLine();
                        state = "Router> ";
                        string answer = "";

                        // 질의 시작
                        while (true)
                        {
                            Pg.RouteConsole(ref state, ref answer);
                            if (answer == "채점")
                                break;
                        }
                    }
                }
                sequence++;
            }

            
        }
        public void RouteConsole(ref string state, ref string answer)
        {
            Console.Write(state);
            answer = Console.ReadLine();

            if (state == "Router> ")
            {
                if (answer == "en" || answer == "enable")
                    state = "Router# ";
            }
            else if (state == "Router# ")
            {
                if (answer == "conf t" || answer == "configure terminal")
                {
                    Console.WriteLine("Enter configuration commands, one per line. End with CNTL/Z");
                    state = "Router(config)# ";
                }
            }
            else if (state == "Router(config)# ")
            {
                if (answer == "hostname ICQA")
                    state = "ICQA(config)# ";
            }
            else if (state == "ICQA(config)# ")
            {
                if (answer == "exit")
                {
                    Console.WriteLine("\n\n%SYS-5-CONFIG_I: Configured from console by console");
                    state = "ICQA# ";
                }
            }
            else if (state == "ICQA# ")
            {
                if (answer == "copy r s")
                {
                    Console.WriteLine("Destination filename [startup-config]?");
                    string enter = Console.ReadLine();
                    Console.WriteLine("Building configuration...[OK]");
                }
            }
            
        }

















        public string Question(string Q, string Answer)
        {
            Console.Write(Q);
            string answer = Console.ReadLine();

            if ((Q == "Router> " && answer == "en") || (Q == "Router# " && answer == "conf t") || (Q == "Enter configuration commands, one per line. End with CNTL/Z.\nRouter(config)# " && answer == "hostname ICQA") || (Q == "ICQA(config)# " && answer == "exit") || (Q== "\n\n%SYS-5-CONFIG_I: Configured from console by console\nICQA# " && answer == "copy r s"))
            {
                Answer += answer;
                Answer += "\n";
                return Answer;
            }
            else
            {
                Console.WriteLine("% Unrecognized command");
                return Question(Q, Answer);
            }
        }
    }
}
