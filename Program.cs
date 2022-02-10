////switch (subject.ToLower())
//ConsoleColor oldColor = Console.ForegroundColor;
//WriteColoredLine("Босс может атаковать в двух режимах: все атаки по очереди и случайной атакой", ConsoleColor.Yellow);
//int Health = 1000;
//int Armor = 20;
//bool isRandomAttack = GetRandomFromZeroTo(2) == 0;
//WriteColoredLine("Босс будет атаковать: " + (isRandomAttack ? "случайно" : "все атаки по очереди"), ConsoleColor.Yellow);
//WriteColoredLine("Нажмите enter для начала боя", ConsoleColor.Green);
//Console.ReadLine();
//int attackNumber = 0;
//void WriteColoredLine(string massage, ConsoleColor color)
//{
//    oldColor = Console.ForegroundColor;
//    Console.ForegroundColor = color;
//    Console.WriteLine(massage);
//    Console.ForegroundColor = oldColor;
//}
//int GetRandomFromZeroTo(int num) => DateTime.Now.Millisecond % num;
//void Attack(int num)
//{
//    if (num == 0)
//    {
//        WriteColoredLine("Босс атаковал с немыслимой яростью своими руками", ConsoleColor.DarkRed);
//        Health = Health - (100 - Armor);
//    }
//    else if (num == 1)
//    {
//        WriteColoredLine("Босс исполнил новый альбом Ольги бузовой", ConsoleColor.DarkMagenta);
//        Health = Health - (140 - Armor);
//    }
//    else if (num == 2)
//    {
//        WriteColoredLine("Босс приуныл и рассказал вам о своём долгом пути и дал пару советов, после выпил ритуальный стопарь боярки", ConsoleColor.DarkGray);
//        Health = Health - (80 - Armor);
//    }
//}
//while (Health > 0)
//{
//    Console.Clear();
//    WriteColoredLine("У вас здоровья: " + Health, ConsoleColor.Red);

//    if (isRandomAttack)
//    {
//        Attack(GetRandomFromZeroTo(3));
//    }
//    else
//    {
//        Attack(attackNumber);

//        attackNumber += 1;
//        if (attackNumber > 2)
//        {
//            attackNumber = 0;
//        }
//    }

//    Thread.Sleep(3000);
//}
//WriteColoredLine("Бой закончен, вы погибли", ConsoleColor.DarkGray);



        
       
            bool r = true;
            string[] taskarray = new string[0];
            int[] statusInt = new int[0];

            bool Check(string name)
            {
                foreach (string s in taskarray)
                {
                    if (s == name)
                    {
                        return true;
                    }
                }

                return false;
            }

            while (true)
            {
                Console.WriteLine("choise a comand ");
                string comand = Console.ReadLine();
                string task;
                int status;
                switch ((comand.ToLower()))
                {
                    case "add-item":
                        Console.WriteLine("Enter item ");
                        task = Console.ReadLine().ToLower();
                        if (Check(task))
                        {
                            continue;
                        }

                        Array.Resize<string>(ref taskarray, taskarray.Length + 1);
                        Array.Resize<int>(ref statusInt, statusInt.Length + 1);
                        taskarray[taskarray.Length - 1] = task;

                        break;
                    case "remove-item":

                        Console.WriteLine("Enter item ");
                        task = Console.ReadLine().ToLower();
                        if (!Array.Exists(taskarray, x => x.ToLower() == task))
                        {
                            continue;
                        }

                        if (task == "*")
                        {
                            Array.Resize<string>(ref taskarray, 0);
                            Array.Resize<int>(ref statusInt, 0);
                            break;
                        }

                        for (int i = 0; i < taskarray.Length; i++)
                        {
                            if (taskarray[i] == task)
                            {
                                string temp;
                                for (int y = i; y < taskarray.Length; y++)
                                {
                                    if (y + 1 == taskarray.Length)
                                    {
                                        break;
                                    }
                                    temp = taskarray[y + 1];
                                    taskarray[y] = temp;
                                }
                                break;
                            }
                        }

                        Array.Resize<string>(ref taskarray, taskarray.Length - 1);
                        Array.Resize<int>(ref statusInt, statusInt.Length - 1);

                        break;

                    case "mark-as":
                        Console.WriteLine("Enter task name ");
                        task = Console.ReadLine().ToLower();
                        if (!Check(task))
                        {
                            continue;
                        }

                        Console.WriteLine("Enter status ");
                        status = int.Parse(Console.ReadLine());

                        if (status != 0 && status != 1)
                        {
                            Console.WriteLine("wrong status");
                            continue; ;
                        }

                        for (int i = 0; i < taskarray.Length; i++)
                        {
                            if (taskarray[i] == task)
                            {
                                statusInt[i] = status;
                            }
                        }

                        break;

                    case "show":

                        Console.WriteLine("Enter status ");
                        status = int.Parse(Console.ReadLine());

                        
                        if (status != 0 && status != 1)
                        {
                            Console.WriteLine("wrong status");
                            continue; ;
                        }

                        for (int i = 0; i < taskarray.Length; i++)
                        {
                            if (status == 1 && statusInt[i] == 1)
                            {
                                Console.WriteLine(taskarray[i]);
                            }
                            else if (status == 0 && statusInt[i] == 0)
                            {
                                Console.WriteLine(taskarray[i]);
                            }
                            else
                            {
                                Console.WriteLine(taskarray[i]);
                            }
                        }

                        break;



                }

                foreach (string s in taskarray)
                {
                    Console.WriteLine(s);
                }


            }
     