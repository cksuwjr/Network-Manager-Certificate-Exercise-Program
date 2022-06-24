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


            //StreamReader sr = new StreamReader("textfile/routerpro.txt");
            string[] text = File.ReadAllLines(@"textfile\routerpro.txt");
            

            string state; // 콘솔 상태

            // 분류 찾기
            int sequence;
            for (sequence = 0; sequence < text.Length; sequence++)
            {
                if (text[sequence] == "Router")
                    break;
            }

            // 시작
            while (sequence < text.Length)
            {
                if (text[sequence] != "")
                {
                    // 문제 찾기
                    if (text[sequence][0].ToString() == "+")
                    {
                        string Problem = text[sequence++].Substring(1);
                        Console.WriteLine(Problem + "  (채점은 숫자0을 입력해주세요.)");

                        string Correct = "";
                        string Input = "";

                        while (text[sequence] != "")
                            Correct += text[sequence++] + "\n"; // 옳은 답안 기록

                        // 구성요소 초기화
                        Console.WriteLine();
                        state = "Router> ";
                        string answer = "";

                        // 질의 시작
                        while (true)
                        {
                            Pg.RouteConsole(ref state, ref answer, ref Input); // 라우터 콘솔 띄우기
                            if (answer == "0") // 채점하기
                            {
                                Console.Clear();

                                if (Input == Correct)
                                    Console.WriteLine("정답입니다!");
                                else
                                {
                                    Console.WriteLine("오답입니다!\n");

                                    Console.WriteLine(Problem);
                                    Console.WriteLine();
                                    Console.WriteLine("입력값: ");
                                        Console.WriteLine(Input);
                                    Console.WriteLine();
                                    Console.WriteLine("정답: ");
                                        Console.WriteLine(Correct);
                                    Console.WriteLine();

                                    Input = "";
                                    Correct = "";

                                    Console.WriteLine("다음문제로 넘어가려면 엔터를 누르세요");
                                    Console.ReadLine();
                                    Console.Clear();
                                }
                                break;
                            }
                        }
                    }
                }
                sequence++;
            }


        }
        public void RouteConsole(ref string state, ref string answer, ref string Input)
        {
            Console.Write(state);
            answer = Console.ReadLine();
            if (answer != "채점")
                Input += answer + "\n"; // 사용자 답안 기록

            if (state == "Router> ")
            {
                if (answer == "en" || answer == "enable")
                    state = "Router# ";
                else
                    Console.WriteLine("% Invalid input detected ~ 비유효한 식별자입니다.");
            }
            else if (state == "Router# ")
            {
                if (answer == "conf t" || answer == "config terminal")
                {
                    Console.WriteLine("Enter configuration commands, one per line. End with CNTL/Z");
                    state = "Router(config)# ";
                }
                else if (answer == "copy r s")
                {
                    Console.WriteLine("Destination filename [startup-config]?");
                    string enter = Console.ReadLine();
                    Console.WriteLine("Building configuration...[OK]");
                }
                else if (answer.Contains("line"))
                {
                    state = "Router(config-line)";
                }
                else if (answer == "show interface")
                    Console.WriteLine("대충 인터페이스 띄워드렸읍니다~");
                else if (answer == "show user")
                    Console.WriteLine("대충~ 유저 정보 띄웠다는 글");
                else if (answer == "show ip route")
                    Console.WriteLine("대충~ 라우팅 테이블 정보 띄웠다는 글");
                else if (answer == "show flash")
                    Console.WriteLine("대충~ 플래쉬 내용 확인 띄웠다는 글");
                else if (answer == "show process")
                    Console.WriteLine("대충~ 프로세스 띄웠다는 글");

                //else
                //    Console.WriteLine("% Invalid input detected ~ 비유효한 식별자입니다.");
            }
            else if (state == "Router(config)# ")
            {
                //if (answer == "hostname ICQA")
                //    state = "ICQA(config)# ";
                if (answer.Contains("hostname"))
                {
                    //Console.WriteLine(answer.Substring(answer.LastIndexOf("hostname") + 9));
                    state = answer.Substring(answer.LastIndexOf("hostname") + 9) + "(config)# ";
                }
                //else if (answer == "int fastethernet 0/0")
                else if (answer.Contains("int"))
                    state = "Router(config-if)# ";
                else if (answer == "exit")
                {
                    Console.WriteLine("\n\n%SYS-5-CONFIG_I: Configured from console by console");
                    state = state.Substring(0, state.LastIndexOf("(config)#")) + "# ";
                }
                else
                    Console.WriteLine("% Invalid input detected ~ 비유효한 식별자입니다.");
            }
            else if (state == "Router(config-if)# " || state == "Router(config-line)")
            {
                if (answer == "exit")
                    state = "Router(config)# ";
                //else if(answer.Contains("ip add"))
                //{
                //    //
                //}
                //else
                //    Console.WriteLine("% Invalid input detected ~ 비유효한 식별자입니다.");
            }
            //else if (state == "ICQA(config)# " || state == "Router(config)# ")
            //{
            //    if (answer == "exit")
            //    {
            //        Console.WriteLine("\n\n%SYS-5-CONFIG_I: Configured from console by console");
            //        state = "ICQA# ";
            //    }
            //    else
            //        Console.WriteLine("% Invalid input detected ~ 비유효한 식별자입니다.");
            //}
            else if (state.Contains("(config)#"))// == "ICQA(config)# " || state == "Router(config)# "
            {
                if (answer == "exit")
                {
                    Console.WriteLine("\n\n%SYS-5-CONFIG_I: Configured from console by console");
                    state = state.Substring(0, state.LastIndexOf("(config)#")) + "# ";
                }
                else
                    Console.WriteLine("% Invalid input detected ~ 비유효한 식별자입니다.");
            }
            //else if (state == "ICQA# ")
            //{
            //    if (answer == "copy r s")
            //    {
            //        Console.WriteLine("Destination filename [startup-config]?");
            //        string enter = Console.ReadLine();
            //        Console.WriteLine("Building configuration...[OK]");
            //    }
            //    else
            //        Console.WriteLine("% Invalid input detected ~ (비유효한 식별자입니다.)");
            //}
            else if (state.Contains("# "))
            {
                if (answer == "copy r s")
                {
                    Console.WriteLine("Destination filename [startup-config]?");
                    string enter = Console.ReadLine();
                    Console.WriteLine("Building configuration...[OK]");
                }
                else if (answer == "conf t" || answer == "config terminal")
                {
                    Console.WriteLine("Enter configuration commands, one per line. End with CNTL/Z");
                    state = "Router(config)# ";
                }
                else
                    Console.WriteLine("% Invalid input detected ~ (비유효한 식별자입니다.)");
            }
        }

















        
    }
}
