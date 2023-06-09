using System;
namespace PBG402
{
	public class User
	{
        int? id;
        String? first_name;
        String? last_name;
        String? address;
        String? phone_number;
        double? cost;
        public void fromfile(String[] all_file,int _id , double _cost)
        {
            id = _id;
            first_name = all_file[0];
            last_name = all_file[1];
            address = all_file[2];
            phone_number = all_file[3];
            cost = double.Floor(_cost);
        }

        public String print_info()
        {
            return "ID: "+id+"  First Name: "+first_name + "  Last Name: " + last_name + "  Address: " + address + "  Phone Number: " + phone_number + "  Cost: " + cost+" SY";
        }

        public void edit_cost(double new_cost,List<User>all_user,int id )
        {
            for(var i = 0; i < all_user.Count; i++)
            {
                if (all_user[i].id == id) {
                    cost = double.Floor(new_cost);
                    
                }
                
            }
           
        }

        public void print_most_calls_to(List<User> all_user)
        {
            double? top = 0d;
           List<int> id_of_top =new List<int>();
            for (var i = 0; i < all_user.Count; i++)
            {
                if (all_user[i].cost >= top)
                {
                    top= all_user[i].cost;
                   
                }
            }
            for (var i = 0; i < all_user.Count; i++)
            {
                if (all_user[i].cost == top)
                {
                    id_of_top.Add(all_user[i].id ?? 999);
                }
            }
            for(var j = 0; j < id_of_top.Count; j++)
            {
                for (var jj = 0; jj < all_user.Count; jj++)
                {
                    if (all_user[jj].id == id_of_top[j])
                    {
                        Console.WriteLine(all_user[jj].print_info());
                    }
                    
                }
                
            }

        }


    }
}

