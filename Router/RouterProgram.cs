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


            string state; // 콘솔 상태

            string[] routerpro = File.ReadAllLines(@"textfile\routerpro.txt"); // 라우터 애뮬레이터 프로그램 문제
            string[] rinuxshort = File.ReadAllLines(@"textfile\rinuxshort.txt"); // 리눅스 애뮬레이터 프로그램 문제
            string[] networkpro = File.ReadAllLines(@"textfile\networkpro.txt"); // 네트워크 단답형 문제

            while (true)
            {
                Console.WriteLine("네트워크 관리사2급 실기 연습 프로그램입니다.            제작자: 차경훈");
                Console.WriteLine();
                Console.WriteLine("                                             시험순서    문항수     배점     합계   ");
                Console.WriteLine("   다이렉트 케이블 만들기는 직접 실습하기      [1]     [ 1 문제 ] [ 6.5 X 1 = 6.5  ]");
                Console.WriteLine("   윈도우 서버문제는 기출풀어보세요 약 12문제  [2]     [ 8 문제 ] [ 5.5 X 8 = 44   ]");
                Console.WriteLine("   신경향 및 보안문제는 제공하지 않습니다      [?]     [ 1 문제 ] [ 5.5 X 1 = 5.5  ]");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("1. 리눅스 명령어                               [3]     [ 2 문제 ] [ 5.5 X 2 = 11   ]");
                Console.WriteLine("2. 네트워크 단답형                             [4]     [ 3 문제 ] [ 5.5 X 3 = 16.5 ]");
                Console.WriteLine("3. 라우터 설정 애뮬레이터                      [5]     [ 3 문제 ] [ 5.5 X 3 = 16.5 ]");
                Console.WriteLine("                                                       [ 18문제 ] [ 총점    : 100  ]");
                Console.WriteLine("4. 종료");
                Console.WriteLine();
                Console.WriteLine("학습하실 모듈을 선택해주세요.");
                Console.WriteLine();

                Console.Write("숫자 입력: ");
                string input = Console.ReadLine();
                int n = 10000;
                try
                {
                    n = int.Parse(input);
                }
                catch { }

                Console.Clear();
                switch (n)
                {
                    case 1:
                        Console.WriteLine("리눅스 명령어를 고르셨습니다. 행운을 빌어요~\n\n");
                        break;
                    case 2:
                        Console.WriteLine("네트워크 단답형을 고르셨습니다. 행운을 빌어요~\n\n");
                        break;
                    case 3:
                        Console.WriteLine("라우터 설정 애뮬레이터를 고르셨습니다. 행운을 빌어요~\n\n");
                        break;
                    case 4:
                        Console.WriteLine("프로그램을 종료합니다.");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("에헤이! 야 야 그거 아니다 잘못 입력하셨네");
                        break;
                }

                switch (n)
                {
                    case 1:
                        // 분류 찾기
                        int readseq;
                        for (readseq = 0; readseq < rinuxshort.Length; readseq++)
                        {
                            if (rinuxshort[readseq].ToString() == "리눅스")
                                break;
                        }

                        while (readseq < rinuxshort.Length)
                        {
                            if (rinuxshort[readseq] != "")
                            {
                                // 문제 찾기
                                if (rinuxshort[readseq][0].ToString() == "+")
                                {
                                    Console.WriteLine(rinuxshort[readseq].Substring(1));
                                    Console.WriteLine();
                                    Console.Write("정답 입력: ");
                                    string answer = Console.ReadLine();

                                    string correct = rinuxshort[readseq + 1];

                                    if (answer == correct)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("정답입니다!\n\n");
                                    }
                                    else
                                    {
                                        Console.Clear();

                                        Console.WriteLine("틀렸습니다!\n\n");
                                        Console.WriteLine(rinuxshort[readseq] + "\n");
                                        Console.WriteLine("답: " + rinuxshort[readseq + 1]);
                                        Console.WriteLine("엔터를 누르면 넘어갑니다.");
                                        Console.ReadLine();
                                        Console.Clear();
                                    }
                                }
                            }
                            readseq++;
                        }
                        break;
                    case 2:
                        // 분류 찾기
                        int rseq;
                        for (rseq = 0; rseq < networkpro.Length; rseq++)
                        {
                            if (networkpro[rseq].ToString() == "네트워크")
                                break;
                        }

                        while (rseq < networkpro.Length)
                        {
                            if (networkpro[rseq] != "")
                            {
                                // 문제 찾기
                                if (networkpro[rseq][0].ToString() == "+")
                                {
                                    Console.WriteLine(networkpro[rseq].Substring(1));
                                    Console.WriteLine();
                                    Console.Write("정답 입력: ");
                                    string answer = Console.ReadLine();

                                    string correct = networkpro[rseq + 1];

                                    if (answer == correct)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("정답입니다!\n\n");
                                    }
                                    else
                                    {
                                        Console.Clear();

                                        Console.WriteLine("틀렸습니다!\n\n");
                                        Console.WriteLine(networkpro[rseq] + "\n");
                                        Console.WriteLine("답: " + networkpro[rseq + 1]);
                                        Console.WriteLine("엔터를 누르면 넘어갑니다.");
                                        Console.ReadLine();
                                        Console.Clear();
                                    }
                                }
                            }
                            rseq++;
                        }
                        break;
                    case 3:
                        // 분류 찾기
                        int sequence;
                        for (sequence = 0; sequence < routerpro.Length; sequence++)
                        {
                            if (routerpro[sequence] == "Router")
                                break;
                        }


                        // 시작
                        while (sequence < routerpro.Length)
                        {
                            if (routerpro[sequence] != "")
                            {
                                // 문제 찾기
                                if (routerpro[sequence][0].ToString() == "+")
                                {
                                    string Problem = routerpro[sequence++].Substring(1);
                                    Console.WriteLine(Problem + "  (채점은 숫자0을 입력해주세요.)");

                                    string Correct = "";
                                    string Input = "";

                                    while (routerpro[sequence] != "")
                                        Correct += routerpro[sequence++] + "\n"; // 옳은 답안 기록

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
                        break;


                    default:
                        Console.WriteLine("ㅃㅃ ㅋㅋ");
                        break;
                }
                Console.WriteLine("문제가 모두 끝났습니다.");
                Console.WriteLine("처음으로 돌아갑니다.");
                Console.ReadLine();
                Console.Clear();
            }
        }
        public void RouteConsole(ref string state, ref string answer, ref string Input)
        {
            Console.Write(state);
            answer = Console.ReadLine();
            if (answer != "0")
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
                    state = "Router(config-line) ";
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
                else if (answer.Contains("ip"))
                {

                }
                else if (answer.Contains("line"))
                {
                    state = "Router(config-line) ";
                }
                else if (answer == "exit")
                {
                    Console.WriteLine("\n\n%SYS-5-CONFIG_I: Configured from console by console");
                    state = state.Substring(0, state.LastIndexOf("(config)#")) + "# ";
                }
                else
                    Console.WriteLine("% Invalid input detected ~ 비유효한 식별자입니다.");
            }
            else if (state == "Router(config-if)# " || state == "Router(config-line) ")
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
                if (answer.Contains("hostname"))
                {
                    //Console.WriteLine(answer.Substring(answer.LastIndexOf("hostname") + 9));
                    state = answer.Substring(answer.LastIndexOf("hostname") + 9) + "(config)# ";
                }
                //else if (answer == "int fastethernet 0/0")
                else if (answer.Contains("int"))
                    state = "Router(config-if)# ";
                else if (answer.Contains("line"))
                {
                    state = "Router(config-line) ";
                }
                else if (answer == "exit")
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
