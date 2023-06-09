
using System;
using System.IO;

namespace PBG402
{
    class MainClass
    {
        static String USER_PATH = "/Users/baderaldenalmasre/Project/c#/PBG402/PBG402/users";
        static String CELLS_PATH = "/Users/baderaldenalmasre/Project/c#/PBG402/PBG402/cells";
        static String CALLS_PATH = "/Users/baderaldenalmasre/Project/c#/PBG402/PBG402/calls";
        static String COST_PATH = "/Users/baderaldenalmasre/Project/c#/PBG402/PBG402/cost/cost.txt";
        static List<User> user_list = new List<User>();
        static List<Cells> cells_list = new List<Cells>();
        static double cost = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("Windows version: {0}", Environment.OSVersion);
            Console.WriteLine("64 Bit operating system? :{0}",Environment.Is64BitOperatingSystem ? "Yes" : "No");
            Console.WriteLine("PC Name : {0}", Environment.MachineName);
            Console.WriteLine("Number of CPUS : {0}", Environment.ProcessorCount);
            Console.WriteLine("Windows folder : {0}", Environment.SystemDirectory);
            Console.WriteLine("Logical Drives Available : {0}", String.Join(", ",Environment.GetLogicalDrives()).TrimEnd(',', ' ').Replace("\\", String.Empty));

            ///////////////// User \\\\\\\\\\\\\\\\

            Console.WriteLine("");
            Console.WriteLine("------------------------ User ------------------------");


            FileInfo[] user_files = new DirectoryInfo(USER_PATH).GetFiles();

            for (var i =0;i< user_files.Length;i++)
            {
                var path = user_files[i].ToString();
                var user_info = System.IO.File.ReadAllLines(path).ToArray();
                User user = new User();
                user.fromfile(all_file: user_info!, _id: int.Parse(path.Split("/").Last().Split(".")[0]), _cost: 0);
                user_list.Add(user);
            }
            
            for (var i = 0; i < user_list.Count; i++)
            {
                Console.WriteLine(user_list[i].print_info());
            }
            Console.WriteLine("The Number of User is : "+user_list.Count);

            ///////////////// Cells \\\\\\\\\\\\\\\\
            Console.WriteLine("");
            Console.WriteLine("------------------------ Cells ------------------------");

            FileInfo[] cells_files = new DirectoryInfo(CELLS_PATH).GetFiles();

            for (var i = 0; i < cells_files.Length; i++)
            {
                var path = cells_files[i].ToString();
                var cells_info = System.IO.File.ReadAllLines(path).ToArray();
                Cells cells = new Cells();
                var all_address = "";
                for (var  j= 0; j < cells_info.Length; j++)
                {
                    all_address = all_address + " " + cells_info[j];

                }
                cells.fromfile( _id: int.Parse(path.Split("/").Last().Split(".")[0]), _address: all_address);
                cells_list.Add(cells);
            }

            for (var i = 0; i < cells_list.Count; i++)
            {
                Console.WriteLine(cells_list[i].print_info());
            }
            Console.WriteLine("The Number of Cells is : " + cells_list.Count);


            ///////////////// Calls \\\\\\\\\\\\\\\\
            // get cost of minute
            
            var cost = double.Parse(System.IO.File.ReadAllLines(COST_PATH)[0]);
           // Console.WriteLine(cost);

            Console.WriteLine("");
            Console.WriteLine("------------------------ Cost Per User ------------------------");


            FileInfo[] calls_files = new DirectoryInfo(CALLS_PATH).GetFiles();

            for (var i = 0; i < calls_files.Length; i++)
            {
                var path = calls_files[i].ToString();
                var calls_info = System.IO.File.ReadAllLines(path).ToArray();
                //Cells cells = new Cells();
                var all_cost = 0d;
                for (var j = 0; j < calls_info.Length; j++)
                {
                    var a = 0d;
                    for (var k = 0; k < calls_info[j].Split(" ").Length; k++)
                    {
                        try {
                           var _ = double.Parse(calls_info[j].Split(" ")[k]);
                            a = _+a;
                        }
                        catch {
                           
                        }
                    
                    }
                    all_cost = all_cost + a;
                }
                user_list[i].edit_cost(new_cost:all_cost,all_user: user_list,id: int.Parse(path.Split("/").Last().Split(".")[0]));
            }
            for (var i = 0; i < user_list.Count; i++)
            {
                Console.WriteLine(user_list[i].print_info());
            }


            ///////////////// Person that Most Calls To \\\\\\\\\\\\\\\\
            Console.WriteLine("");
            Console.WriteLine("------------------------ Person that Most Calls To ------------------------");
            new User().print_most_calls_to(all_user: user_list);












            //var a = new List<String>
            //{
            //    "aaa",
            //    "bbb",
            //    "ccc",
            //    "ddd"
            //};

            //User user = new User();
            //user.fromfile(all_file:a,_id:0,_cost:3.3);
            //Console.WriteLine(user.print_info());


            //string folderPath = "/Users/baderaldenalmasre/Project/c#/PBG402/PBG402/cost";

            // DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);




            //FileInfo[] files = directoryInfo.GetFiles();

            //foreach (FileInfo file in files)
            //{
            //    Console.WriteLine(file.Name);
            //}

        }
    }
}
