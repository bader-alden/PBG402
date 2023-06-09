using System;
namespace PBG402
{
	public class Cells
	{
        int? id;
        String? address;
        public void fromfile(int _id , String _address)
        {
            id = _id;
            address = _address;
        }

        public String print_info()
        {
            return "ID: " + id + "  Address: " + address;
        }


    }
}

